using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    [Serializable]
    public class News
    {
        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("ID")]
        public Int32  ID { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DisplayName("Title")]
        public string Title { get; set; }

        /// <summary>
        /// Account
        /// </summary>
        [DisplayName("Title1")]
        public string Title1 { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [DisplayName("UserID")]
        public string UserID { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("Type")]
        public string Type { get; set; }

        /// <summary>
        /// 系统备注
        /// </summary>
        [DisplayName("Contents")]
        public string Contents { get; set; }

        /// <summary>
        /// 状态 0 正常 1 冻结
        /// </summary>
        [DisplayName("状态 0 正常 1 冻结")]
        public int State { get; set; }

       

    }
}
