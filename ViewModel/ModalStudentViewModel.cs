﻿using AutoMapper;
using EngMasterWPF.DTOs;

using EngMasterWPF.Services;
using EngMasterWPF.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EngMasterWPF.ViewModel
{
    public class ModalStudentViewModel : ViewModelBase
    {
        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged();
            }
        }

        private string studentCode;
        public string StudentCode
        {
            get => studentCode;
            set
            {
                studentCode = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _gender;
        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        private string _dateOfBirth;
        public string DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        private string _enrollmentDate;
        public string EnrollmentDate
        {
            get => _enrollmentDate;
            set
            {
                _enrollmentDate = value;
                OnPropertyChanged();
            }
        }

        private string _status;
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        private bool _isUpdate;

        public bool IsUpdate
        {
            get => _isUpdate;
            set
            {
                _isUpdate = value;
                OnPropertyChanged();
            }
        }

        private bool _isSubmit = false;
        public bool IsSubmit
        {
            get => _isSubmit;
            set
            {
                _isSubmit = value;
                OnPropertyChanged();
            }
        }

        private readonly StudentService _studentService;
        public ICommand AddStudentCommand { get; set; }

        private readonly IServiceProvider _service;

        private readonly IMapper _mapper;

        public ModalStudentViewModel()

        {
            _service = Installer.InstallServices.Instance.serviceProvider;

            _mapper = _service.GetRequiredService<IMapper>();

            AddStudentCommand = new RelayCommand(_canExecute => true, async _execute => await AddStudentAsync());
        }

        private string NormalizeDateOfBirth(string dateOfBirth)
        {
            if (DateTime.TryParse(dateOfBirth, out DateTime dob))
            {
                return dob.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            }

            return new DateTime(2000, 1, 1).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        }

        public void ResetForm()
        {
            FullName = string.Empty;
            Gender = string.Empty;
            DateOfBirth = null;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            StudentCode = string.Empty;
            EnrollmentDate = null;
            Status = string.Empty;
        }
        private async Task AddStudentAsync()
        {
            IsSubmit = true;
            var newStudent = new AddStudentDTO
            {
                FullName = FullName ?? string.Empty,
                Gender = Gender ?? string.Empty,
                Email = Email ?? string.Empty,
                PhoneNumber = PhoneNumber ?? string.Empty,
                DateOfBirth = NormalizeDateOfBirth(DateOfBirth),
                StudentCode = StudentCode ?? string.Empty,
                EnrollmentDate = NormalizeDateOfBirth(EnrollmentDate),
                Status = Status ?? string.Empty,
            };

            if (IsUpdate)
            {

                MessageBox.Show("Updating student...");

            }

            string jsonCourse = JsonConvert.SerializeObject(newStudent);
            try
            {

                StudentService studentService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<StudentService>();
                var result = await studentService.AddStudentAsync(newStudent);

                MessageBox.Show("Student added successfully.");
                ResetForm();
                IsSubmit = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong. Error: {ex.Message}\nStackTrace: {jsonCourse}");
                IsSubmit = false;
                return;
            }
        }
    }
}
