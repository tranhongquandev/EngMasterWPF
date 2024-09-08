using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngMasterWPF.Model.Entities
{
    public class UserClass
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int UserAccountId { get; set; }

        public Class? Class { get; set; }
        public UserAccounts? UserAccounts { get; set; }
    }
}
