using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Repository
{
    public static class  DapperSqlHelper
    {

        // string connection= ConfigurationManager.ConnectionStrings["wzyx"].ConnectionString;
        static string connection= "Server=(local);Database=MyDataBase;User Id=AIFULI;password=02233657;Trusted_Connection=True;MultipleActiveResultSets=true";
        #region +ExcuteNonQuery 增、删、改同步操作
        /// <summary>
        /// 增、删、改同步操作
        /// 作者： 逍遥帝君
        /// 2016-10-26
        ///  </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">链接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>int</returns>
        public static int ExcuteNonQuery<T>( string cmd, DynamicParameters param, bool flag = true) where T : class, new()
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(connection))
            {
                if (flag)
                {
                    result = con.Execute(cmd, param, null, null, CommandType.StoredProcedure);
                }
                else
                {
                    result = con.Execute(cmd, param, null, null, CommandType.Text);
                }
            }
            return result;
        }
        #endregion

        #region +ExcuteNonQueryAsync 增、删、改异步操作
        /// <summary>
        /// 增、删、改异步操作
        /// 作者： 逍遥帝君
        /// 2016-10-26
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">链接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>int</returns>
        public static async Task<int> ExcuteNonQueryAsync<T>( string cmd, DynamicParameters param, bool flag = true) where T : class, new()
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(connection))
            {
                if (flag)
                {
                    result = await con.ExecuteAsync(cmd, param, null, null, CommandType.StoredProcedure);
                }
                else
                {
                    result = await con.ExecuteAsync(cmd, param, null, null, CommandType.Text);
                }
            }
            return result;
        }
        #endregion

        #region +ExecuteScalar 同步查询操作
        /// <summary>
        /// 同步查询操作
        /// 作者： 逍遥帝君
        /// 2016-10-26
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>object</returns>
        public static object ExecuteScalar<T>( string cmd, DynamicParameters param, bool flag = true) where T : class, new()
        {
            object result = null;
            using (SqlConnection con = new SqlConnection(connection))
            {
                if (flag)
                {
                    result = con.ExecuteScalar(cmd, param, null, null, CommandType.StoredProcedure);
                }
                else
                {
                    result = con.ExecuteScalar(cmd, param, null, null, CommandType.Text);
                }
            }
            return result;
        }
        #endregion

        #region +ExecuteScalarAsync 异步查询操作
        /// <summary>
        /// 异步查询操作
        /// 作者： 逍遥帝君
        /// 2016-10-26
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>object</returns>
        public static async Task<object> ExecuteScalarAsync<T>( string cmd, DynamicParameters param, bool flag = true) where T : class, new()
        {
            object result = null;
            using (SqlConnection con = new SqlConnection(connection))
            {
                if (flag)
                {
                    result = await con.ExecuteScalarAsync(cmd, param, null, null, CommandType.StoredProcedure);
                }
                else
                {
                    result = con.ExecuteScalarAsync(cmd, param, null, null, CommandType.Text);
                }
            }
            return result;
        }
        #endregion

        #region +FindOne  同步查询一条数据
        /// <summary>
        /// 同步查询一条数据
        /// 作者： 逍遥帝君
        /// 2016-10-26
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>t</returns>
        public static T FindOne<T>( string cmd, DynamicParameters param, bool flag = true) where T : class, new()
        {
            IDataReader dataReader = null;
            using (SqlConnection con = new SqlConnection(connection))
            {
                if (flag)
                {
                    dataReader = con.ExecuteReader(cmd, param, null, null, CommandType.StoredProcedure);
                }
                else
                {
                    dataReader = con.ExecuteReader(cmd, param, null, null, CommandType.Text);
                }
                if (dataReader == null || !dataReader.Read()) return null;
                Type type = typeof(T);
                T t = new T();
                foreach (var item in type.GetProperties())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        //属性名与查询出来的列名比较
                        if (item.Name.ToLower() != dataReader.GetName(i).ToLower()) continue;
                        var kvalue = dataReader[item.Name];
                        if (kvalue == DBNull.Value) continue;
                        item.SetValue(t, kvalue, null);
                        break;
                    }
                }
                return t;
            }
        }
        #endregion

        #region +FindOne  异步查询一条数据
        /// <summary>
        /// 异步查询一条数据
        /// 作者： 逍遥帝君
        /// 2016-10-26
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>t</returns>
        public static async Task<T> FindOneAsync<T>( string cmd, DynamicParameters param, bool flag = true) where T : class, new()
        {
            IDataReader dataReader = null;
            using (SqlConnection con = new SqlConnection(connection))
            {
                if (flag)
                {
                    dataReader = await con.ExecuteReaderAsync(cmd, param, null, null, CommandType.StoredProcedure);
                }
                else
                {
                    dataReader = await con.ExecuteReaderAsync(cmd, param, null, null, CommandType.Text);
                }
                if (dataReader == null || !dataReader.Read()) return null;
                Type type = typeof(T);
                T t = new T();
                foreach (var item in type.GetProperties())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        //属性名与查询出来的列名比较
                        if (item.Name.ToLower() != dataReader.GetName(i).ToLower()) continue;
                        var kvalue = dataReader[item.Name];
                        if (kvalue == DBNull.Value) continue;
                        item.SetValue(t, kvalue, null);
                        break;
                    }
                }
                return t;
            }
        }
        #endregion

        #region +FindToList  同步查询数据集合
        /// <summary>
        /// 同步查询数据集合
        /// 作者： 逍遥帝君
        /// 2016-10-26
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>t</returns>
        public static IList<T> FindToList<T>( string cmd, DynamicParameters param, bool flag = true) where T : class, new()
        {
            IDataReader dataReader = null;
            using (SqlConnection con = new SqlConnection(connection))
            {
                if (flag)
                {

                    dataReader = con.ExecuteReader(cmd, param, null, null, CommandType.StoredProcedure);
                }
                else
                {
                    dataReader = con.ExecuteReader(cmd, param, null, null, CommandType.Text);
                }
                if (dataReader == null || !dataReader.Read()) return null;
                Type type = typeof(T);
                List<T> tlist = new List<T>();
                while (dataReader.Read())
                {
                    T t = new T();
                    foreach (var item in type.GetProperties())
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            //属性名与查询出来的列名比较
                            if (item.Name.ToLower() != dataReader.GetName(i).ToLower()) continue;
                            var kvalue = dataReader[item.Name];
                            if (kvalue == DBNull.Value) continue;
                            item.SetValue(t, kvalue, null);
                            break;
                        }
                    }
                    if (tlist != null) tlist.Add(t);
                }
                return tlist;
            }
        }
        #endregion

        #region +FindToListAsync  异步查询数据集合
        /// <summary>
        /// 异步查询数据集合
        /// 作者： 逍遥帝君
        /// 2016-10-26
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>t</returns>
        public static async Task<IList<T>> FindToListAsync<T>( string cmd, DynamicParameters param, bool flag = true) where T : class, new()
        {
            IDataReader dataReader = null;
            using (SqlConnection con = new SqlConnection(connection))
            {
                if (flag)
                {
                    dataReader = await con.ExecuteReaderAsync(cmd, param, null, null, CommandType.StoredProcedure);
                }
                else
                {
                    dataReader = await con.ExecuteReaderAsync(cmd, param, null, null, CommandType.Text);
                }
                if (dataReader == null || !dataReader.Read()) return null;
                Type type = typeof(T);
                List<T> tlist = new List<T>();
                while (dataReader.Read())
                {
                    T t = new T();
                    foreach (var item in type.GetProperties())
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            //属性名与查询出来的列名比较
                            if (item.Name.ToLower() != dataReader.GetName(i).ToLower()) continue;
                            var kvalue = dataReader[item.Name];
                            if (kvalue == DBNull.Value) continue;
                            item.SetValue(t, kvalue, null);
                            break;
                        }
                    }
                    if (tlist != null) tlist.Add(t);
                }
                return tlist;
            }
        }
        #endregion

        #region +FindToList  同步查询数据集合
        /// <summary>
        /// 同步查询数据集合
        ///   作者： 逍遥帝君
        /// 2016-10-26
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>t</returns>
        public static IList<T> FindToListAsPage<T>( string cmd, DynamicParameters param, bool flag = true) where T : class, new()
        {
            IDataReader dataReader = null;
            using (SqlConnection con = new SqlConnection(connection))
            {
                if (flag)
                {
                    dataReader = con.ExecuteReader(cmd, param, null, null, CommandType.StoredProcedure);
                }
                else
                {
                    dataReader = con.ExecuteReader(cmd, param, null, null, CommandType.Text);
                }
                if (dataReader == null || !dataReader.Read()) return null;
                Type type = typeof(T);
                List<T> tlist = new List<T>();
                while (dataReader.Read())
                {
                    T t = new T();
                    foreach (var item in type.GetProperties())
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            //属性名与查询出来的列名比较
                            if (item.Name.ToLower() != dataReader.GetName(i).ToLower()) continue;
                            var kvalue = dataReader[item.Name];
                            if (kvalue == DBNull.Value) continue;
                            item.SetValue(t, kvalue, null);
                            break;
                        }
                    }
                    if (tlist != null) tlist.Add(t);
                }
                return tlist;
            }
        }
        #endregion

        #region +FindToListByPage  同步分页查询数据集合
        /// <summary>
        /// 同步分页查询数据集合
        /// 作者： 逍遥帝君
        /// 2016-10-26
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>t</returns>
        public static IList<T> FindToListByPage<T>( string cmd, DynamicParameters param, bool flag = true) where T : class, new()
        {
            IDataReader dataReader = null;
            using (SqlConnection con = new SqlConnection(connection))
            {
                if (flag)
                {
                    dataReader = con.ExecuteReader(cmd, param, null, null, CommandType.StoredProcedure);
                }
                else
                {
                    dataReader = con.ExecuteReader(cmd, param, null, null, CommandType.Text);
                }
                if (dataReader == null || !dataReader.Read()) return null;
                Type type = typeof(T);
                List<T> tlist = new List<T>();
                while (dataReader.Read())
                {
                    T t = new T();
                    foreach (var item in type.GetProperties())
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            //属性名与查询出来的列名比较
                            if (item.Name.ToLower() != dataReader.GetName(i).ToLower()) continue;
                            var kvalue = dataReader[item.Name];
                            if (kvalue == DBNull.Value) continue;
                            item.SetValue(t, kvalue, null);
                            break;
                        }
                    }
                    if (tlist != null) tlist.Add(t);
                }
                return tlist;
            }
        }
        #endregion

        #region +FindToListByPageAsync  异步分页查询数据集合
        /// <summary>
        /// 异步分页查询数据集合
        /// 作者： 逍遥帝君
        /// 2016-10-26
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>t</returns>
        public static async Task<IList<T>> FindToListByPageAsync<T>( string cmd, DynamicParameters param, bool flag = true) where T : class, new()
        {
            IDataReader dataReader = null;
            using (SqlConnection con = new SqlConnection(connection))
            {
                if (flag)
                {
                    dataReader = await con.ExecuteReaderAsync(cmd, param, null, null, CommandType.StoredProcedure);
                }
                else
                {
                    dataReader = await con.ExecuteReaderAsync(cmd, param, null, null, CommandType.Text);
                }
                if (dataReader == null || !dataReader.Read()) return null;
                Type type = typeof(T);
                List<T> tlist = new List<T>();
                while (dataReader.Read())
                {
                    T t = new T();
                    foreach (var item in type.GetProperties())
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            //属性名与查询出来的列名比较
                            if (item.Name.ToLower() != dataReader.GetName(i).ToLower()) continue;
                            var kvalue = dataReader[item.Name];
                            if (kvalue == DBNull.Value) continue;
                            item.SetValue(t, kvalue, null);
                            break;
                        }
                    }
                    if (tlist != null) tlist.Add(t);
                }
                return tlist;
            }
        }
        #endregion
    }
}
