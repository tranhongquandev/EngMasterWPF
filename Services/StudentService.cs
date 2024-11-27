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
        private const string _baseURL = "https://englabapi.onrender.com/api/v1/student/";
        public async Task<ObservableCollection<StudentDTO>?> GetStudentsByPageAsync(int page, int pageSize)
        {
            var urlRequest = _baseURL + "get-by-filter" + $"?page={page}&pagesize={pageSize}";
            var result = await GetAsync<ObservableCollection<StudentDTO>>(urlRequest);
            return result ?? new ObservableCollection<StudentDTO>();
        }

        public async Task<int> CountAll()
        {
            var urlRequest = _baseURL + "count-all";
            return await GetAsync<int>(urlRequest);
        }

        public async Task<ObservableCollection<StudentDTO>> GetByName(string name)
        {
            var urlRequest = _baseURL + "get-by-name" + $"?name={name}";
            var result = await GetAsync<ObservableCollection<StudentDTO>>(urlRequest);
            return result ?? new ObservableCollection<StudentDTO>();
        }

        public async Task<AddStudentDTO> AddStudentAsync(AddStudentDTO course)
        {
            try
            {
                var result = await PostAsync<AddStudentDTO>(_baseURL, course);
                if (result == null)
                {
                    throw new Exception("Failed to add the course: the API returned no data.");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add the course.", ex);
            }
        }
    }
}
