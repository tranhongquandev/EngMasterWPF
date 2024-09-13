using EngMasterWPF.DTOs;
using EngMasterWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.ViewModel
{
    public class StudentVM : BaseViewModel
    {
        public StudentVM()
        {
            Students = new List<StudentDTO>();
            Students.Add(new StudentDTO
            {
                Id = 1,
                Name = "Nguyen Van A",
                BirtDay = new DateTime(1999, 1, 1),
                Sex = "Nam",
                Address = "Ha Noi",
                Email = "engmaster@gmail.com",
                Phone = "0123456789",
                StartAt = new DateTime(DateTime.UtcNow.Day),
                EndAt = new DateTime(DateTime.UtcNow.Day),
                Status = "Active"
            });
            Students.Add(new StudentDTO
            {
                Id = 1,
                Name = "Nguyen Van A",
                BirtDay = new DateTime(1999, 1, 1),
                Sex = "Nam",
                Address = "Ha Noi",
                Email = "engmaster@gmail.com",
                Phone = "0123456789",
                StartAt = new DateTime(DateTime.UtcNow.Day),
                EndAt = new DateTime(DateTime.UtcNow.Day),
                Status = "Active"
            });
            Students.Add(new StudentDTO
            {
                Id = 1,
                Name = "Nguyen Van A",
                BirtDay = new DateTime(1999, 1, 1),
                Sex = "Nam",
                Address = "Ha Noi",
                Email = "engmaster@gmail.com",
                Phone = "0123456789",
                StartAt = new DateTime(DateTime.UtcNow.Day),
                EndAt = new DateTime(DateTime.UtcNow.Day),
                Status = "Active"
            });
            Students.Add(new StudentDTO
            {
                Id = 1,
                Name = "Nguyen Van A",
                BirtDay = new DateTime(1999, 1, 1),
                Sex = "Nam",
                Address = "Ha Noi",
                Email = "engmaster@gmail.com",
                Phone = "0123456789",
                StartAt = new DateTime(DateTime.UtcNow.Day),
                EndAt = new DateTime(DateTime.UtcNow.Day),
                Status = "Active"
            });
            Students.Add(new StudentDTO
            {
                Id = 1,
                Name = "Nguyen Van A",
                BirtDay = new DateTime(1999, 1, 1),
                Sex = "Nam",
                Address = "Ha Noi",
                Email = "engmaster@gmail.com",
                Phone = "0123456789",
                StartAt = new DateTime(DateTime.UtcNow.Day),
                EndAt = new DateTime(DateTime.UtcNow.Day),
                Status = "Active"
            });
            Students.Add(new StudentDTO
            {
                Id = 1,
                Name = "Nguyen Van A",
                BirtDay = new DateTime(1999, 1, 1),
                Sex = "Nam",
                Address = "Ha Noi",
                Email = "engmaster@gmail.com",
                Phone = "0123456789",
                StartAt = new DateTime(DateTime.UtcNow.Day),
                EndAt = new DateTime(DateTime.UtcNow.Day),
                Status = "Active"
            });
            Students.Add(new StudentDTO
            {
                Id = 1,
                Name = "Nguyen Van A",
                BirtDay = new DateTime(1999, 1, 1),
                Sex = "Nam",
                Address = "Ha Noi",
                Email = "engmaster@gmail.com",
                Phone = "0123456789",
                StartAt = new DateTime(DateTime.UtcNow.Day),
                EndAt = new DateTime(DateTime.UtcNow.Day),
                Status = "Active"
            });
            Students.Add(new StudentDTO
            {
                Id = 1,
                Name = "Nguyen Van A",
                BirtDay = new DateTime(1999, 1, 1),
                Sex = "Nam",
                Address = "Ha Noi",
                Email = "engmaster@gmail.com",
                Phone = "0123456789",
                StartAt = new DateTime(DateTime.UtcNow.Day),
                EndAt = new DateTime(DateTime.UtcNow.Day),
                Status = "Active"
            });
            Students.Add(new StudentDTO
            {
                Id = 1,
                Name = "Nguyen Van A",
                BirtDay = new DateTime(1999, 1, 1),
                Sex = "Nam",
                Address = "Ha Noi",
                Email = "engmaster@gmail.com",
                Phone = "0123456789",
                StartAt = new DateTime(DateTime.UtcNow.Day),
                EndAt = new DateTime(DateTime.UtcNow.Day),
                Status = "Active"
            });
            Students.Add(new StudentDTO
            {
                Id = 1,
                Name = "Nguyen Van A",
                BirtDay = new DateTime(1999, 1, 1),
                Sex = "Nam",
                Address = "Ha Noi",
                Email = "engmaster@gmail.com",
                Phone = "0123456789",
                StartAt = new DateTime(DateTime.UtcNow.Day),
                EndAt = new DateTime(DateTime.UtcNow.Day),
                Status = "Active"
            });
        }
        public List<StudentDTO> Students { get; set; }
    }





}

