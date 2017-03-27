using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Model
{
    public class QuestionModel
    {
        #region Model
        private string _questionid;
        private long _doctorid;
        private string _questiontopic;
        private string _description;
        private string _pictures;
        private DateTime? _createtime;
        private string _doctorids;
        /// <summary>
        /// 
        /// </summary>
        public string questionId
        {
            set { _questionid = value; }
            get { return _questionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long doctorId
        {
            set { _doctorid = value; }
            get { return _doctorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string questiontopic
        {
            set { _questiontopic = value; }
            get { return _questiontopic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pictures
        {
            set { _pictures = value; }
            get { return _pictures; }
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
        public string doctorIDs
        {
            set { _doctorids = value; }
            get { return _doctorids; }
        }
        #endregion Model
    }
}
