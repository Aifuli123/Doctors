using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using Doctors.Common.Extensions;

namespace Doctors.Common
{
    public class CacheMgr
    {
        /// <summary>
        /// 创建一份永久缓存，当网站的进程重启以后，缓存丢失
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetData(string key, object value)
        {
            HttpRuntime.Cache[key] = value;
        }
        /// <summary>
        /// 覆盖插入
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Insert(string key, object value, CacheType type)
        {
            int m;
            int s;
            switch ((int)type)
            {
                case 1:
                   m = ConfigurationManager.AppSettings["tokenExpiresM"].ToInt();
                   s = ConfigurationManager.AppSettings["tokenExpiresS"].ToInt();
                    break;
                default:
                    m = ConfigurationManager.AppSettings["tokenExpiresM"].ToInt();
                    s = ConfigurationManager.AppSettings["tokenExpiresS"].ToInt();
                    break;
            }
          
            TimeSpan span = new TimeSpan(0,m,s);

            HttpRuntime.Cache.Insert(key,value, null, Cache.NoAbsoluteExpiration,span);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            return (T)HttpRuntime.Cache.Get(key);
        }
        /// <summary>
        /// 获取指定key的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetData<T>(string key)
        {
            return (T)HttpRuntime.Cache[key];
        }
        public static void RemoveData(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }
    }

    public enum CacheType
    {
        Token=1,
        User=2
    }
}
