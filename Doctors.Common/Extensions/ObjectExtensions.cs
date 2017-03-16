using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Common.Extensions
{
    public static class ObjectExtensions
    {
        #region 类型转换

        /// <summary>
        /// 转换为int，默认值为int的默认值
        /// </summary>
        /// <param name="o">当前对象</param>
        /// <returns></returns>
        public static int ToInt(this object o)
        {
            return o.To<int>();
        }

        /// <summary>
        /// 转换为Decimal，默认值为Decimal的默认值
        /// </summary>
        /// <param name="o">当前对象</param>
        /// <returns></returns>
        public static Decimal ToDecimal(this object o)
        {
            return o.To<Decimal>();
        }

        /// <summary>
        /// 转换为Double，默认值为Double的默认值
        /// </summary>
        /// <param name="o">当前对象</param>
        /// <returns></returns>
        public static Double ToDouble(this object o)
        {
            return o.To<Double>();
        }

        /// <summary>
        /// 转换为bool，默认值为bool的默认值
        /// </summary>
        /// <param name="o">当前对象</param>
        /// <returns></returns>
        public static bool ToBool(this object o)
        {
            return o.To<bool>();
        }

        /// <summary>
        /// 转换为DateTime，默认值为DateTime的默认值
        /// </summary>
        /// <param name="o">当前对象</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object o)
        {
            return o.To<DateTime>();
        }

        /// <summary>
        /// 转换为Guid，默认值为Guid的默认值
        /// </summary>
        /// <param name="o">当前对象</param>
        /// <returns></returns>
        public static Guid ToGuid(this object o)
        {
            return o.To<Guid>();
        }

        /// <summary>
        /// 转换为目标类型
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="o">当前对象</param>
        /// <param name="defaultvalue">转换失败时的默认值</param>
        /// <returns></returns>
        public static T To<T>(this object o, T defaultvalue) where T : struct
        {
            return (T)o.TryParse(typeof(T), defaultvalue);
        }

        /// <summary>
        /// 转换为目标类型（默认值为目标类型的默认值）
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="o">当前对象</param>
        /// <returns></returns>
        public static T To<T>(this object o) where T : struct
        {
            return (T)o.TryParse(typeof(T), default(T));
        }

        /// <summary>
        /// 转化为目标类型的可空类型，失败时为null
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="o">当前对象</param>
        /// <returns></returns>
        public static T? ToNullable<T>(this object o) where T : struct
        {
            return (T?)o.TryParse(typeof(T), null);
        }

        #region 内核方法，使用TryParse实现，避免抛出异常

        private static object TryParse(this object o, Type targerttype)
        {
            return o.TryParse(targerttype, o);
        }

        private static object TryParse(this object o, Type targerttype, object defaultvalue)
        {
            if (o.IsNull())
                return defaultvalue;

            string value = o.ToString();

            if (targerttype.IsGenericType && targerttype.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                targerttype = new NullableConverter(targerttype).UnderlyingType;

            TypeCode typeCode = Type.GetTypeCode(targerttype);
            switch (typeCode)
            {
                case TypeCode.Boolean:
                    Boolean boolean;
                    return Boolean.TryParse(value, out boolean) ? boolean : defaultvalue;

                case TypeCode.Char:
                    Char ch;
                    return Char.TryParse(value, out ch) ? ch : defaultvalue;

                case TypeCode.SByte:
                    SByte sb;
                    return SByte.TryParse(value, out sb) ? sb : defaultvalue;

                case TypeCode.Byte:
                    Byte by;
                    return Byte.TryParse(value, out by) ? by : defaultvalue;

                case TypeCode.Int16:
                    Int16 int16;
                    return Int16.TryParse(value, out int16) ? int16 : defaultvalue;

                case TypeCode.UInt16:
                    UInt16 uInt16;
                    return UInt16.TryParse(value, out uInt16) ? uInt16 : defaultvalue;

                case TypeCode.Int32:
                    Int32 int32;
                    return Int32.TryParse(value, out int32) ? int32 : defaultvalue;

                case TypeCode.UInt32:
                    UInt32 uInt32;
                    return UInt32.TryParse(value, out uInt32) ? uInt32 : defaultvalue;

                case TypeCode.Int64:
                    Int64 int64;
                    return Int64.TryParse(value, out int64) ? int64 : defaultvalue;

                case TypeCode.UInt64:
                    UInt64 uInt64;
                    return UInt64.TryParse(value, out uInt64) ? uInt64 : defaultvalue;

                case TypeCode.Single:
                    Single single;
                    return Single.TryParse(value, out single) ? single : defaultvalue;

                case TypeCode.Double:
                    Double dou;
                    return Double.TryParse(value, out dou) ? dou : defaultvalue;

                case TypeCode.Decimal:
                    Decimal de;
                    return Decimal.TryParse(value, out de) ? de : defaultvalue;

                case TypeCode.DateTime:
                    DateTime dt;
                    return DateTime.TryParse(value, out dt) ? dt : defaultvalue;

            }
            if (targerttype.Equals(typeof(Guid)))
            {
                Guid guid;
                return Guid.TryParse(value, out guid) ? guid : defaultvalue;
            }
            if (targerttype.Equals(typeof(TimeSpan)))
            {
                TimeSpan ts;
                return TimeSpan.TryParse(value, out ts) ? ts : defaultvalue;
            }
            return defaultvalue;
        }

        #endregion

        #endregion

        /// <summary>
        /// 当前对象是否为null
        /// </summary>
        /// <param name="o">当前对象</param>
        /// <returns></returns>
        public static bool IsNull(this object o)
        {
            return o == null;
        }

        /// <summary>
        /// 从源对象source中找对应的属性值，Map到当前对象value中。效果等价于：value.Property1=source.Property1;value.Property2=source.Property2;...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <remarks>Added by fengzili at 20150409</remarks>
        public static T MergeProperty<T>(this T value, object source)
        {
            Type typValue = source.GetType();
            foreach (PropertyInfo pfiTarget in typeof(T).GetProperties())
            {
                if (pfiTarget.GetSetMethod() == null)
                {
                    continue;
                }
                PropertyInfo pfiSource = typValue.GetProperty(pfiTarget.Name);
                if (pfiSource == null)
                {
                    continue;
                }
                object objValue = pfiSource.GetValue(source, null);
                if (pfiTarget.PropertyType == pfiSource.PropertyType)
                {
                    pfiTarget.SetValue(value, objValue, null);
                    continue;
                }
                if (objValue == null || objValue == DBNull.Value)
                {
                    continue;
                }
                if (pfiTarget.PropertyType.BaseType == typeof(Enum))
                {
                    objValue = Enum.Parse(pfiTarget.PropertyType, objValue.ToString());
                }
                else if (pfiTarget.PropertyType.IsGenericType)
                {
                    Type typParameter = pfiTarget.PropertyType.GetGenericArguments()[0];
                    if (typParameter.BaseType == typeof(Enum))
                    {
                        objValue = Enum.Parse(typParameter, objValue.SafeToString());
                    }
                    else
                    {
                        objValue = Convert.ChangeType(objValue, typParameter);
                    }
                    pfiTarget.SetValue(value, objValue, null);
                    continue;
                }
                pfiTarget.SetValue(value, Convert.ChangeType(objValue, pfiTarget.PropertyType), null);
            }
            return value;
        }

        /// <summary>
        /// 简单的判断集合是否为空
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        ///<remarks>Added by fengzili at 2015.05.14</remarks>
        public static bool IsNullOrEmpty(this IEnumerable collection)
        {
            if (collection == null)
            {
                return true;
            }
            foreach (object o in collection)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 更加安全的调用对象的ToString方法，如果是null，返回string.Empty；其它情况调用实际的ToString。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks>Added by fengzili at 20150409</remarks>
        public static string SafeToString(this object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            return value.ToString();
        }
    }
}
