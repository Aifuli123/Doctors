using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Doctors.IServices;
using Doctors.Model;
using Doctors.Repository;

namespace Doctors.Services
{
    internal class CirclesInfoService : ICirclesInfoService
    {
        public IList<CirclesInfoModel> GetCirclesInfo(int pageIndex, int pageSize, string city, string dep)
        {
            StringBuilder strsql =
                new StringBuilder(
                    "select top (@pageSize) circleID,a.doctorID as userId,imageUrl,circlecontent as contentText,createtime,commentCount,praiseCount from circle as a " +
                    "left join user_doctor as b on b.doctorID = a.doctorID " +
                    "left join wzyx_hospital_info h on h.hospitalid = b.hospitalid " +
                    "left join wzyx_department_info dep on dep.departmentid = b.departmentid " +
                    "where circleID not in(select top (@pageSize*(@pageIndex-1))  circleID from circle c " +
                    "left join user_doctor as d on d.doctorID=c.doctorID " +
                    "left join wzyx_hospital_info h on h.hospitalid=b.hospitalid " +
                    "left join wzyx_department_info dep on dep.departmentid=b.departmentid  where 1=1");
            DynamicParameters paras = new DynamicParameters();
            paras.Add("@pageIndex", pageIndex, System.Data.DbType.Int32);
            paras.Add("@pageSize", pageSize, System.Data.DbType.Int32);
            if (city != null)
            {

                paras.Add("@city", city, System.Data.DbType.String);
                strsql.Append(" and h.city =@city  ");
            }
            if (dep != null)
            {

                paras.Add("@dep", dep, System.Data.DbType.String);
                strsql.Append(" and dep.department_name =@dep  ");
            }
            strsql.Append(" order by circleID) ");
            if (city != null)
            {

                paras.Add("@city1", city, System.Data.DbType.String);
                strsql.Append(" and h.city =@city1  ");
            }
            if (dep != null)
            {
                paras.Add("@dep1", dep, System.Data.DbType.String);

                strsql.Append(" and dep.department_name =@dep1  ");
            }
            strsql.Append(" order by circleID");



            IList<CirclesInfoModel> circleslist = DapperSqlHelper.FindToList<CirclesInfoModel>(strsql.ToString(), paras, false);
            return circleslist;
        }

        public IList<CirclecommentModel> GetCommentsInfo(string circleId)
        {
 
            DynamicParameters paras = new DynamicParameters();
            paras.Add("@circleId", circleId, System.Data.DbType.String);
            IList <CirclecommentModel> circlecommentlist = DapperSqlHelper.FindToList<CirclecommentModel>("commentContentInfo".ToString(), paras, true);
            return circlecommentlist;
        }
    }
}
