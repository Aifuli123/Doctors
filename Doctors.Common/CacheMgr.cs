using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
}
