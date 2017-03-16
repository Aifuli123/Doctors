using Doctors.Common;
using Doctors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Doctors.API.Controllers.BaseContolles
{
    public class BaseApiController: EncryptBaseController
    {
       
    }

    public  class UserObj
    {
       public  DoctorInfor doctorInfor { get; set; }

        [ThreadStatic]
        [NonSerialized]
        private static UserObj currentUserObj;
        public static UserObj CurrentUser
        {
            get
            {
                var token = HttpContext.Current.Request["token"] as string;
                if (!string.IsNullOrWhiteSpace(token))
                {

                    currentUserObj.doctorInfor = CacheMgr.GetData<DoctorInfor>(token);
                    return currentUserObj;
                }
                else
                {
                    return currentUserObj;
                }
            }
            set
            {
               currentUserObj = value;
            }
        }
    }
}
