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
using ValueObject.SinhVien;

namespace DataAccessLayer
{
    public class SINHVIENDAO
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = Constants.BASE_API_URL + "api/sinhvien";

        public SINHVIENDAO()
        {
            _httpClient = HttpManager.GetHttpClient();
        }

        public async Task<List<SINHVIEN>> GetData()
        {
            var response = await _httpClient.GetAsync(BASE_URL);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<SINHVIEN>>();
        }

        public async Task<SINHVIEN> GetDataByID(string maSV)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/{maSV}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<SINHVIEN>();
            }

            return null;
        }

        public async Task<int> Insert(CreateSinhVienRequestDto obj)
        {
            var response = await _httpClient.PostAsJsonAsync(BASE_URL, obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Update(string maSV, UpdateSinhVienRequestDto obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{maSV}", obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Delete(string maSV)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{maSV}");
            response.EnsureSuccessStatusCode();

            return 1;
        }
    }
}
