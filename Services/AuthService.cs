using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EngMasterWPF.Services
{
    public class AuthService
    {

        private readonly HttpClient _httpClient;


        public AuthService()
        {
            var handler = new HttpClientHandler
            {
                UseCookies = true
            };

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://englabapi.onrender.com/api/v1/auth/") 
            };

           
        }

        public async Task<object> LoginAsync(string email, string password)
        {
            var payload = new { Email = email, Password = password };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

          
            var response = await _httpClient.PostAsync("login", content);

            if (response.IsSuccessStatusCode)
            {
               
                var responseContent = await response.Content.ReadFromJsonAsync<LoginResponse>();
                if (responseContent != null)
                {
                    return new { status = 200,  responseContent.userId };
                }
            }

            return new { status = 400, message = "Email hoặc mật khẩu không đúng" };
        }

        public async Task<bool> LogoutAsync()
        {
            var result = await _httpClient.PostAsync("logout", null);

            if (result.IsSuccessStatusCode) {
                return true;
            };

            return false;

           
        }





    }
}

public class LoginResponse
{
    public int userId { get; set; }
    
}
