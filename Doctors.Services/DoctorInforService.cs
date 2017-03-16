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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pwd"></param>
        /// <param name="type">1:用户名登陆 , 2:手机号登陆 ， 3：账户登陆 </param>
        /// <returns></returns>
        public  DoctorInfor GetDoctorInfor(string userId, string pwd,int type)
        {
            StringBuilder strsql = new StringBuilder("select * from user_doctor where ");
            DynamicParameters paras = new DynamicParameters();
            switch (type)
            {
                case 1:
                    paras.Add("@userName", userId, System.Data.DbType.String);
                    paras.Add("@pwd", pwd, System.Data.DbType.String);
                    strsql.Append("doctorID=@userName and password=@pwd");
                    break;
                case 2:
                    paras.Add("@mobilephone", userId, System.Data.DbType.String);
                    paras.Add("@pwd", pwd, System.Data.DbType.String);
                    strsql.Append("mobilephone=@mobilephone and password=@pwd");
                    break;
                case 3:
                    paras.Add("@accountID", userId, System.Data.DbType.Int64);
                    paras.Add("@pwd", pwd, System.Data.DbType.String);
                    strsql.Append("accountID=@accountID and password=@pwd");             
                    break;
                default:
                    paras.Add("@userName", userId, System.Data.DbType.String);
                    paras.Add("@pwd", pwd, System.Data.DbType.String);
                    strsql.Append("doctorID=@userName and password=@pwd");
                    break;
            }
           

          
            DoctorInfor userone = DapperSqlHelper.FindOne<DoctorInfor>(strsql.ToString(), paras, false);

            return userone;
        }
    }
}
