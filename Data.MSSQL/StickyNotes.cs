using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.MSSQL
{
    public class StickyNotes : Data.Interface.IStickyNotes
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
        public StickyNotes()
        {
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="model">Data.Model.NoteBook实体类</param>
        /// <returns>操作所影响的行数</returns>
        public int Add(Data.Model.StickyNotes model)
        {
            string sql = @"INSERT INTO StickyNotes( guid,ComID,UserID,Bodys,AddTime) VALUES(@guid,@ComID,@UserID,@Bodys,@AddTime)";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id",SqlDbType.Int,4) { Value = model.id} ,
        new SqlParameter("@guid",SqlDbType.VarChar,100) { Value = model.guid },
        new SqlParameter("@ComID",SqlDbType.Int,4) { Value = model.ComID},
        new SqlParameter("@UserID",SqlDbType.VarChar,500) { Value = model.UserID},
        new SqlParameter("@Bodys",SqlDbType.VarChar,500) { Value = model.Bodys},
        new SqlParameter("@AddTime",SqlDbType.DateTime,8) { Value = model.AddTime}
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model">Data.Model.NoteBook实体类</param>
        public int Update(Data.Model.StickyNotes model)
        {
            string sql = @"UPDATE StickyNotes SET  guid = @guid, ComID = @ComID, UserID = @UserID, Bodys = @Bodys,AddTime = @AddTime		WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id",SqlDbType.Int,4) { Value = model.id} ,
        new SqlParameter("@guid",SqlDbType.VarChar,100) { Value = model.guid },
        new SqlParameter("@ComID",SqlDbType.Int,4) { Value = model.ComID},
        new SqlParameter("@UserID",SqlDbType.VarChar,500) { Value = model.UserID},
        new SqlParameter("@Bodys",SqlDbType.VarChar,500) { Value = model.Bodys},
        new SqlParameter("@AddTime",SqlDbType.DateTime,8) { Value = model.AddTime}

			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        public int Delete(Guid id)
        {
            string sql = "DELETE FROM StickyNotes WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id",SqlDbType.Int,4) { Value =id} 
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 将DataRedar转换为List
        /// </summary>
        private List<Data.Model.StickyNotes> DataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.StickyNotes> List = new List<Data.Model.StickyNotes>();
            Data.Model.StickyNotes model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.StickyNotes();
                model.id = dataReader.GetInt32(0);
                model.guid = dataReader.GetString(1);
                model.ComID = dataReader.GetInt32(2);
                model.UserID = dataReader.GetString(3);
                model.AddTime = dataReader.GetDateTime(4);
                if (!dataReader.IsDBNull(5))
                    model.Bodys = dataReader.GetString(5);

                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.StickyNotes> GetAll()
        {
            string sql = "SELECT * from StickyNotes order by AddTime desc";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.StickyNotes> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        public long GetCount()
        {
            string sql = "SELECT COUNT(*) FROM StickyNotes";
            long count;
            return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
        }
        /// <summary>
        /// 根据主键查询一条记录
        /// </summary>
        public Data.Model.StickyNotes Get(Int32 id)
        {
            string sql = "SELECT * FROM StickyNotes WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.Int,4){ Value = id }
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.StickyNotes> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }

      
    }
}


