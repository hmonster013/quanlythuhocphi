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
using ValueObject.GiangVien;

namespace DataAccessLayer
{
    public class GIANGVIENDAO
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = Constants.BASE_API_URL + "api/giangvien";

        public GIANGVIENDAO()
        {
            _httpClient = HttpManager.GetHttpClient();
        }

        public async Task<List<GIANGVIEN>> GetData()
        {
            var response = await _httpClient.GetAsync(BASE_URL);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<GIANGVIEN>>();
        }

        public async Task<GIANGVIEN> GetDataByID(string maGV)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/{maGV}");
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<GIANGVIEN>();
            }

            return null;
        }

        public async Task<int> Insert(CreateGiangVienRequestDto obj)
        {
            var response = await _httpClient.PostAsJsonAsync(BASE_URL, obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Update(string maGV, UpdateGiangVienRequestDto obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{maGV}", obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Delete(string maGV)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{maGV}");
            response.EnsureSuccessStatusCode();

            return 1;
        }
    }
}
