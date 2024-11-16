using EngMasterWPF.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Services
{
    class TeacherService : BaseHttpClient
    {
        private const string _baseURL = "https://englabapi.onrender.com/api/v1/teacher/";

        public async Task<ObservableCollection<TeacherDTO>?> GetTeachersByPageAsync(int page, int pageSize)
        {
            var urlRequest = _baseURL + "get-by-page" + $"?page={page}&pagesize={pageSize}";
            var result = await GetAsync<ObservableCollection<TeacherDTO>>(urlRequest);
            return result ?? new ObservableCollection<TeacherDTO>();
        }

        public async Task<int> CountAll()
        {
            var urlRequest = _baseURL + "count-all";
            return await GetAsync<int>(urlRequest);
        }


        public async Task<ObservableCollection<TeacherDTO>> GetByName(string name)
        {
            var urlRequest = _baseURL + "get-by-name" + $"?name={name}";
            var result = await GetAsync<ObservableCollection<TeacherDTO>>(urlRequest);
            return result ?? new ObservableCollection<TeacherDTO>();
        }

        public async Task<bool> AddTeacherAsync(TeacherDTO teacher)
        {
            try
            {
                var result = await PostAsync<bool>(_baseURL, teacher);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding teacher: {ex.Message}");
                return false;
            }
        }
    }
}

