using Dapper;
using Doctors.IServices;
using Doctors.Model;
using Doctors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Services
{
    class DoctorInforService : IDoctorInforService
    {
        public DoctorInfor GetDoctorInfor(string id)
        {
            DynamicParameters paras = new DynamicParameters();
            paras.Add("@UserId", id, System.Data.DbType.String);
            DoctorInfor userone = DapperSqlHelper.FindOne<DoctorInfor>("select * from user_doctor where doctorID=@UserId", paras, false);

            return userone;
        }
    }
}
