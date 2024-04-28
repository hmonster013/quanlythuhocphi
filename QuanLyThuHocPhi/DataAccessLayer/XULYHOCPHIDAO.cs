using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ValueObject.XuLyHocPhi;

namespace DataAccessLayer
{
    public class XULYHOCPHIDAO
    {
        private dbConnect _dbConnect = new dbConnect();
        private readonly HttpClient _httpClient;
        private const string BASE_URL = Constants.BASE_API_URL + "api/xulyhocphi";

        public XULYHOCPHIDAO()
        {
            _httpClient = HttpManager.GetHttpClient();
        }

        public DataTable GetDataHocPhi(string MASV)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MASV", MASV)
            };
            return _dbConnect.GetData("sp_XULYHOCPHI_all", param);
        }

        public async Task<HocPhiDto> GetDataTongHocPhiOfSV(string MASV)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/sinhvien/sum/{MASV}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<HocPhiDto>();
        }

        public async Task<HocPhiDto> GetDataBySVandHK(string MASV, int HOCKY)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/sinhvienandhocky/sum/{MASV}/{HOCKY}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<HocPhiDto>();
            }

            return null;
        }

        public DataTable GetAllDataHocPhi(string MAKHOA, string MACN, string MALOP)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAKHOA", MAKHOA),
                new SqlParameter("MACN", MACN),
                new SqlParameter("MALOP", MALOP)
            };
            return _dbConnect.GetData("sp_XULYHOCPHI_ds_all", param);
        }

        public DataTable GetAllDataTongHocPhi(string MAKHOA, string MACN, string MALOP)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAKHOA", MAKHOA),
                new SqlParameter("MACN", MACN),
                new SqlParameter("MALOP", MALOP)
            };
            return _dbConnect.GetData("sp_XULYHOCPHI_ds_sum_all", param);
        }

        public DataTable GetAllDataNoHocPhi(string MAKHOA, string MACN, string MALOP)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAKHOA", MAKHOA),
                new SqlParameter("MACN", MACN),
                new SqlParameter("MALOP", MALOP)
            };
            return _dbConnect.GetData("sp_XULYHOCPHI_ds_nohp_all", param);
        }
    }
}
