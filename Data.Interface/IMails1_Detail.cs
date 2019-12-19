using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Interface
{
    public interface IMails1_Detail
    {


        /// <summary>
        /// 新增
        /// </summary>
        int Add(Data.Model.Mails_Detail1 model);

        /// <summary>
        /// 更新
        /// </summary>
        int Update(Data.Model.Mails_Detail1 model);

        /// <summary>
        /// 查询所有记录
        /// </summary>
        List<Data.Model.Mails_Detail1> GetAll();

        /// <summary>
        /// 查询单条记录
        /// </summary>
        Model.Mails_Detail1 Get(Int32 id);

        /// <summary>
        /// 删除
        /// </summary>
        int Delete(Guid id);

        /// <summary>
        /// 查询记录条数
        /// </summary>
        long GetCount();


    }
}
