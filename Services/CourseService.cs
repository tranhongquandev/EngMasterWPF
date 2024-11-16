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
    class CourseService : BaseHttpClient
    {
        private const string _baseURL = "https://englabapi.onrender.com/api/v1/course/";

        public async Task<ObservableCollection<CourseDTO>?> GetCoursesByPageAsync(int page, int pageSize)
        {
            var urlRequest = _baseURL + "get-by-page" + $"?page={page}&pagesize={pageSize}";
            var result = await GetAsync<ObservableCollection<CourseDTO>>(urlRequest);
            return result ?? new ObservableCollection<CourseDTO>();
        }

        public async Task<int> CountAll()
        {
            var urlRequest = _baseURL + "count-all";
            return await GetAsync<int>(urlRequest);
        }


        public async Task<ObservableCollection<CourseDTO>> GetByName(string name)
        {
            var urlRequest = _baseURL + "get-by-name" + $"?name={name}";
            var result = await GetAsync<ObservableCollection<CourseDTO>>(urlRequest);
            return result ?? new ObservableCollection<CourseDTO>();
        }

        public async Task<bool> AddCourseAsync(CourseDTO course)
        {
            var result = await PostAsync<bool>(_baseURL, course);

            return result;
        }
    }
}

