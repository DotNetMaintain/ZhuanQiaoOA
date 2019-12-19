using System;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface IRead_Log
    {
        /// <summary>
        /// 新增
        /// </summary>
        int Add(Data.Model.Read_Log model);

        /// <summary>
        /// 更新
        /// </summary>
        int Update(Data.Model.Read_Log model);

        /// <summary>
        /// 查询所有记录
        /// </summary>
        List<Data.Model.Read_Log> GetAll();

        /// <summary>
        /// 查询单条记录
        /// </summary>
        Model.Read_Log Get(Guid id);

        /// <summary>
        /// 删除
        /// </summary>
        int Delete(Guid id);

        /// <summary>
        /// 查询记录条数
        /// </summary>
        long GetCount();

        

        /// <summary>
        /// 检查帐号是否重复
        /// </summary>
        /// <param name="account">帐号</param>
        /// <param name="userID">人员ID(此人员除外)</param>
        /// <returns></returns>
        bool HasRead(string guid, string userid, string table_name);

       
    }
}
