using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace EngMasterWPF.Services
{

    public class BaseHttpClient
    {
        private readonly HttpClient _httpClient;


        public BaseHttpClient()
        {
            _httpClient = new HttpClient();
        }

        protected async Task<T?> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonResponse);
            }
            return default(T?);
           
        }

        protected async Task<T?> PostAsync<T>(string url, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }

        protected async Task<T?> PutAsync<T>(string url, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }

        protected async Task<bool> DeleteAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
    }

}

