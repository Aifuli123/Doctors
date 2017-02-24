using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Model.BaseResult
{
    public class SimpleResult
    {
        /// <summary>
        /// 方法
        /// </summary>
        /// <param name="status">1成功，0：已知的失败结果，-1未知的失败结果</param>
        /// <param name="msg">消息</param>
        public SimpleResult(int status, string msg)
        {
            Status = status;
            Msg = msg;
            Success = false;
        }

        public SimpleResult(int status)
        {
            Status = status;
            Msg = "";
            Success = false;
        }

        public SimpleResult()
        {
        }

        /// <summary>
        /// 1成功，0：已知的失败结果   ，-1未知的失败结果
        /// 
        /// 
        /// /// <summary>
        /// 错误码
        /// 1表示成功
        /// 100***：系统级基础错误  
        /// 100000: NULL
        /// 100001: SIGN_ERROR
        /// 100002: APP_AUTH_ERROR
        /// 100003: USER_AUTH_ERROR
        /// 100004: SYSTEM_ERROR
        /// 100005: 参数验证失败
        /// 100006：服务器操作失败
        /// 
        /// 200***：用户相关错误
        /// 200001：登录名或密码错误
        /// 200002: 您的账户已经被禁用，请联系管理员
        /// 200003: 用户授权失败
        /// 200004: 文件不合法
        /// </summary>

        public int Status { get; set; }
        /// <summary>
        /// 消息
        /// </summary>

        public string Msg { get; set; }


        public bool Success { get; set; }
    }
}
