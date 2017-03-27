using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Doctors.API.Controllers.BaseContolles;
using Doctors.IServices;
using Doctors.Model;
using Doctors.Model.BaseResult;

namespace Doctors.API.Controllers
{
    public class QuestionController : BaseApiController
    {
        IQuestionService questionService;
        public QuestionController(IQuestionService question)
        {
            questionService = question;
        }


        /// <summary>
        /// 添加问题
        /// </summary>
        /// <param name="questiontopic">主题</param>
        /// <param name="description">描述</param>
        /// <param name="picturesurl">图片路径</param>
        /// <returns></returns>
        //http://localhost:41877/api/Question/QuestionAdd?questiontopic=1&&description=2&&picturesurl=西安
        [System.Web.Http.HttpGet]
        public IHttpActionResult QuestionAdd( string questiontopic,string description, string picturesurl)
        {
            QuestionModel questionModel= new QuestionModel();
            questionModel.questionId = System.Guid.NewGuid().ToString();
            questionModel.doctorId = 2;
            questionModel.description = description;
            questionModel.questiontopic = questiontopic;
            questionModel.Pictures = picturesurl;
            questionModel.createtime = System.DateTime.Now;
            var item = questionService.QuestionAdd(questionModel);
            SimpleResult result = new SimpleResult();
            result.Resource = item;
            return Json(result);
        }
    }
}