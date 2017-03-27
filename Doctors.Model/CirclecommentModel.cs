using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Model
{
    public class CirclecommentModel
    {
        public CirclecommentModel()
        { }
        #region Model
        private string _circlecommentid;
        private string _circleid;
        private string _doctorid;
        private DateTime? _createtime;
        private string _name;
        private string _head_image;
        private string _commentcontent;
        private string _againcomment;
        /// <summary>
        /// 
        /// </summary>
        public string circlecommentID
        {
            set { _circlecommentid = value; }
            get { return _circlecommentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string circleID
        {
            set { _circleid = value; }
            get { return _circleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string doctorID
        {
            set { _doctorid = value; }
            get { return _doctorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string head_image
        {
            set { _head_image = value; }
            get { return _head_image; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string commentContent
        {
            set { _commentcontent = value; }
            get { return _commentcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string againcomment
        {
            set { _againcomment = value; }
            get { return _againcomment; }
        }
        #endregion Model
    }
}
