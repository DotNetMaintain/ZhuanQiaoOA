using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    [Serializable]
    public class Mails_Detail
    {
        private int id;
        private string guid;
        private int comID;
        private string receiveIDs;
        private string receiveIDRealNames;
        private string ccIDs;
        private string ccRealNames;
        private string bccIDs;
        private string bccRealNames;
        private string bodys;
        private string attachments;
       

        public Mails_Detail() { }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Guid
        {
            get { return this.guid; }
            set { this.guid = value; }
        }
        public int ComID
        {
            get { return this.comID; }
            set { this.comID = value; }
        }
        public string ReceiveIDs
        {
            get { return this.receiveIDs; }
            set { this.receiveIDs = value; }
        }
        public string ReceiveIDRealNames
        {
            get { return this.receiveIDRealNames; }
            set { this.receiveIDRealNames = value; }
        }
        public string CcIDs
        {
            get { return this.ccIDs; }
            set { this.ccIDs = value; }
        }
        public string CcRealNames
        {
            get { return this.ccRealNames; }
            set { this.ccRealNames = value; }
        }
        public string BccIDs
        {
            get { return this.bccIDs; }
            set { this.bccIDs = value; }
        }
        public string BccRealNames
        {
            get { return this.bccRealNames; }
            set { this.bccRealNames = value; }
        }
        public string Bodys
        {
            get { return this.bodys; }
            set { this.bodys = value; }
        }


        public string Attachments
        {
            get { return this.attachments; }
            set { this.attachments = value; }
        }

    }
}
