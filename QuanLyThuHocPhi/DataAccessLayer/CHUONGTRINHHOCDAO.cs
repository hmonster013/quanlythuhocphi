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
using ValueObject.MonHoc;

namespace DataAccessLayer
{
    public class CHUONGTRINHHOCDAO
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = Constants.BASE_API_URL + "api/chuongtrinhhoc";

        public CHUONGTRINHHOCDAO()
        {
            _httpClient = HttpManager.GetHttpClient();
        }

        public async Task<List<MONHOC>> GetDataBySinhVien(string MASV)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/sinhvien/{MASV}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<MONHOC>>();
        }

        public async Task<List<MONHOC>> GetDataBySVHocKy(string MASV, int HOCKY) 
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/sinhvienandhocky/{MASV}/{HOCKY}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<MONHOC>>();
        }

        public async Task<List<MONHOC>> GetDataByChuyenNganh(string MACN)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/1/{MACN}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<MONHOC>>();
        }

        public async Task<List<MONHOC>> GetDataNotInChuyenNganh(string MACN)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/0/{MACN}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<MONHOC>>();
        }
    }
}
