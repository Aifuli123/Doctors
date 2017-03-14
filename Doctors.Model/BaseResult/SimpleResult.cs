using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Model.BaseResult
{
    public class SimpleResult
    {

       

        public Result Status { get; set; }
        /// <summary>
        /// 消息
        /// </summary>

        public string Msg { get; set; }
        public object Resource { get; set; }



    }
    public enum Result
    {
        succeed = 1,
        failure = 2
    }
}
