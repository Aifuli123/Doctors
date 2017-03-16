using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Model
{
    public class DoctorInfor
    {
        #region Model
        private long _doctorid;
        private long _accountid;
        private string _name;
        private bool? _sex;
        private string _head_image;
        private string _mobilephone;
        private string _email;
        private string _idcardimage;
        private string _password;
        private string _teach_title;
        private string _job;
        private string _hospitalid;
        private string _departmentid;
        private string _experience;
        private int? _isture;
        private int? _enable;
        private string _create_time;
        private string _update_time;
        private string _description;
        private string _qrcode;
        /// <summary>
        /// 
        /// </summary>
        public long doctorID
        {
            set { _doctorid = value; }
            get { return _doctorid; }
        }
        public long accountID
        {
            set { _accountid = value; }
            get { return _accountid; }
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
        public bool? sex
        {
            set { _sex = value; }
            get { return _sex; }
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
        public string mobilephone
        {
            set { _mobilephone = value; }
            get { return _mobilephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDcardImage
        {
            set { _idcardimage = value; }
            get { return _idcardimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string teach_title
        {
            set { _teach_title = value; }
            get { return _teach_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string job
        {
            set { _job = value; }
            get { return _job; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hospitalid
        {
            set { _hospitalid = value; }
            get { return _hospitalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string departmentid
        {
            set { _departmentid = value; }
            get { return _departmentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string experience
        {
            set { _experience = value; }
            get { return _experience; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isture
        {
            set { _isture = value; }
            get { return _isture; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? enable
        {
            set { _enable = value; }
            get { return _enable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string create_time
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string update_time
        {
            set { _update_time = value; }
            get { return _update_time; }
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
        public string QRcode
        {
            set { _qrcode = value; }
            get { return _qrcode; }
        }
        #endregion Model
    }
}
