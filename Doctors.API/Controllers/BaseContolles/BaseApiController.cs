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

    public class UserObj: DoctorInfor
    {
        [ThreadStatic]
        [NonSerialized]
        private static UserObj currentUserObj;
        public static UserObj CurrentUser
        {
            get
            {
                var accountID = HttpContext.Current.Items["accountID"] as string;
                if (!string.IsNullOrWhiteSpace(accountID))
                {

                    var user = (UserObj)CacheMgr.GetData<DoctorInfor>(accountID);
                    return user;
                }
                else
                {
                    return currentUserObj;
                }
            }
            set
            {
                if (HttpContext.Current != null)
                    HttpContext.Current.Items["userobj"] = value;
                else
                {
                    currentUserObj = value;
                }
            }
        }
    }
}
