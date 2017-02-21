using Doctors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.IServices
{
    public interface ISysUserInfo
    {
         bool LogIn(string userName,string pwd);
        User GetUserById(string id);

    }
}
