using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Repository
{
    public interface IUserProfileRepository : IBaseRepository<Model.Entities.UserProfile>
    {
         IQueryable<Model.Entities.UserProfile> GetAllStudentsPagination(int page);
        IQueryable<Model.Entities.UserProfile> GetAllStudents();

    }
}
