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

       public async Task<StaffDTO> GetById (int? id)
        {
            var urlRequest = _baseURL + $"get-by-id/{id}";
            var result = await GetAsync<StaffDTO>(urlRequest);

            if(result != null)
            {
                return result;
            }

            else
            {
                return new StaffDTO();
            }
        }
    }
}
