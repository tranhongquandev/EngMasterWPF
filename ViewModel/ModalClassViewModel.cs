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
    public class ModalClassViewModel : ViewModelBase
    {
        private string _className;
        public string ClassName
        {
            get => _className;
            set
            {
                _className = value;
                OnPropertyChanged();
            }
        }

        private string _startDate;
        public string StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }

        private string _endDate;
        public string EndDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }


        private int _courseId;
        public int CourseId
        {
            get => _courseId;
            set
            {
                _courseId = value;
                OnPropertyChanged();
            }
        }

        private int _teacherId;
        public int TeacherId
        {
            get => _teacherId;
            set
            {
                _teacherId = value;
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

        private readonly GradeService _gradeService;
        public ICommand AddClassCommand { get; set; }

        private readonly IServiceProvider _service;

        private readonly IMapper _mapper;

        public ModalClassViewModel()

        {
            _service = Installer.InstallServices.Instance.serviceProvider;

            _mapper = _service.GetRequiredService<IMapper>();

            AddClassCommand = new RelayCommand(_canExecute => true, async _execute => await AddTeacherAsync());
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
            var newClass = new AddClassDTO
            {
                ClassName = ClassName ?? string.Empty,
                StartDate = StartDate ?? string.Empty,
                EndDate = EndDate ?? string.Empty,
                CourseId = CourseId,
                TeacherId = TeacherId,
                //HireDate = NormalizeDateOfBirth(DateOfBirth),
                //EndDate = NormalizeDateOfBirth(DateOfBirth),
            };

            if (IsUpdate)
            {

                MessageBox.Show("Updating class...");

            }

            string jsonCourse = JsonConvert.SerializeObject(newClass);
            try
            {

                GradeService gradeService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<GradeService>();
                var result = await gradeService.AddClassAsync(newClass);

                MessageBox.Show("Class added successfully.");
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
