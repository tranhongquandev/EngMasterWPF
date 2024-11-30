using AutoMapper;
using EngMasterWPF.DTOs;
using EngMasterWPF.Services;
using EngMasterWPF.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EngMasterWPF.ViewModel
{
    public class ModalTeacherViewModel : ViewModelBase
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

        private string _imageUrl;
        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                _imageUrl = value;
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

        private string _address;
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
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


        private string _teacherCode;
        public string TeacherCode
        {
            get => _teacherCode;
            set
            {
                _teacherCode = value;
                OnPropertyChanged();
            }
        }

        private string _hireDate;
        public string HireDate
        {
            get => _hireDate;
            set
            {
                _hireDate = value;
                OnPropertyChanged();
            }
        }

        private string _endDate;
        public string EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged();
            }
        }

        private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
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

        private readonly TeacherService _teacherService;
        public ICommand AddTeacherCommand { get; set; }

        private readonly IServiceProvider _service;

        private readonly IMapper _mapper;

        public ModalTeacherViewModel()

        {
            _service = Installer.InstallServices.Instance.serviceProvider;

            _mapper = _service.GetRequiredService<IMapper>();

            AddTeacherCommand = new RelayCommand(_canExecute => true, async _execute => await AddTeacherAsync());
        }

        private string NormalizeDateOfBirth(string dateOfBirth)
        {
            if (DateTime.TryParse(dateOfBirth, out DateTime dob))
            {
                return dob.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            }

            return new DateTime(2000, 1, 1).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        }

        private async Task AddTeacherAsync()
        {
            IsSubmit = true;
            var newTeacher = new AddTeacherDTO
            {
                FullName = FullName ?? string.Empty,
                Gender = Gender ?? string.Empty,
                Email = Email ?? string.Empty,
                PhoneNumber = PhoneNumber ?? string.Empty,
                DateOfBirth = NormalizeDateOfBirth(DateOfBirth),
                HireDate = NormalizeDateOfBirth(HireDate),
                EndDate = NormalizeDateOfBirth(EndDate),
                IsActive = IsActive,
                TeacherCode = TeacherCode,
                Address = Address
            };

            if (IsUpdate)
            {

                MessageBox.Show("Updating teacher...");

            }

            string jsonCourse = JsonConvert.SerializeObject(newTeacher);
            try
            {

                TeacherService teacherService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<TeacherService>();
                var result = await teacherService.AddTeacherAsync(newTeacher);

                MessageBox.Show("Teacher added successfully.");
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
