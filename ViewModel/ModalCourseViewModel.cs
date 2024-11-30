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

        private double _discount;
        public double Discount
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

        private bool _isActive = false;
        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
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

        public void ResetForm()
        {
            CourseName = string.Empty;
            Duration = string.Empty;
            Fee = 0;
            Discount = 0;
            Description = string.Empty;
            //TotalFee = Fee - Discount * Fee, 
            IsActive = true;
            //LevelId = 22;
            CourseCode = string.Empty;
        }


        private async Task AddCourseAsync()
        {
            IsSubmit = true;
            var newCourse = new AddCourseDTO
            {
                CourseName = CourseName ?? string.Empty,  
                Duration = Duration, 
                Fee = Fee > 0 ? Fee : 0, 
                Discount = Discount, 
                Description = Description ?? string.Empty,  
                //TotalFee = Fee - Discount * Fee, 
                IsActive = true,
                LevelId = 22,
                CourseCode = CourseCode ?? string.Empty
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

                MessageBox.Show( "Course added successfully.");
                ResetForm();
                IsSubmit = false;

            }
            catch(Exception ex)
            {
                MessageBox.Show($"Something went wrong. Error: {ex.Message}\nStackTrace: {jsonCourse}");
                IsSubmit = false;
                return;
            }
        }
    }
}
