using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Platform
{
    public class NewsArticle
    {
        /// <summary>
        /// 前缀
        /// </summary>
        public const string PREFIX = "u_";
        private Data.Interface.INewsArticle dataNews;
        public NewsArticle()
        {
            this.dataNews = Data.Factory.Platform.GetNewsArticleInstance();
        }
        /// <summary>
        /// 新增
        /// </summary>
        public int Add(Data.Model.NewsArticle model)
        {
            return dataNews.Add(model);
        }
        /// <summary>
        /// 更新
        /// </summary>
        public int Update(Data.Model.NewsArticle model)
        {
            return dataNews.Update(model);
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.NewsArticle> GetAll()
        {
            return dataNews.GetAll();
        }
        /// <summary>
        /// 查询单条记录
        /// </summary>
        public Data.Model.NewsArticle Get(Int32 id)
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


    }
}


