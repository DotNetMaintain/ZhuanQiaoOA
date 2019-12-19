using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Data.Model
{

    [Serializable]
    public class StickyNotes
    {
        private int _id; //  
        private string _guid; //  
        private int _ComID; //  
        private string _UserID; //  
        private DateTime _AddTime; //   
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
        public int ComID
        {
            get { return _ComID; }
            set
            {
                if (value.ToString().Length > 4)
                {
                    throw new Exception("ComID字段长度不能超过4");
                }
                _ComID = value;
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
