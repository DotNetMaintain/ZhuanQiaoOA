using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    [Serializable]
    public class Mails1
    {
        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("ID")]
        public Int32  ID { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DisplayName("guid")]
        public string guid { get; set; }

        /// <summary>
        /// Account
        /// </summary>
        [DisplayName("ComID")]
        public Int32 ComID { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [DisplayName("ReceiverID")]
        public string ReceiverID { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("SenderID")]
        public string SenderID { get; set; }

        /// <summary>
        /// 系统备注
        /// </summary>
        [DisplayName("SenderGUID")]
        public string SenderGUID { get; set; }

        /// <summary>
        /// 系统备注
        /// </summary>
        [DisplayName("SenderRealName")]
        public string SenderRealName { get; set; }

        /// <summary>
        /// 系统备注
        /// </summary>
        [DisplayName("SenderDepName")]
        public string SenderDepName { get; set; }

        /// <summary>
        /// 系统备注
        /// </summary>
        [DisplayName("SendType")]
        public string SendType { get; set; }

        /// <summary>
        /// 系统备注
        /// </summary>
        [DisplayName("Subject")]
        public string Subject { get; set; }


        /// <summary>
        /// 系统备注
        /// </summary>
        [DisplayName("IsRead")]
        public Int32 IsRead { get; set; }


        /// <summary>
        /// 系统备注
        /// </summary>
        [DisplayName("FolderType")]
        public Int32 FolderType { get; set; }


        /// <summary>
        /// 系统备注
        /// </summary>
        [DisplayName("SendTime")]
        public DateTime SendTime { get; set; }


        

        /// <summary>
        /// 状态 0 正常 1 冻结
        /// </summary>
        [DisplayName("状态 0 正常 1 冻结")]
        public int did { get; set; }

       

    }
}

