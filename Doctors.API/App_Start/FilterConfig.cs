﻿
using Doctors.API.Filters;
using System.Web;
using System.Web.Mvc;

namespace Doctors.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {

            filters.Add(new HandleErrorAttribute());

           
        }
    }
}
