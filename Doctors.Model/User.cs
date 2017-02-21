using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Model
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Project { get; set; }
    }
}
