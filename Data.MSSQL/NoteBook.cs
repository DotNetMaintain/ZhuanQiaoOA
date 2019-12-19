using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.MSSQL
{
    public class NoteBook : Data.Interface.INoteBook
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
        public NoteBook()
        {
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="model">Data.Model.NoteBook实体类</param>
        /// <returns>操作所影响的行数</returns>
        public int Add(Data.Model.NoteBook model)
        {
            string sql = @"INSERT INTO NoteBook( guid,ComID,UserID,RealName,DepName,Subject,Bodys,AddTime) VALUES(@guid,@ComID,@UserID,@RealName,@DepName,@Subject,@Bodys,@AddTime)";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id",SqlDbType.Int,4) { Value = model.id} ,
        new SqlParameter("@guid",SqlDbType.VarChar,100) { Value = model.guid },
        new SqlParameter("@ComID",SqlDbType.Int,4) { Value = model.ComID},
        new SqlParameter("@UserID",SqlDbType.VarChar,500) { Value = model.UserID},
        new SqlParameter("@RealName",SqlDbType.VarChar,100) { Value = model.RealName},
        new SqlParameter("@DepName",SqlDbType.VarChar,100) { Value = model.DepName},
        new SqlParameter("@Subject",SqlDbType.VarChar,100) { Value = model.Subject},
        new SqlParameter("@Bodys",SqlDbType.VarChar,500) { Value = model.Bodys},
        new SqlParameter("@AddTime",SqlDbType.DateTime,8) { Value = model.AddTime}
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model">Data.Model.NoteBook实体类</param>
        public int Update(Data.Model.NoteBook model)
        {
            string sql = @"UPDATE NoteBook SET  guid = @guid, ComID = @ComID, UserID = @UserID, RealName = @RealName, DepName        =@DepName, Subject = @Subject, Bodys = @Bodys,AddTime = @AddTime		WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id",SqlDbType.Int,4) { Value = model.id} ,
        new SqlParameter("@guid",SqlDbType.VarChar,100) { Value = model.guid },
        new SqlParameter("@ComID",SqlDbType.Int,4) { Value = model.ComID},
        new SqlParameter("@UserID",SqlDbType.VarChar,500) { Value = model.UserID},
        new SqlParameter("@RealName",SqlDbType.VarChar,100) { Value = model.RealName},
        new SqlParameter("@DepName",SqlDbType.VarChar,100) { Value = model.DepName},
        new SqlParameter("@Subject",SqlDbType.VarChar,100) { Value = model.Subject},
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
            string sql = "DELETE FROM NoteBook WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id",SqlDbType.Int,4) { Value =id} 
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 将DataRedar转换为List
        /// </summary>
        private List<Data.Model.NoteBook> DataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.NoteBook> List = new List<Data.Model.NoteBook>();
            Data.Model.NoteBook model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.NoteBook();
                model.id = dataReader.GetInt32(0);
                model.guid = dataReader.GetString(1);
                model.ComID = dataReader.GetInt32(2);
                model.UserID = dataReader.GetString(3);

                if (!dataReader.IsDBNull(4))
                    model.RealName = dataReader.GetString(4);
                if (!dataReader.IsDBNull(5))
                    model.DepName = dataReader.GetString(5);
               
                model.AddTime = dataReader.GetDateTime(6);

                if (!dataReader.IsDBNull(7))
                    model.Subject = dataReader.GetString(7);

                if (!dataReader.IsDBNull(8))
                    model.Bodys = dataReader.GetString(8);

                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.NoteBook> GetAll()
        {
            string sql = "SELECT * from NoteBook order by AddTime desc";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.NoteBook> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        public long GetCount()
        {
            string sql = "SELECT COUNT(*) FROM NoteBook";
            long count;
            return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
        }
        /// <summary>
        /// 根据主键查询一条记录
        /// </summary>
        public Data.Model.NoteBook Get(Int32 id)
        {
            string sql = "SELECT * FROM NoteBook WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.Int,4){ Value = id }
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.NoteBook> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }

      
    }
}

