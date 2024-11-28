using EngMasterWPF.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Services
{
    public class GradeService : BaseHttpClient
    {
        private const string _baseURL = "https://englabapi.onrender.com/api/v1/class/";
        public async Task<ObservableCollection<ClassDTO>?> GetGradesByPageAsync(int page, int pageSize)
        {
            var urlRequest = _baseURL + "get-by-filter" + $"?page={page}&pagesize={pageSize}";
            var result = await GetAsync<ObservableCollection<ClassDTO>>(urlRequest);
            return result ?? new ObservableCollection<ClassDTO>();
        }

        public async Task<int> CountAll()
        {
            var urlRequest = _baseURL + "count-all";
            return await GetAsync<int>(urlRequest);
        }

        public async Task<ObservableCollection<ClassDTO>> GetByName(string name)
        {
            var urlRequest = _baseURL + "get-by-name" + $"?name={name}";
            var result = await GetAsync<ObservableCollection<ClassDTO>>(urlRequest);
            return result ?? new ObservableCollection<ClassDTO>();
        }

        public async Task<AddClassDTO> AddClassAsync(AddClassDTO student)
        { 
            try
            {
                var urlRequest = _baseURL + "/create-class";
                var result = await PostAsync<AddClassDTO>(urlRequest, student);
                if (result == null)
                {
                    throw new Exception("Failed to add the class: the API returned no data.");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add the class.", ex);
            }
        }

        public async Task<bool> DeleteClassAsync(int id)
        {
            var urlRequest = _baseURL + $"{id}";
            var result = await DeleteAsync(urlRequest);

            return result;
        }
    }
}
