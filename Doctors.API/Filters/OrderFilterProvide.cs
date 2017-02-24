using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Doctors.API.Filters
{
    public interface IOrderFilter
    {
        int Order { get; }
    }
    public class ActionOrderFilterProvider : IFilterProvider
    {
        /// <summary>
        /// 返回与此操作方法关联的筛选器。
        /// </summary>
        /// 
        /// <returns>
        /// 与此操作方法关联的筛选器。
        /// </returns>
        /// <param name="configuration">配置。</param><param name="actionDescriptor">操作描述符。</param>
        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)

        {

            var controllerInfos =
                actionDescriptor.ControllerDescriptor.GetFilters()
                    .Select(i => new FilterInfo(i, FilterScope.Controller));

            var actionFilter = actionDescriptor.GetFilters().Select(i => new FilterInfo(i, FilterScope.Action));

            var ls = controllerInfos.Concat(actionFilter).ToList();
            ls.Sort(FilterInfoComparer.Instance);
            return ls;
        }
        internal sealed class FilterInfoComparer : IComparer<FilterInfo>
        {
            private static readonly FilterInfoComparer _instance = new FilterInfoComparer();

            public static FilterInfoComparer Instance
            {
                get
                {
                    return FilterInfoComparer._instance;
                }
            }

            static FilterInfoComparer()
            {
            }

            public int Compare(FilterInfo x, FilterInfo y)
            {
                if (x == null && y == null)
                    return 0;
                if (x == null)
                    return -1;
                if (y == null)
                    return 1;


                if (x.Instance is IOrderFilter && y.Instance is IOrderFilter)
                {
                    var xo = x.Instance as IOrderFilter;
                    var yo = y.Instance as IOrderFilter;
                    return xo.Order - yo.Order;
                }
                else if (x.Instance is IOrderFilter)
                {
                    return -1;
                }
                else if (y.Instance is IOrderFilter)
                {
                    return 1;
                }
                return 0;

            }
        }

    }
}