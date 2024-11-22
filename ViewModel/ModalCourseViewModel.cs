using AutoMapper;
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
    public class ModalCourseViewModel : ViewModelBase
    {
        private string _courseName;
        public string CourseName
        {
            get => _courseName;
            set
            {
                _courseName = value;
                OnPropertyChanged();
            }
        }

        private string _courseCode;
        public string CourseCode
        {
            get => _courseCode;
            set
            {
                _courseCode = value;
                OnPropertyChanged();
            }
        }

        private string _duration;
        public string Duration
        {
            get => _duration;
            set
            {
                _duration = value;
                OnPropertyChanged();
            }
        }

        private int _fee;
        public int Fee
        {
            get => _fee;
            set
            {
                _fee = value;
                OnPropertyChanged();
            }
        }

        private decimal _discount;
        public decimal Discount
        {
            get => _discount;
            set
            {
                _discount = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
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

        private readonly TeacherService _teacherService;
        public ICommand AddCourseCommand { get; set; }

        private readonly IServiceProvider _service;

        private readonly IMapper _mapper;

        public ModalCourseViewModel()

        {
            _service = Installer.InstallServices.Instance.serviceProvider;

            _mapper = _service.GetRequiredService<IMapper>();
    
            AddCourseCommand = new RelayCommand(_canExecute => true, async _execute => await AddCourseAsync());
        }


        private async Task AddCourseAsync()
        {

            var newCourse = new AddCourseDTO
            {
                CourseName = CourseName ?? string.Empty,  
                //CourseCode = CourseCode ?? string.Empty, 
                Duration = Duration, 
                Fee = Fee > 0 ? Fee : 0, 
                Discount = 0, 
                Description = Description ?? string.Empty,  
                TotalFee = 0, 
                IsActive = true,
                LevelId = 22,
            };

            if (IsUpdate)
            {
              
                MessageBox.Show("Updating course...");
         
            }

            string jsonCourse = JsonConvert.SerializeObject(newCourse);
            try
            {
               
                CourseService courseService = Installer.InstallServices.Instance.serviceProvider.GetRequiredService<CourseService>();
                var result  = await courseService.AddCourseAsync(newCourse);

                MessageBox.Show(result ? "Course added successfully." : "Failed to add course.");

            }
            catch(Exception ex)
            {
                MessageBox.Show($"Something went wrong. Error: {ex.Message}\nStackTrace: {jsonCourse}");
                return;
            }
        }
    }
}
