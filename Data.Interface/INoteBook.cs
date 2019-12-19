using System;
using System.Collections.Generic;


namespace Data.Interface
{
    public interface INoteBook
    {
        /// <summary>
        /// 新增
        /// </summary>
        int Add(Data.Model.NoteBook model);

        /// <summary>
        /// 更新
        /// </summary>
        int Update(Data.Model.NoteBook model);

        /// <summary>
        /// 查询所有记录
        /// </summary>
        List<Data.Model.NoteBook> GetAll();

        /// <summary>
        /// 查询单条记录
        /// </summary>
        Model.NoteBook Get(Int32 id);

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


