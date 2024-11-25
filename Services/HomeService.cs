using EngMasterWPF.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Services
{
    public class HomeService : BaseHttpClient
    {
        private const string _baseURL = "https://englabapi.onrender.com/api/v1/";


        public async Task<int> CountAllCourse()
        {
            var urlRequest = _baseURL + "course/count-all";
            return await GetAsync<int>(urlRequest);
        }

        public async Task<int> CountAllStudent()
        {
            var urlRequest = _baseURL + "student/count-all";
            return await GetAsync<int>(urlRequest);
        }

        public async Task<int> CountAllTeacher()
        {
            var urlRequest = _baseURL + "teacher/count-all";
            return await GetAsync<int>(urlRequest);
        }

        public async Task<int> CountAllClass()
        {
            var urlRequest = _baseURL + "class/count-all";
            return await GetAsync<int>(urlRequest);
        }

        public async Task<ObservableCollection<CourseDTO>?> GetCourseByLimit(int page)
        {
            var urlRequest = _baseURL + "course/get-by-page" + $"?page={page}&pagesize={4}";
            var result = await GetAsync<ObservableCollection<CourseDTO>>(urlRequest);
            return result ?? new ObservableCollection<CourseDTO>();
        }
    }
}
