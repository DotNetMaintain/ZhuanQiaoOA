using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    [Serializable]
    public class Read_Log
    {
        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("id")]
        public Guid id { get; set; }

        /// <summary>
        /// guid
        /// </summary>
        [DisplayName("guid")]
        public string guid { get; set; }

        /// <summary>
        /// userid
        /// </summary>
        [DisplayName("userid")]
        public string userid { get; set; }

        /// <summary>
        /// table_name
        /// </summary>
        [DisplayName("table_name")]
        public string table_name { get; set; }


        /// <summary>
        /// table_name
        /// </summary>
        [DisplayName("modify_date")]
        public DateTime modify_date { get; set; }
       
    }
}
