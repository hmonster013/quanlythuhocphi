using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject.PhieuThu;
using System.Net.Http;
using System.Net.Http.Json;

namespace DataAccessLayer
{
    public class PHIEUTHUDAO
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = Constants.BASE_API_URL + "api/phieuthu";

        public PHIEUTHUDAO()
        {
            _httpClient = HttpManager.GetHttpClient();
        }

        public async Task<List<PHIEUTHU>> GetData()
        {
            var response = await _httpClient.GetAsync(BASE_URL);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<PHIEUTHU>>();
        }

        public async Task<PHIEUTHU> GetDataByID(int maPT)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/{maPT}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<PHIEUTHU>();
            }

            return null;
        }

        public async Task<List<PHIEUTHU>> GetDataByMASV(string MASV)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/sinhvien/{MASV}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<PHIEUTHU>>();
        }

        public async Task<PHIEUTHU> GetDataByMaSVandHK(string MASV, int HOCKY) 
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/sinhvienandhocky/{MASV}/{HOCKY}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<PHIEUTHU>();
            }

            return null;
        }

        public async Task<int> Insert(CreatePhieuThuRequestDto obj)
        {
            var response = await _httpClient.PostAsJsonAsync(BASE_URL, obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Update(int maPT, UpdatePhieuThuRequestDto obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{maPT}", obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Delete(int maPT)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{maPT}");
            response.EnsureSuccessStatusCode();

            return 1;
        }
    }
}
