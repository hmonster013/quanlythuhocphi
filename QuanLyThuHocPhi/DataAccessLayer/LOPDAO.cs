using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject.Lop;
using System.Net.Http;
using System.Net.Http.Json;
using ValueObject.Khoa;

namespace DataAccessLayer
{
    public class LOPDAO
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = Constants.BASE_API_URL + "api/lop";

        public LOPDAO()
        {
            _httpClient = HttpManager.GetHttpClient();
        }

        public async Task<List<LOP>> GetData()
        {
            var response = await _httpClient.GetAsync(BASE_URL);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<LOP>>();
        }

        public async Task<LOP> GetDataByID(string maLop)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/{maLop}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LOP>();
            }

            return null;
        }

        public async Task<List<LOP>> GetDataByMAKHOA(string MAKHOA)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/khoa/{MAKHOA}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<LOP>>();
        }

        public async Task<List<LOP>> GetDataByMACN(string MACN) 
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/chuyennganh/{MACN}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<LOP>>();
        }

        public async Task<int> Insert(CreateLopRequestDto obj)
        {
            var response = await _httpClient.PostAsJsonAsync(BASE_URL, obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Update(String maLop, UpdateLopRequestDto obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{maLop}", obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Delete(string maLop)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{maLop}");
            response.EnsureSuccessStatusCode();

            return 1;
        }
    }
}
