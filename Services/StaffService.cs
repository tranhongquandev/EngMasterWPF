using EngMasterWPF.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Services
{
    public class StaffService : BaseHttpClient
    {
        private string _baseURL = "https://englabapi.onrender.com/api/v1/staff/";

       public async Task<GetStaffDTO> GetById (int? id)
        {
            var urlRequest = _baseURL + $"get-by-id/{id}";
            var result = await GetAsync<GetStaffDTO>(urlRequest);

            if(result != null)
            {
                return result;
            }

            else
            {
                return new GetStaffDTO();
            }
        }

        public async Task<List<GetAllRoleDTO>> GetAllRole()
        {
            var urlRequest = _baseURL + "get-all-staff-role";
            var result = await GetAsync<List<GetAllRoleDTO>>(urlRequest);

            if (result != null)
            {
                return result;
            }

            else
            {
                return new List<GetAllRoleDTO>();
            }
        }

        public async Task<List<GetStaffDTO>> GetStaffByFilter(string? name, int? page, int? pageSize, int? userId)
        {
            var urlRequest = new StringBuilder(_baseURL + "get-by-filter");

            var queryParams = new List<string>();

            if (userId.HasValue)
            {
                queryParams.Add($"userId={userId.Value}");
            }

            if (!string.IsNullOrEmpty(name))
            {
                queryParams.Add($"name={Uri.EscapeDataString(name)}");
            }

            if (page.HasValue)
            {
                queryParams.Add($"page={page.Value}");
            }

            if (pageSize.HasValue)
            {
                queryParams.Add($"pageSize={pageSize.Value}");
            }

            if (queryParams.Any())
            {
                urlRequest.Append("?" + string.Join("&", queryParams));
            }

            var request = await GetAsync<List<GetStaffDTO>>(urlRequest.ToString());

            return request ?? new List<GetStaffDTO>();
        }



    }
}
