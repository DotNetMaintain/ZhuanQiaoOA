using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Platform
{
    public class Mail
    {

                /// <summary>
        /// 前缀
        /// </summary>
        public const string PREFIX = "u_";
        private Data.Interface.IMails dataNews;
        public Mail()
        {
            this.dataNews = Data.Factory.Platform.GetMailsInstance();
        }
        /// <summary>
        /// 新增
        /// </summary>
        public int Add(Data.Model.Mails model)
        {
            return dataNews.Add(model);
        }
        /// <summary>
        /// 更新
        /// </summary>
        public int Update(Data.Model.Mails model)
        {
            return dataNews.Update(model);
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.Mails> GetAll()
        {
            return dataNews.GetAll();
        }
        /// <summary>
        /// 查询单条记录
        /// </summary>
        public Data.Model.Mails Get(Int32 id)
        {
            return dataNews.Get(id);
        }

       

        /// <summary>
        /// 删除
        /// </summary>
        public int Delete(Int32 id)
        {
            return dataNews.Delete(id);
        }
        /// <summary>
        /// 查询记录条数
        /// </summary>
        public long GetCount()
        {
            return dataNews.GetCount();
        }


        /// <summary>
        /// 查询单条记录
        /// </summary>
        /// out string pager,Guid UserID, int foldtype, string query = ""
        public List<Data.Model.Mails> GetAccount(out string pager, Guid Userid, int foldtype, string query = "")
        {
            return dataNews.GetAccount(out pager, Userid, foldtype, query);
        }


        public List<Data.Model.Mails> GetSendAccount(Guid Userid)
        {
            return dataNews.GetSendAccount(Userid);
        }


        public List<Data.Model.Mails> GetDelAccount(Guid Userid)
        {
            return dataNews.GetDelAccount(Userid);
        }



    }
}
