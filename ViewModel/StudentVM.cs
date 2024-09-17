using AutoMapper;
using EngMasterWPF.DTOs;
using EngMasterWPF.Repository;
using EngMasterWPF.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.ViewModel
{
    public class StudentVM : BaseViewModel
    {
        private bool _isSelected = false;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMapper _mapper;

        private IEnumerable<StudentDTO> _students;

        public int Count { get; set; }

        

        public IEnumerable<StudentDTO> Students
        {
            get { return _students; }
            set
            {
                _students = value;
            }
        }

        public StudentVM()
        {
            IServiceProvider _services = Installer.InstallServices.Instance.serviceProvider;
            _userProfileRepository = _services.GetRequiredService<IUserProfileRepository>();
            _mapper = _services.GetRequiredService<IMapper>();
            _students = _mapper.Map<IEnumerable<StudentDTO>?>(_userProfileRepository.GetAllStudentsPagination(1))!;
            Count = _userProfileRepository.GetAllStudents().Count();
        }


    }





}

