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
using ValueObject.DangKy;

namespace DataAccessLayer
{
    public class DANGKYDAO
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = Constants.BASE_API_URL + "api/dangky";

        public DANGKYDAO()
        {
            _httpClient = HttpManager.GetHttpClient();
        }

        public async Task<List<DANGKY>> GetData()
        {
            var response = await _httpClient.GetAsync(BASE_URL);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<DANGKY>>();
        }

        public async Task<DANGKY> GetDataByID(int maDK)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/{maDK}");
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<DANGKY>();
            }

            return null;
        }

        public async Task<List<DANGKY>> GetDataByMASV(string MASV)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/sinhvien/{MASV}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<DANGKY>>();
        }

        public async Task<DANGKY> GetDataByMASVandHOCKY(string MASV, int HOCKY)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/sinhvien/{MASV}/{HOCKY}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<DANGKY>();
            }

            return null;
        }

        public async Task<int> Insert(CreateDangKyRequestDto obj)
        {
            var response = await _httpClient.PostAsJsonAsync(BASE_URL, obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Update(int maDK, UpdateDangKyRequestDto obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{maDK}", obj);
            response.EnsureSuccessStatusCode();

            return 1;
        }

        public async Task<int> Delete(int maDK)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{maDK}");
            response.EnsureSuccessStatusCode();

            return 1;
        }
    }
}

