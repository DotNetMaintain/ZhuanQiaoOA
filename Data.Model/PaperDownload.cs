using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Model
{
     [Serializable]
    public class PaperDownload
    {


        private int _id; //  
        private string _guid; //   
        private string _DPaperNo; //  
        private string _Subject; //  
        private string _FileAttech; //  
        private string _DPaperSymbol; //   
        private string _AddUserid; //  
        private DateTime _AddTime; //  


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
        public string DPaperNo
        {
            get { return _DPaperNo; }
            set
            {
                _DPaperNo = value;
            }
        }

        /// <summary>
        ///
        /// </summary>  
        public string Subject
        {
            get { return _Subject; }
            set
            {

                _Subject = value;
            }
        }

        /// <summary>
        ///
        /// </summary>  
        public string FileAttech
        {
            get { return _FileAttech; }
            set
            {
                _FileAttech = value;
            }
        }

        /// <summary>
        ///
        /// </summary>  
        public string DPaperSymbol
        {
            get { return _DPaperSymbol; }
            set
            {

                _DPaperSymbol = value;
            }
        }


        public string AddUserid
        {
            get { return _AddUserid; }
            set
            {

                _AddUserid = value;
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

       

    }
}
