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
            var urlRequest = _baseURL + "get-by-page" + $"?page={page}&pagesize={pageSize}";
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
    }
}
