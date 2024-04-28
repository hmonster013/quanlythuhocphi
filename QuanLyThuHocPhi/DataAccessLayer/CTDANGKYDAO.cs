using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject.CTDangKy;
using System.Net.Http;
using System.Net.Http.Json;
using ValueObject.DangKy;

namespace DataAccessLayer
{
    public class CTDANGKYDAO
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = Constants.BASE_API_URL + "api/ctdangky";

        public CTDANGKYDAO()
        {
            _httpClient = HttpManager.GetHttpClient();
        }

        public async Task<List<CTDANGKY>> GetData()
        {
            var response = await _httpClient.GetAsync(BASE_URL);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<CTDANGKY>>();
        }

        public async Task<CTDANGKY> GetDataByID(int maCTDK)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/{maCTDK}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CTDANGKY>();
            }

            return null;
        }

        public async Task<int> Insert(CreateCTDangKyRequestDto obj)
        {
            var response = await _httpClient.PostAsJsonAsync(BASE_URL, obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Update(int maCTDK, UpdateCTDangKyRequestDto obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{maCTDK}", obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Delete(int maCTDK)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{maCTDK}");
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> DeleteByCondition(int maDangKy, int maLopHocPhan)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{maDangKy}/{maLopHocPhan}");
            response.EnsureSuccessStatusCode();

            return 1;
        }
    }
}
