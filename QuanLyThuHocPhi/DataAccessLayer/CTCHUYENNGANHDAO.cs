using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject.CTChuyenNganh;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Cache;

namespace DataAccessLayer
{
    public class CTCHUYENNGANHDAO
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = Constants.BASE_API_URL + "api/ctchuyennganh";

        public CTCHUYENNGANHDAO()
        {
            _httpClient = HttpManager.GetHttpClient();
        }

        public async Task<List<CTCHUYENNGANH>> GetData()
        {
            var response = await _httpClient.GetAsync(BASE_URL);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<CTCHUYENNGANH>>();
        }

        public async Task<CTCHUYENNGANH> GetDataByID(int maCTCN)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/{maCTCN}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CTCHUYENNGANH>();
            }

            return null;
        }

        public async Task<int> Insert(CreateCTChuyenNganhRequestDto obj)
        {
            var response = await _httpClient.PostAsJsonAsync(BASE_URL, obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Update(int maCTCN, UpdateCTChuyenNganhRequestDto obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{maCTCN}", obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Delete(int maCTCN)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{maCTCN}");
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> DeleteByMaMH(string MAMH)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/monhoc/{MAMH}");
            if (response.IsSuccessStatusCode)
            {
                return 1;
            }

            return 0;
        }
    }
}
