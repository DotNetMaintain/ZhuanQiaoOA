using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Data.Model
{

    [Serializable]
    public class NewsArticle
    {
        private int _id; //  
        private string _guid; //  
        private int _ComID; //  
        private string _NewsTitle; //  
        private string _FilePath; //  
        private string _Notes; //  
        private string _TypeID; //  
        private int _CreatorID; //  
        private string _CreatorRealName; //  
        private string _CreatorDepName; //  
        private DateTime _AddTime; //  
        private string _ShareUsers; //  
        private string _ShareDeps; //  
        private string _namelist; //  
        private string _typename; // 

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
        public string NewsTitle
        {
            get { return _NewsTitle; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new Exception("NewsTitle不能为空");
                }
                if (value.ToString().Length > 500)
                {
                    throw new Exception("NewsTitle字段长度不能超过500");
                }
                _NewsTitle = value;
            }
        }

        /// <summary>
        ///
        /// </summary>  
        public string FilePath
        {
            get { return _FilePath; }
            set
            {
               
                _FilePath = value;
            }
        }

        /// <summary>
        ///
        /// </summary>  
        public string Notes
        {
            get { return _Notes; }
            set
            {
                _Notes = value;
            }
        }

        /// <summary>
        ///
        /// </summary>  
        public string TypeID
        {
            get { return _TypeID; }
            set
            {
               
                _TypeID = value;
            }
        }


        public string  TypeName
        {
            get { return _typename; }
            set
            {
               
                _typename = value;
            }
        }


        /// <summary>
        ///
        /// </summary>  
        public int CreatorID
        {
            get { return _CreatorID; }
            set
            {
                if (value.ToString().Length > 4)
                {
                    throw new Exception("CreatorID字段长度不能超过4");
                }
                _CreatorID = value;
            }
        }

        /// <summary>
        ///
        /// </summary>  
        public string CreatorRealName
        {
            get { return _CreatorRealName; }
            set
            {
                if (value.ToString().Length > 100)
                {
                    throw new Exception("CreatorRealName字段长度不能超过100");
                }
                _CreatorRealName = value;
            }
        }

        /// <summary>
        ///
        /// </summary>  
        public string CreatorDepName
        {
            get { return _CreatorDepName; }
            set
            {
                if (value.ToString().Length > 100)
                {
                    throw new Exception("CreatorDepName字段长度不能超过100");
                }
                _CreatorDepName = value;
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
        public string ShareUsers
        {
            get { return _ShareUsers; }
            set
            {
                
                _ShareUsers = value;
            }
        }

        /// <summary>
        ///
        /// </summary>  
        public string ShareDeps
        {
            get { return _ShareDeps; }
            set
            {
               
                _ShareDeps = value;
            }
        }

        /// <summary>
        ///
        /// </summary>  
        public string namelist
        {
            get { return _namelist; }
            set
            {
               
                _namelist = value;
            }
        }
    }
}