using EngMasterWPF.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Services
{
    public class StudentService : BaseHttpClient
    {
        private const string _baseURL = "http://localhost:5110/api/v1/student/";
        public async Task<ObservableCollection<StudentDTO>?> GetStudentsByPageAsync(int page, int pageSize)
        {
            var urlRequest = _baseURL + "get-by-page" + $"?page={page}&pagesize={pageSize}";
            return await GetAsync<ObservableCollection<StudentDTO>>(urlRequest);

        }

        public async Task<int> CountAll()
        {
            var urlRequest = _baseURL + "count-all";
            return await GetAsync<int>(urlRequest);

        }

    }
}
