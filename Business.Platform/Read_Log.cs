using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Platform
{
    public class Read_Log
    {
        /// <summary>
        /// 前缀
        /// </summary>
        public const string PREFIX = "u_";
        private Data.Interface.IRead_Log dataUsers;
        public Read_Log()
        {
            this.dataUsers = Data.Factory.Platform.GetRead_LogInstance();
        }
        /// <summary>
        /// 新增
        /// </summary>
        public int Add(Data.Model.Read_Log model)
        {
            return dataUsers.Add(model);
        }
        /// <summary>
        /// 更新
        /// </summary>
        public int Update(Data.Model.Read_Log model)
        {
            return dataUsers.Update(model);
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.Read_Log> GetAll()
        {
            return dataUsers.GetAll();
        }
        /// <summary>
        /// 查询单条记录
        /// </summary>
        public Data.Model.Read_Log Get(Guid id)
        {
            return dataUsers.Get(id);
        }
        /// <summary>
        /// 删除
        /// </summary>
        public int Delete(Guid id)
        {
            return dataUsers.Delete(id);
        }
        /// <summary>
        /// 查询记录条数
        /// </summary>
        public long GetCount()
        {
            return dataUsers.GetCount();
        }







        /// <summary>
        /// 检查帐号是否重复
        /// </summary>
        /// <param name="account">帐号</param>
        /// <param name="userID">人员ID(此人员除外)</param>
        /// <returns></returns>
        public bool HasRead(string guid, string userid, string table_name)
        {
            return guid.IsNullOrEmpty() ? false : dataUsers.HasRead(guid.Trim(), userid, table_name);
        }


    }
}
