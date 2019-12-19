using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    [Serializable]
    public class Mails_Detail1
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
        [DisplayName("SendIDs")]
        public string SendIDs { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("SendRealNames")]
        public string SendRealNames { get; set; }

        /// <summary>
        /// 系统备注
        /// </summary>
        [DisplayName("CcIDs")]
        public string CcIDs { get; set; }

        /// <summary>
        /// 系统备注
        /// </summary>
        [DisplayName("CcRealNames")]
        public string CcRealNames { get; set; }

        /// <summary>
        /// 系统备注
        /// </summary>
        [DisplayName("BccIDs")]
        public string BccIDs { get; set; }

        /// <summary>
        /// 系统备注
        /// </summary>
        [DisplayName("BccRealNames")]
        public string BccRealNames { get; set; }

        /// <summary>
        /// 系统备注
        /// </summary>
        [DisplayName("Bodys")]
        public string Bodys { get; set; }


        /// <summary>
        /// 系统备注
        /// </summary>
        [DisplayName("Attachments")]
        public string Attachments { get; set; }


       
       

    }
}

