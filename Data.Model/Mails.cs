using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    [Serializable]
    public class Mails
    {
        /// <summary>
        /// id
        /// </summary>
        [DisplayName("id")]
        public int id { get; set; }

        /// <summary>
        /// guid
        /// </summary>
        [DisplayName("guid")]
        public string guid { get; set; }

        /// <summary>
        /// ComID
        /// </summary>
        [DisplayName("ComID")]
        public int? ComID { get; set; }

        /// <summary>
        /// ReceiverID
        /// </summary>
        [DisplayName("ReceiverID")]
        public string ReceiverID { get; set; }

        /// <summary>
        /// SenderIDs
        /// </summary>
        [DisplayName("SenderIDs")]
        public string SenderIDs { get; set; }

        /// <summary>
        /// CCIDs
        /// </summary>
        [DisplayName("CCIDs")]
        public string CCIDs { get; set; }

        /// <summary>
        /// BccIDs
        /// </summary>
        [DisplayName("BccIDs")]
        public string BccIDs { get; set; }

        /// <summary>
        /// SenderGUID
        /// </summary>
        [DisplayName("SenderGUID")]
        public string SenderGUID { get; set; }

        /// <summary>
        /// SenderRealName
        /// </summary>
        [DisplayName("SenderRealName")]
        public string SenderRealName { get; set; }

        /// <summary>
        /// SenderDepName
        /// </summary>
        [DisplayName("SenderDepName")]
        public string SenderDepName { get; set; }

        /// <summary>
        /// SendType
        /// </summary>
        [DisplayName("SendType")]
        public int? SendType { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        [DisplayName("Subject")]
        public string Subject { get; set; }

        /// <summary>
        /// IsRead
        /// </summary>
        [DisplayName("IsRead")]
        public int? IsRead { get; set; }

        /// <summary>
        /// FolderType
        /// </summary>
        [DisplayName("FolderType")]
        public int? FolderType { get; set; }

        /// <summary>
        /// SendTime
        /// </summary>
        [DisplayName("SendTime")]
        public DateTime? SendTime { get; set; }

        /// <summary>
        /// did
        /// </summary>
        [DisplayName("did")]
        public int did { get; set; }

        /// <summary>
        /// body
        /// </summary>
        [DisplayName("body")]
        public string body { get; set; }

        /// <summary>
        /// fileattech
        /// </summary>
        [DisplayName("fileattech")]
        public string fileattech { get; set; }

    }
}
