using EngMasterWPF.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Services
{
    class CourseService : BaseHttpClient
    {
        private const string _baseURL = "https://englabapi.onrender.com/api/v1/course/";

        public async Task<ObservableCollection<CourseDTO>?> GetCourseByFilter(string? name,int page, int pageSize)
        {
            var urlRequest = _baseURL + "get-by-filter" + $"?page={page}&pagesize={pageSize}";

            if(!string.IsNullOrEmpty(name))
            {
                urlRequest += $"&name={name}";
            }

            var result = await GetAsync<ObservableCollection<CourseDTO>>(urlRequest);
            return result ?? new ObservableCollection<CourseDTO>();
        }

        public async Task<int> CountAll()
        {
            var urlRequest = _baseURL + "count-all";
            return await GetAsync<int>(urlRequest);
        }


      

        public async Task<AddCourseDTO> AddCourseAsync(AddCourseDTO course)
        {
            try
            {
                var urlRequest = _baseURL + "/create-course";
                var result = await PostAsync<AddCourseDTO>(_baseURL, course);
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

        public async Task<UpdateCourseDTO> UpdateCourseAsync(UpdateCourseDTO course)
        {
            try
            {
                var result = await PutAsync<UpdateCourseDTO>(_baseURL, course);
                if (result == null)
                {
                    throw new Exception("Failed to update the course: the API returned no data.");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update the course.", ex);
            }
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var urlRequest = _baseURL + $"{id}";
            var result = await DeleteAsync(urlRequest);

            return result;
        }
    }
}

