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
        public async Task<ObservableCollection<ClassDTO>?> GetGradeByFilter(string? name, int page, int pageSize)
        {
            var urlRequest = _baseURL + "get-by-filter" + $"?page={page}&pagesize={pageSize}";

            if (!string.IsNullOrEmpty(name))
            {
                urlRequest += $"&name={name}";
            }


            var result = await GetAsync<ObservableCollection<ClassDTO>>(urlRequest);
            return result ?? new ObservableCollection<ClassDTO>();
        }

        public async Task<int> CountAll()
        {
            var urlRequest = _baseURL + "count-all";
            return await GetAsync<int>(urlRequest);
        }



        public async Task<bool> AddClassAsync(AddClassDTO classDTO)
        {

            var urlRequest = _baseURL + "create-class";
            var result = await PostAsync<AddClassDTO>(urlRequest, classDTO);

            if (!result) return false;
            return true;

        }

        public async Task<bool> DeleteClassAsync(int id)
        {
            var urlRequest = _baseURL + $"{id}";
            var result = await DeleteAsync(urlRequest);

            return result;
        }

        public async Task <ClassDTO> GetById(int? id)
        {
            var urlRequest = _baseURL + $"get-by-id/{id}";

            return await GetAsync<ClassDTO>(urlRequest);

        }


        public async Task<ObservableCollection<StudentDTO>> GetStudentByClassId(int? id)
        {
            var urlRequest = _baseURL + $"get-student-by-class-id/{id}";

            return await GetAsync<ObservableCollection<StudentDTO>>(urlRequest);

        }
    }
}
