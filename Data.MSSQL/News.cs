using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.MSSQL
{
    public class News : Data.Interface.INews
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
        public News()
        {
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="model">Data.Model.Users实体类</param>
        /// <returns>操作所影响的行数</returns>
        public int Add(Data.Model.News model)
        {
            string sql = @"INSERT INTO TempTest_News
				(ID,Title,Title1,UserID,Type,Contents,State) 
				VALUES(@ID,@Title,@Title1,@UserID,@Type,@Contents,@State)";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1){ Value = model.ID },
				new SqlParameter("@Title", SqlDbType.NVarChar, 500){ Value = model.Title },
				new SqlParameter("@Title1", SqlDbType.VarChar, 50){ Value = model.Title1 },
				new SqlParameter("@UserID", SqlDbType.VarChar, 50){ Value = model.UserID },
				new SqlParameter("@Type", SqlDbType.VarChar, 50){ Value = model.Type },
				new SqlParameter("@Contents", SqlDbType.Text){ Value = model.Contents },
                new SqlParameter("@State", SqlDbType.Int, -1){ Value = model.State }
				
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model">Data.Model.Users实体类</param>
        public int Update(Data.Model.News model)
        {
            string sql = @"UPDATE TempTest_News SET 
				Title=@Title,Title1=@Title1,UserID=@UserID,Type=@Type,Contents=@Contents,State=@State
				WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.Int, -1){ Value = model.ID },
				new SqlParameter("@Title", SqlDbType.NVarChar, 500){ Value = model.Title },
				new SqlParameter("@Title1", SqlDbType.VarChar, 50){ Value = model.Title1 },
				new SqlParameter("@UserID", SqlDbType.VarChar, 50){ Value = model.UserID },
				new SqlParameter("@Type", SqlDbType.VarChar, 50){ Value = model.Type },
				new SqlParameter("@Contents", SqlDbType.Text){ Value = model.Contents },
                new SqlParameter("@State", SqlDbType.Int, -1){ Value = model.State }
				
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        public int Delete(Int32 id)
        {
            string sql = "DELETE FROM TempTest_News WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.Int ,-1){ Value = id }
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 将DataRedar转换为List
        /// </summary>
        private List<Data.Model.News> DataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.News> List = new List<Data.Model.News>();
            Data.Model.News model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.News();
                model.ID = dataReader.GetInt32(0);
                model.Title = dataReader.GetString(1);
                model.Title1 = dataReader.GetString(2);
                if (!dataReader.IsDBNull(3))
                    model.UserID = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4))
                    model.Type = dataReader.GetString(4);
                if (!dataReader.IsDBNull(5))
                    model.Contents = dataReader.GetString(5);
                model.State = dataReader.GetInt32(6);
                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.News> GetAll()
        {
            string sql = "SELECT * FROM TempTest_News";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.News> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        public long GetCount()
        {
            string sql = "SELECT COUNT(*) FROM TempTest_News";
            long count;
            return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
        }
        /// <summary>
        /// 根据主键查询一条记录
        /// </summary>
        public Data.Model.News Get(Int32 id)
        {
            string sql = "SELECT * FROM TempTest_News WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier){ Value = id }
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.News> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }

      
    }
}
