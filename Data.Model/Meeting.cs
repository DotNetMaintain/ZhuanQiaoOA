using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Data.Model
{

    [Serializable]
    public class Meeting
    {
        private int _id; //  
        private string _guid; //  
        private string _UserID; //  
        private string _MainTopics; //  
        private string _Address; //  
        private DateTime _AddTime; //   
        private string _AbsencePerson; //  
        private string _Bodys; //  


        /// <summary>
        ///
        /// </summary>  
        public int id
        {
            get { return _id; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new Exception("id不能为空");
                }
                if (value.ToString().Length > 4)
                {
                    throw new Exception("id字段长度不能超过4");
                }
                _id = value;
            }
        }

        /// <summary>
        ///
        /// </summary>  
        public string guid
        {
            get { return _guid; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new Exception("guid不能为空");
                }
                if (value.ToString().Length > 100)
                {
                    throw new Exception("guid字段长度不能超过100");
                }
                _guid = value;
            }
        }

        

        /// <summary>
        ///
        /// </summary>  
        public string UserID
        {
            get { return _UserID; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new Exception("UserID不能为空");
                }
                if (value.ToString().Length > 500)
                {
                    throw new Exception("UserID字段长度不能超过500");
                }
                _UserID = value;
            }
        }

        /// <summary>
        ///
        /// </summary>  
        public string MainTopics
        {
            get { return _MainTopics; }
            set
            {

                _MainTopics = value;
            }
        }

        /// <summary>
        ///
        /// </summary>  
        public string Address
        {
            get { return _Address; }
            set
            {
                _Address = value;
            }
        }

       

        /// <summary>
        ///
        /// </summary>  
        public DateTime AddTime
        {
            get { return _AddTime; }
            set
            {
                _AddTime = value;
            }
        }

        /// <summary>
        ///
        /// </summary>  
        public string AbsencePerson
        {
            get { return _AbsencePerson; }
            set
            {

                _AbsencePerson = value;
            }
        }

        /// <summary>
        ///
        /// </summary>  
        public string Bodys
        {
            get { return _Bodys; }
            set
            {

                _Bodys = value;
            }
        }

      
    }
}
