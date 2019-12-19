using System;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface IMails
    {
        /// <summary>
        /// 新增
        /// </summary>
        int Add(Data.Model.Mails model);

        /// <summary>
        /// 更新
        /// </summary>
        int Update(Data.Model.Mails model);

        /// <summary>
        /// 查询所有记录
        /// </summary>
        List<Data.Model.Mails> GetAll();

        /// <summary>
        /// 查询单条记录
        /// </summary>
        Model.Mails Get(int id);

       // List<Model.Mails> GetAccount(Guid Userid,int foldtype);
        List<Model.Mails> GetAccount(out string page, Guid Userid, int foldtype, string query);

        List<Model.Mails> GetSendAccount(Guid Userid);

        List<Model.Mails> GetDelAccount(Guid Userid);

        /// <summary>
        /// 删除
        /// </summary>
        int Delete(int id);

        /// <summary>
        /// 查询记录条数
        /// </summary>
        long GetCount();
    }
}
