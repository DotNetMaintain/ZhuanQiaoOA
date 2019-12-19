using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Platform
{
    public class PaperDownload
    {

        /// <summary>
        /// 前缀
        /// </summary>
        public const string PREFIX = "u_";
        private Data.Interface.IPaperDownload dataNews;
        public PaperDownload()
        {
            this.dataNews = Data.Factory.Platform.GetPaperDownloadInstance();

        }
        /// <summary>
        /// 新增
        /// </summary>
        public int Add(Data.Model.PaperDownload model)
        {
            return dataNews.Add(model);
        }
        /// <summary>
        /// 更新
        /// </summary>
        public int Update(Data.Model.PaperDownload model)
        {
            return dataNews.Update(model);
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.PaperDownload> GetAll()
        {
            return dataNews.GetAll();
        }
        /// <summary>
        /// 查询单条记录
        /// </summary>
        public Data.Model.PaperDownload Get(Int32 id)
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
