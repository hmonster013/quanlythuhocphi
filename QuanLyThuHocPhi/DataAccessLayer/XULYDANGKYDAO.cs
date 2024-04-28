using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ValueObject.DangKy;
using ValueObject.XuLyDangKy;

namespace DataAccessLayer
{
    public class XULYDANGKYDAO
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = Constants.BASE_API_URL + "api/xulydangky";

        public XULYDANGKYDAO()
        {
            _httpClient = HttpManager.GetHttpClient();
        }

        public async Task<List<LopHocPhanQueryDto>> GetDataLHPDaDK(DANGKY obj)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/1/{obj.MADK}/{obj.MASV}/{obj.HOCKY}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<LopHocPhanQueryDto>>();
        }

        public async Task<List<LopHocPhanQueryDto>> GetDataLHPChuaDK(DANGKY obj)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/0/{obj.MADK}/{obj.MASV}/{obj.HOCKY}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<LopHocPhanQueryDto>>();
        }
    }
}
