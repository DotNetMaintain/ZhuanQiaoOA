using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.MSSQL
{
    public class Meeting : Data.Interface.IMeeting
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
        public Meeting()
        {
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="model">Data.Model.NoteBook实体类</param>
        /// <returns>操作所影响的行数</returns>
        public int Add(Data.Model.Meeting model)
        {
            string sql = @"INSERT INTO Meeting( guid,UserID,MainTopics,Address,AbsencePerson,Bodys,AddTime) VALUES(@guid,@UserID,@MainTopics,@Address,@AbsencePerson,@Bodys,@AddTime)";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id",SqlDbType.Int,4) { Value = model.id} ,
        new SqlParameter("@guid",SqlDbType.VarChar,100) { Value = model.guid },
        new SqlParameter("@UserID",SqlDbType.VarChar,500) { Value = model.UserID},
        new SqlParameter("@MainTopics",SqlDbType.VarChar,100) { Value = model.MainTopics},
        new SqlParameter("@Address",SqlDbType.VarChar,100) { Value = model.Address},
        new SqlParameter("@AbsencePerson",SqlDbType.VarChar,100) { Value = model.AbsencePerson},
        new SqlParameter("@Bodys",SqlDbType.VarChar,500) { Value = model.Bodys},
        new SqlParameter("@AddTime",SqlDbType.DateTime,8) { Value = model.AddTime}
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model">Data.Model.NoteBook实体类</param>
        public int Update(Data.Model.Meeting model)
        {
            string sql = @"UPDATE Meeting SET  guid = @guid, UserID = @UserID, MainTopics = @MainTopics, Address=@Address, AbsencePerson = @AbsencePerson, Bodys = @Bodys,AddTime = @AddTime		WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id",SqlDbType.Int,4) { Value = model.id} ,
        new SqlParameter("@guid",SqlDbType.VarChar,100) { Value = model.guid },
        new SqlParameter("@UserID",SqlDbType.VarChar,500) { Value = model.UserID},
        new SqlParameter("@MainTopics",SqlDbType.VarChar,100) { Value = model.MainTopics},
        new SqlParameter("@Address",SqlDbType.VarChar,100) { Value = model.Address},
        new SqlParameter("@AbsencePerson",SqlDbType.VarChar,100) { Value = model.AbsencePerson},
        new SqlParameter("@Bodys",SqlDbType.VarChar,500) { Value = model.Bodys},
        new SqlParameter("@AddTime",SqlDbType.DateTime,8) { Value = model.AddTime}

			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        public int Delete(Int32 id)
        {
            string sql = "DELETE FROM Meeting WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id",SqlDbType.Int,-1) { Value =id} 
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 将DataRedar转换为List
        /// </summary>
        private List<Data.Model.Meeting> DataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.Meeting> List = new List<Data.Model.Meeting>();
            Data.Model.Meeting model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.Meeting();
                model.id = dataReader.GetInt32(0);
                model.guid = dataReader.GetString(1);
                model.UserID = dataReader.GetString(2);
                if (!dataReader.IsDBNull(3))
                    model.Bodys = dataReader.GetString(3);

                if (!dataReader.IsDBNull(4))
                    model.MainTopics = dataReader.GetString(4);
                if (!dataReader.IsDBNull(5))
                    model.Address = dataReader.GetString(5);
                if (!dataReader.IsDBNull(6))
                    model.AbsencePerson = dataReader.GetString(6);
               
                model.AddTime = dataReader.GetDateTime(7);

               

               

                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.Meeting> GetAll()
        {
            string sql = "SELECT * from Meeting order by AddTime desc";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.Meeting> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        public long GetCount()
        {
            string sql = "SELECT COUNT(*) FROM Meeting";
            long count;
            return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
        }
        /// <summary>
        /// 根据主键查询一条记录
        /// </summary>
        public Data.Model.Meeting  Get(Int32 id)
        {
            string sql = "SELECT * FROM Meeting WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.Int,4){ Value = id }
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.Meeting> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }

      
    }
}


