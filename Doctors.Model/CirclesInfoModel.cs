using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Model
{
    public class CirclesInfoModel
    {
        #region Model
        private string _circleid;
        private long _doctorid;
        private string _imageUrl;
        private string _contentText;
        private DateTime? _createtime;
        private int? _commentCount;
        private int? _praiseCount;
        /// <summary>
        /// 
        /// </summary>
        public string circleId
        {
            set { _circleid = value; }
            get { return _circleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long userId
        {
            set { _doctorid = value; }
            get { return _doctorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string imageUrl
        {
            set { _imageUrl = value; }
            get { return _imageUrl; }
        }

        /// <summary>
        /// 
        /// </summary>
        public String contentText
        {
            set { _contentText = value; }
            get { return _contentText; }
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
        public int? commentCount
        {
            set { _commentCount = value; }
            get { return _commentCount; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? praiseCount
        {
            set { _praiseCount = value; }
            get { return _praiseCount; }
        }
        #endregion Model
    }
}
