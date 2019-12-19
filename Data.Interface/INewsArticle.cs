using System;
using System.Collections.Generic;


namespace Data.Interface
{
    public interface INewsArticle
    {
        /// <summary>
        /// 新增
        /// </summary>
        int Add(Data.Model.NewsArticle model);

        /// <summary>
        /// 更新
        /// </summary>
        int Update(Data.Model.NewsArticle model);

        /// <summary>
        /// 查询所有记录
        /// </summary>
        List<Data.Model.NewsArticle> GetAll();

        /// <summary>
        /// 查询单条记录
        /// </summary>
        Model.NewsArticle Get(Int32 id);

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

