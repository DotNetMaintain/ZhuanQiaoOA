using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.MSSQL
{
    public class Read_Log : Data.Interface.IRead_Log
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
        public Read_Log()
        {
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="model">Data.Model.Users实体类</param>
        /// <returns>操作所影响的行数</returns>
        public int Add(Data.Model.Read_Log model)
        {
            string sql = @"INSERT INTO dbo.Read_Log
				(ID,guid,userid,table_name,modify_date) 
				VALUES(@ID,@guid,@userid,@table_name,@modify_date)";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1){ Value = model.id },
				new SqlParameter("@guid", SqlDbType.NVarChar, 100){ Value = model.guid },
				new SqlParameter("@userid", SqlDbType.VarChar, 255){ Value = model.userid },
				new SqlParameter("@table_name", SqlDbType.VarChar, 500){ Value = model.table_name},
                new SqlParameter("@modify_date", SqlDbType.DateTime){ Value = model.modify_date }

			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model">Data.Model.Users实体类</param>
        public int Update(Data.Model.Read_Log model)
        {
            string sql = @"UPDATE Read_Log SET 
				guid=@guid,userid=@userid,table_name=@table_name
				WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@guid", SqlDbType.NVarChar, 100){ Value = model.guid },
				new SqlParameter("@userid", SqlDbType.VarChar, 255){ Value = model.userid },
				new SqlParameter("@table_name", SqlDbType.VarChar, 500){ Value = model.table_name }
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        public int Delete(Guid id)
        {
            string sql = "DELETE FROM Read_Log WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier){ Value = id }
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 将DataRedar转换为List
        /// </summary>
        private List<Data.Model.Read_Log> DataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.Read_Log> List = new List<Data.Model.Read_Log>();
            Data.Model.Read_Log model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.Read_Log();
                model.id = dataReader.GetGuid(0);
                model.guid = dataReader.GetString(1);
                model.userid = dataReader.GetString(2);
                model.table_name = dataReader.GetString(3);
               List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.Read_Log> GetAll()
        {
            string sql = "SELECT * FROM Read_Log";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.Read_Log> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        public long GetCount()
        {
            string sql = "SELECT COUNT(*) FROM Read_Log";
            long count;
            return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
        }
        /// <summary>
        /// 根据主键查询一条记录
        /// </summary>
        public Data.Model.Read_Log Get(Guid id)
        {
            string sql = "SELECT * FROM Read_Log WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier){ Value = id }
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.Read_Log> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }

       

       
    
        /// <summary>
        /// 检查帐号是否重复
        /// </summary>
        /// <param name="account">帐号</param>
        /// <param name="userID">人员ID(此人员除外)</param>
        /// <returns></returns>
        public bool HasRead(string guid,string userid,string table_name)
        {
            string sql = "SELECT ID FROM Read_Log WHERE guid=@guid and userid=@userid and table_name=@table_name";
            List<SqlParameter> plist = new List<SqlParameter>();
             SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@guid", SqlDbType.NVarChar, 100){ Value = guid },
				new SqlParameter("@userid", SqlDbType.VarChar, 255){ Value = userid },
				new SqlParameter("@table_name", SqlDbType.VarChar, 500){ Value = table_name }
			};


             SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            bool flag = dataReader.HasRows;
            dataReader.Close();
            return flag;
        }
        
    }
}