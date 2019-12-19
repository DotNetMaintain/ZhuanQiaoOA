using System;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface IMails_Detail
    {
        /// <summary>
        /// 新增
        /// </summary>
        int Add(Data.Model.Mails_Detail model);

        /// <summary>
        /// 更新
        /// </summary>
        int Update(Data.Model.Mails_Detail model);

        /// <summary>
        /// 查询所有记录
        /// </summary>
        List<Data.Model.Mails_Detail> GetAll();

        /// <summary>
        /// 查询单条记录
        /// </summary>
        Model.Mails_Detail Get(int id);

        /// <summary>
        /// 删除
        /// </summary>
        int Delete(int id);

        /// <summary>
        /// 查询记录条数
        /// </summary>
        long GetCount();


        Model.Mails_Detail GetGuid(string guid);
        

    }
}
