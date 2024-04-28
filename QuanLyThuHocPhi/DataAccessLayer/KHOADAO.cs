using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Json;
using ValueObject.Khoa;

namespace DataAccessLayer
{
    public class KHOADAO
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = Constants.BASE_API_URL + "api/khoa";

        public KHOADAO()
        {
            _httpClient = HttpManager.GetHttpClient();
        }

        public async Task<List<KHOA>> GetData()
        {
            var response = await _httpClient.GetAsync(BASE_URL);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<KHOA>>();
        }

        public async Task<KHOA> GetDataByID(string maKhoa)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/{maKhoa}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<KHOA>();
            }

            return null;
        }

        public async Task<int> Insert(CreateKhoaRequestDto obj)
        {
            var response = await _httpClient.PostAsJsonAsync(BASE_URL, obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Update(string maKhoa, UpdateKhoaRequestDto obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{maKhoa}", obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Delete(string maKhoa)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{maKhoa}");
            response.EnsureSuccessStatusCode();

            return 1;
        }
    }
}
