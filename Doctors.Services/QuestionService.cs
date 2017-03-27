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
     public  class QuestionService:IQuestionService
    {
         public int QuestionAdd(QuestionModel question)
         {
            DynamicParameters paras = new DynamicParameters();
            paras.Add("@questionId", question.questionId, System.Data.DbType.String);
            paras.Add("@doctorId", question.doctorId, System.Data.DbType.Int64);
            paras.Add("@questiontopic", question.questiontopic, System.Data.DbType.String);
            paras.Add("@description", question.description, System.Data.DbType.String);
            paras.Add("@Pictures", question.Pictures, System.Data.DbType.String);
            paras.Add("@createtime", question.createtime, System.Data.DbType.DateTime);
            paras.Add("@doctorIDs", question.doctorIDs, System.Data.DbType.String);
            int  count = DapperSqlHelper.ExcuteNonQuery<QuestionModel>("questionAdd",paras, true);
             return count;
         }
    }
}
