using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject.LopHocPhan;
using System.Net.Http;
using System.Net.Http.Json;

namespace DataAccessLayer
{
    public class LOPHOCPHANDAO
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = Constants.BASE_API_URL + "api/lophocphan";

        public LOPHOCPHANDAO()
        {
            _httpClient = HttpManager.GetHttpClient();
        }

        public async Task<List<LOPHOCPHAN>> GetData()
        {
            var response = await _httpClient.GetAsync(BASE_URL);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<LOPHOCPHAN>>();
        }

        public async Task<LOPHOCPHAN> GetDataByID(int maLHP)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/{maLHP}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LOPHOCPHAN>();
            }

            return null;
        }

        public async Task<List<LOPHOCPHAN>> GetDataByChuyenNganh(string MACN)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/chuyennganh/{MACN}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<LOPHOCPHAN>>();
        }

        public async Task<int> Insert(CreateLopHocPhanRequestDto obj)
        {
            var response = await _httpClient.PostAsJsonAsync(BASE_URL, obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Update(int maLHP, UpdateLopHocPhanRequestDto obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{maLHP}", obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Delete(int maLHP)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{maLHP}");
            response.EnsureSuccessStatusCode();

            return 1;
        }

    }
}
