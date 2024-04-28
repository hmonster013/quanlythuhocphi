using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ValueObject.NguoiDung;

namespace DataAccessLayer
{
    public class NGUOIDUNGDAO
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = Constants.BASE_API_URL + "api/nguoidung";

        public NGUOIDUNGDAO()
        {
            _httpClient = HttpManager.GetHttpClient();
        }

        public async Task<List<NGUOIDUNG>> GetData()
        {
            var response = await _httpClient.GetAsync(BASE_URL);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<NGUOIDUNG>>();
        }

        public async Task<NGUOIDUNG> GetDataByID(string tenTaiKhoan)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}/{tenTaiKhoan}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<NGUOIDUNG>();
            }

            return null;
        }

        public async Task<int> Insert(CreateNguoiDungRequestDto obj)
        {
            var response = await _httpClient.PostAsJsonAsync(BASE_URL, obj);
            response.EnsureSuccessStatusCode();
            return 1;
        }

        public async Task<int> Update(string tenTaiKhoan, UpdateNguoiDungRequestDto obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BASE_URL}/{tenTaiKhoan}", obj);
            response.EnsureSuccessStatusCode();
            return 1;
        }

        public async Task<int> Delete(string tenTaiKhoan)
        {
            var response = await _httpClient.DeleteAsync($"{BASE_URL}/{tenTaiKhoan}");
            response.EnsureSuccessStatusCode();
            return 1;
        }
    }
}
