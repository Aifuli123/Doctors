using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Model.BaseResult
{
    public class BaseResult
    {
       public Result Result { get; set; }
       public  string Message { get; set; }
    }
    public enum Result
    {
        succeed = 1,
        failure=2
    }
}
