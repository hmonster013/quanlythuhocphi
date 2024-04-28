using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject.ChuyenNganh;
using System.Net.Http;
using System.Net.Http.Json;

namespace DataAccessLayer
{
    public class CHUYENNGANHDAO
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = Constants.BASE_API_URL + "api/chuyennganh";

        public CHUYENNGANHDAO()
        {
            _httpClient = HttpManager.GetHttpClient();
        }

        public async Task<List<CHUYENNGANH>> GetData()
        {
            var response = await _httpClient.GetAsync(BASE_URL);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<CHUYENNGANH>>();
        }

        public async Task<CHUYENNGANH> GetDataByID(string maCN)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/{maCN}");
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CHUYENNGANH>();
            }

            return null;
        }

        public async Task<List<CHUYENNGANH>> GetDataByMAKHOA(string MAKHOA)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/khoa/{MAKHOA}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<CHUYENNGANH>>();
        }

        public async Task<int> Insert(CreateChuyenNganhRequestDto obj)
        {
            var response = await _httpClient.PostAsJsonAsync(BASE_URL, obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Update(string maCN, UpdateChuyenNganhRequestDto obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{maCN}", obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Delete(string maCN)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{maCN}");
            response.EnsureSuccessStatusCode();

            return 1;
        }
    }
}
