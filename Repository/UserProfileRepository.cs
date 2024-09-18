using EngMasterWPF.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Repository
{
    public class UserProfileRepository : BaseRepository<Model.Entities.UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(EngMasterDbContext context) : base(context)
        {
        }
        public IEnumerable<Model.Entities.UserProfile> GetAllStudentsPagination(int page)
        {
            return  _context.UserProfiles.Include(x => x.UserRoles).Where(x => x.UserRoles!.Name == "Student").Skip((page - 1) * 9).Take(9).ToList();
        }
        public int CountStudents()
        {
            return _context.UserProfiles.Include(x => x.UserRoles).Where(x => x.UserRoles!.Name == "Student").Count();
        }
    }
}
