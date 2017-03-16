using Doctors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.IServices
{
    public interface IDoctorInforService
    {
        DoctorInfor GetDoctorInfor(string id);
        DoctorInfor GetDoctorInfor(string userName,string pwd, int type);
    }
}
