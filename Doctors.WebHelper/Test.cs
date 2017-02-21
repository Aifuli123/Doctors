using CRM.WebHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace Doctors.WebHelper
{
    public class Test: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
          var collect=  filterContext.ActionDescriptor.GetCustomAttributes<SkipCheckLoginAttribute>();
            return;
        }
    }
}
