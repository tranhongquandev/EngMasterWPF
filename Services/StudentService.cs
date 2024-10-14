﻿using EngMasterWPF.DTOs;
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
    }
}
