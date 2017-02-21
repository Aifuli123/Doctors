using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doctors.IServices;
using Doctors.Repository;
using Dapper;
using Doctors.Model;
namespace Doctors.Services
{
   public  class SysUserInfo:ISysUserInfo
    {
       
       public  bool LogIn(string userName, string pwd)
        {
            DynamicParameters paras = new DynamicParameters();
            paras.Add("@userName",userName,System.Data.DbType.String);
            paras.Add("@pwd", pwd, System.Data.DbType.String);
           var userone= DapperSqlHelper.ExecuteScalar<object>("select Id,UserName,PassWord,Project from User_Info where UserName=@userName and PassWord=@pwd", paras,false);
            
            return userone==null?false:true;
        }

        public User GetUserById(string id)
        {
            DynamicParameters paras = new DynamicParameters();
            paras.Add("@UserId", id, System.Data.DbType.String);
            User userone = DapperSqlHelper.FindOne<User>("select Id,UserName,PassWord,Project from User_Info where UserId=@UserId", paras, false);

            return userone;
        }
    }
}
