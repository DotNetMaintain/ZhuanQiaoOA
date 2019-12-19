using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Interface
{
    public interface IPaperDownload
    {


        /// <summary>
        /// 新增
        /// </summary>
        int Add(Data.Model.PaperDownload model);

        /// <summary>
        /// 更新
        /// </summary>
        int Update(Data.Model.PaperDownload model);

        /// <summary>
        /// 查询所有记录
        /// </summary>
        List<Data.Model.PaperDownload> GetAll();

        /// <summary>
        /// 查询单条记录
        /// </summary>
        Model.PaperDownload Get(Int32 id);

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
