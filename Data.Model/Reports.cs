using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Data.Model
{
    [Serializable]
    public  class Reports
    {
       

        /// <summary>
        /// Name
        /// </summary>
        [DisplayName("DeptName")]
        public string DeptName { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DisplayName("UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// 事假
        /// </summary>
        [DisplayName("AffairDays")]
        public double AffairDays { get; set; }

        /// <summary>
        /// 婚假
        /// </summary>
        [DisplayName("WeddingDays")]
        public double WeddingDays { get; set; }

        /// <summary>
        /// 病假
        /// </summary>
        [DisplayName("SickDays")]
        public double SickDays { get; set; }

        /// <summary>
        /// 产假
        /// </summary>
        [DisplayName("MaternityDays")]
        public double MaternityDays { get; set; }

        /// <summary>
        /// 陪护假
        /// </summary>
        [DisplayName("ChaperonageDays")]
        public double ChaperonageDays { get; set; }

        /// <summary>
        /// 年假
        /// </summary>
        [DisplayName("YearDays")]
        public double YearDays { get; set; }

        /// <summary>
        /// 探亲假
        /// </summary>
        [DisplayName("HomeDays")]
        public double HomeDays { get; set; }

        /// <summary>
        /// 上年度公休假
        /// </summary>
        [DisplayName("LastPublicDays")]
        public decimal LastPublicDays { get; set; }

        /// <summary>
        /// 本年度公休假
        /// </summary>
        [DisplayName("PublicDays")]
        public decimal PublicDays { get; set; }

        /// <summary>
        /// 调休假
        /// </summary>
        [DisplayName("RestDays")]
        public decimal RestDays { get; set; }

        /// <summary>
        /// 调休假
        /// </summary>
        [DisplayName("subLastPublicDate")]
        public double subLastPublicDate { get; set; }

        /// <summary>
        /// 调休假
        /// </summary>
        [DisplayName("subPublicDate")]
        public double subPublicDate { get; set; }

        /// <summary>
        /// 调休假
        /// </summary>
        [DisplayName("subRestDate")]
        public double subRestDate { get; set; }

       

    }


    [Serializable]
    public class RestDetailReports
    {
       /// <summary>
        /// Name
        /// </summary>
        [DisplayName("DeptName")]
        public string DeptName { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DisplayName("UserName")]
        public string UserName { get; set; }


        /// <summary>
        /// 假别
        /// </summary>
        [DisplayName("RestType")]
        public string RestType { get; set; }

        /// <summary>
        /// 请假天数
        /// </summary>
        [DisplayName("Days")]
        public double Days { get; set; }

        /// <summary>
        /// 请假开始时间
        /// </summary>
        [DisplayName("StartTime")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 请假结束时间
        /// </summary>
        [DisplayName("EndTime")]
        public DateTime EndTime { get; set; }
    }




    [Serializable]
    public class ReceiveReports
    {
        /// <summary>
        /// Name
        /// </summary>
        [DisplayName("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DisplayName("BeginDate")]
        public DateTime BeginDate { get; set; }



        /// <summary>
        /// Name
        /// </summary>
        [DisplayName("EndDate")]
        public DateTime EndDate { get; set; }


        /// <summary>
        /// 零报
        /// </summary>
        [DisplayName("Model")]
        public Int32 Model { get; set; }

        /// <summary>
        /// 帮困
        /// </summary>
        [DisplayName("Unit")]
        public Int32 Unit { get; set; }

        /// <summary>
        /// 减负
        /// </summary>
        [DisplayName("Type")]
        public Int32 Type { get; set; }

        /// <summary>
        /// 交换次数
        /// </summary>
        [DisplayName("Fresequence")]
        public Int32 Fresequence { get; set; }
    }



}
