using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;
using System.Net.Http;
using System.Net.Http.Json;
using ValueObject.MonHoc;

namespace DataAccessLayer
{
    public class MONHOCDAO
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = Constants.BASE_API_URL + "api/monhoc";

        public MONHOCDAO()
        {
            _httpClient = HttpManager.GetHttpClient();
        }

        public async Task<List<MONHOC>> GetData()
        {
            var response = await _httpClient.GetAsync(BASE_URL);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<MONHOC>>();
        }

        public async Task<MONHOC> GetDataByID(string maMH)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/{maMH}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<MONHOC>();
            }

            return null;
        }

        public async Task<int> Insert(CreateMonHocRequestDto obj)
        {
            var response = await _httpClient.PostAsJsonAsync(BASE_URL, obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Update(string maMH, UpdateMonHocRequestDto obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{maMH}", obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Delete(string maMH)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{maMH}");
            response.EnsureSuccessStatusCode();

            return 1;
        }
    }
}
