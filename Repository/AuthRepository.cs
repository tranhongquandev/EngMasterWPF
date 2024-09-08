using EngMasterWPF.Model.Context;
using EngMasterWPF.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Repository
{
    public class AuthRepository : BaseRepository<UserAccounts>, IAuthRepository
    {
        public AuthRepository(EngMasterDbContext context) : base(context)
        {
        }
    }
}
