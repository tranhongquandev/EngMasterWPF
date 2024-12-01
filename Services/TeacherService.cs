using EngMasterWPF.DTOs;
using Microsoft.IdentityModel.Tokens;
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

        public async Task<ObservableCollection<TeacherDTO>?> GetTeacherByFilter(string? name, int page, int pageSize)
        {

            var urlRequest = _baseURL + "get-by-filter" + $"?page={page}&pagesize={pageSize}";


            if (!name.IsNullOrEmpty())
            {
                urlRequest += $"&name={name}";
            }


            var result = await GetAsync<ObservableCollection<TeacherDTO>>(urlRequest);
            return result ?? new ObservableCollection<TeacherDTO>();
        }

        public async Task<int> CountAll()
        {
            var urlRequest = _baseURL + "count-all";
            return await GetAsync<int>(urlRequest);
        }




        public async Task<AddTeacherDTO> AddTeacherAsync(AddTeacherDTO student)
        {
            try
            {
                var urlRequest = _baseURL + "create-teacher";
                var result = await PostAsync<AddTeacherDTO>(urlRequest, student);
                if (result == null)
                {
                    throw new Exception("Failed to add the teacher: the API returned no data.");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add the teacher.", ex);
            }
        }

        public async Task<UpdateTeacherDTO> UpdateTeacherAsync(UpdateTeacherDTO teacher, int id)
        {
            try
            {
                var urlRequest = _baseURL + $"{id}";
                var result = await PatchAsync<UpdateTeacherDTO>(urlRequest, teacher);

                if (result == null)
                {
                    throw new Exception("Failed to update the teacher: the API returned no data.");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update the teacher.", ex);
            }
        }

        public async Task<bool> DeleteTeacherAsync(int id)
        {
            var urlRequest = _baseURL + $"{id}";
            var result = await DeleteAsync(urlRequest);

            return result;
        }
    }
}

