using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Platform
{
    public class Mails_Detail
    {

                /// <summary>
        /// 前缀
        /// </summary>
        public const string PREFIX = "u_";
        private Data.Interface.IMails_Detail dataNews;
        public Mails_Detail()
        {
            this.dataNews = Data.Factory.Platform.GetMails_DetailInstance();
        }
        /// <summary>
        /// 新增
        /// </summary>
        public int Add(Data.Model.Mails_Detail model)
        {
            return dataNews.Add(model);
        }
        /// <summary>
        /// 更新
        /// </summary>
        public int Update(Data.Model.Mails_Detail model)
        {
            return dataNews.Update(model);
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.Mails_Detail> GetAll()
        {
            return dataNews.GetAll();
        }
        /// <summary>
        /// 查询单条记录
        /// </summary>
        public Data.Model.Mails_Detail Get(Int32 id)
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


        ///// <summary>
        ///// 查询单条记录
        ///// </summary>
        public Data.Model.Mails_Detail GetGuid(string guid)
        {
            return dataNews.GetGuid(guid);
        }


        //public List<Data.Model.Mails_Detail> GetSendAccount(Guid Userid)
        //{
        //    return dataNews.GetSendAccount(Userid);
        //}


        //public List<Data.Model.Mails_Detail> GetDelAccount(Guid Userid)
        //{
        //    return dataNews.GetDelAccount(Userid);
        //}



    }
}

