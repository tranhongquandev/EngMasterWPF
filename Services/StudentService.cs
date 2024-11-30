using EngMasterWPF.DTOs;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<ObservableCollection<StudentDTO>?> GetStudentByFilter(string? name, int page, int pageSize)
        {

            var urlRequest = _baseURL + "get-by-filter?";

            if (!name.IsNullOrEmpty())
            {
                urlRequest += $"name={name}&";
            }
            urlRequest += $"page={page}&pagesize={pageSize}";
            var result = await GetAsync<ObservableCollection<StudentDTO>>(urlRequest);
            return result ?? new ObservableCollection<StudentDTO>();
        }

        public async Task<int> CountAll()
        {
            var urlRequest = _baseURL + "count-all";
            return await GetAsync<int>(urlRequest);
        }



        public async Task<AddStudentDTO> AddStudentAsync(AddStudentDTO student)
        {
            try
            {
                var urlRequest = _baseURL + "create-student";
                var result = await PostAsync<AddStudentDTO>(urlRequest, student);
                if (result == null)
                {
                    throw new Exception("Failed to add the student: the API returned no data.");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add the student.", ex);
            }
        }

        public async Task<UpdateStudentDTO> UpdateStudentAsync(UpdateStudentDTO student, int id)
        {
            try
            {
                var urlRequest = _baseURL + $"{id}";
                var result = await PutAsync<UpdateStudentDTO>(urlRequest, student);
                if (result == null)
                {
                    throw new Exception("Failed to update the student: the API returned no data.");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update the student.", ex);
            }
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var urlRequest = _baseURL + $"{id}";
            var result = await DeleteAsync(urlRequest);

            return result;
        }
    }
}
