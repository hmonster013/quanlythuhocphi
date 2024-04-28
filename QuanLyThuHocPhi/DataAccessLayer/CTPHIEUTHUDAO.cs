using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ValueObject;
using ValueObject.CTPhieuThu;

namespace DataAccessLayer
{
    public class CTPHIEUTHUDAO
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = Constants.BASE_API_URL + "api/ctphieuthu";

        public CTPHIEUTHUDAO()
        {
            _httpClient = HttpManager.GetHttpClient();
        }

        public async Task<List<CTPHIEUTHU>> GetData()
        {
            var response = await _httpClient.GetAsync(BASE_URL);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<CTPHIEUTHU>>();
        }

        public async Task<CTPHIEUTHU> GetDataByMaCTPT(int maCTPT)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/{maCTPT}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CTPHIEUTHU>();
            }

            return null;
        }

        public async Task<List<CTPHIEUTHU>> GetDataByMaPT(int MAPT)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/phieuthu/{MAPT}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<CTPHIEUTHU>>();
        }

        public async Task<int> Insert(CreateCTPhieuThuRequestDto obj)
        {
            var response = await _httpClient.PostAsJsonAsync(BASE_URL, obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Update(int maCTPT, UpdateCTPhieuThuRequestDto obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{maCTPT}", obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Delete(int maCTPT)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{maCTPT}");
            response.EnsureSuccessStatusCode();

            return 1;
        }
    }
}
