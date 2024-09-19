using EngMasterWPF.Model.Context;
using EngMasterWPF.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(EngMasterDbContext context) : base(context)
        {
        }

        public IQueryable<Student> GetStudentsByPage(int page, int pageSize)
        {
            return _context.Student.Skip((page - 1) * pageSize).Take(pageSize).AsQueryable();  
        }
    }
}
