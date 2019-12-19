using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Platform
{
    public class StickyNotes
    {
        /// <summary>
        /// 前缀
        /// </summary>
        public const string PREFIX = "u_";
        private Data.Interface.IStickyNotes dataNews;
        public StickyNotes()
        {
            this.dataNews = Data.Factory.Platform.GetStickyNotesInstance();

        }
        /// <summary>
        /// 新增
        /// </summary>
        public int Add(Data.Model.StickyNotes model)
        {
            return dataNews.Add(model);
        }
        /// <summary>
        /// 更新
        /// </summary>
        public int Update(Data.Model.StickyNotes model)
        {
            return dataNews.Update(model);
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.StickyNotes> GetAll()
        {
            return dataNews.GetAll();
        }
        /// <summary>
        /// 查询单条记录
        /// </summary>
        public Data.Model.StickyNotes Get(Int32 id)
        {
            return dataNews.Get(id);
        }
        /// <summary>
        /// 删除
        /// </summary>
        public int Delete(Guid id)
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



