using System;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface INews
    {
        /// <summary>
        /// 新增
        /// </summary>
        int Add(Data.Model.News model);

        /// <summary>
        /// 更新
        /// </summary>
        int Update(Data.Model.News model);

        /// <summary>
        /// 查询所有记录
        /// </summary>
        List<Data.Model.News> GetAll();

        /// <summary>
        /// 查询单条记录
        /// </summary>
        Model.News Get(Int32 id);

        /// <summary>
        /// 删除
        /// </summary>
        int Delete(Int32 id);

        /// <summary>
        /// 查询记录条数
        /// </summary>
        long GetCount();




    }
}

