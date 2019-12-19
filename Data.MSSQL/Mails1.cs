using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.MSSQL
{
    public class Mails1 : Data.Interface.IMails1
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
        public Mails1()
        {
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="model">Data.Model.Users实体类</param>
        /// <returns>操作所影响的行数</returns>
        public int Add(Data.Model.Mails1 model)
        {
            string sql = @"INSERT INTO dbo.Mails_Detail
				(guid,ComID,ReceiverID,SenderID,SenderGUID,SenderRealName,SenderDepName,SendType,Subject,IsRead,FolderType,SendTime,did)
				 VALUES(@guid,@ComID,@ReceiverID,@SenderID,@SenderGUID,@SenderRealName,@SenderDepName,@SendType,@Subject,@IsRead,@FolderType,@SendTime,@did)";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@guid", SqlDbType.VarChar, 50){ Value = model.guid },
				new SqlParameter("@ComID", SqlDbType.Int, -1){ Value = model.ComID },
				new SqlParameter("@ReceiverID", SqlDbType.VarChar, 50){ Value = model.ReceiverID },
				new SqlParameter("@SenderID", SqlDbType.VarChar, 50){ Value = model.SenderID },
				new SqlParameter("@SenderGUID", SqlDbType.VarChar, 50){ Value = model.SenderGUID },
				new SqlParameter("@SenderRealName", SqlDbType.VarChar,500){ Value = model.SenderRealName },
                new SqlParameter("@SenderDepName", SqlDbType.VarChar, 500){ Value = model.SenderDepName },
                new SqlParameter("@SendType", SqlDbType.VarChar, 50){ Value = model.SendType },
                new SqlParameter("@Subject", SqlDbType.VarChar, 500){ Value = model.Subject },
                new SqlParameter("@IsRead", SqlDbType.Int, -1){ Value = model.IsRead },
                new SqlParameter("@FolderType", SqlDbType.Int, -1){ Value = model.FolderType },
                new SqlParameter("@SendTime", SqlDbType.DateTime){ Value = model.SendTime },
                new SqlParameter("@did", SqlDbType.Int, -1){ Value = model.did }
				
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model">Data.Model.Users实体类</param>
        public int Update(Data.Model.Mails1 model)
        {
            string sql = @"UPDATE Mails_Detail SET 
				guid=@guid,ComID=@ComID,ReceiverID=@ReceiverID,SenderID=@SenderID,SenderGUID=@SenderGUID,SenderRealName=@SenderRealName,
             SenderDepName=@SenderDepName,SendType=@SendType,Subject=@Subject,IsRead=@IsRead,FolderType=@FolderType,SendTime=@SendTime,did=@did
				WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.Int, -1){ Value = model.ID },
				new SqlParameter("@guid", SqlDbType.VarChar, 50){ Value = model.guid },
				new SqlParameter("@ComID", SqlDbType.Int, -1){ Value = model.ComID },
				new SqlParameter("@ReceiverID", SqlDbType.VarChar, 50){ Value = model.ReceiverID },
				new SqlParameter("@SenderID", SqlDbType.VarChar, 50){ Value = model.SenderID },
				new SqlParameter("@SenderGUID", SqlDbType.VarChar, 50){ Value = model.SenderGUID },
				new SqlParameter("@SenderRealName", SqlDbType.VarChar,500){ Value = model.SenderRealName },
                new SqlParameter("@SenderDepName", SqlDbType.VarChar, 500){ Value = model.SenderDepName },
                new SqlParameter("@SendType", SqlDbType.VarChar, 50){ Value = model.SendType },
                new SqlParameter("@Subject", SqlDbType.VarChar, 500){ Value = model.Subject },
                new SqlParameter("@IsRead", SqlDbType.Int, -1){ Value = model.IsRead },
                new SqlParameter("@FolderType", SqlDbType.Int, -1){ Value = model.FolderType },
                new SqlParameter("@SendTime", SqlDbType.DateTime){ Value = model.SendTime },
                new SqlParameter("@did", SqlDbType.Int, -1){ Value = model.did }
				
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        public int Delete(Guid id)
        {
            string sql = "DELETE FROM dbo.Mails WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@ID", SqlDbType.Int, -1){ Value = id}
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 将DataRedar转换为List
        /// </summary>
        private List<Data.Model.Mails1> DataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.Mails1> List = new List<Data.Model.Mails1>();
            Data.Model.Mails1 model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.Mails1();
                model.ID = dataReader.GetInt32(0);
                model.guid = dataReader.GetString(1);
                model.ComID = dataReader.GetInt32(2);
                if (!dataReader.IsDBNull(3))
                    model.ReceiverID = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4))
                    model.SenderID = dataReader.GetString(4);
                if (!dataReader.IsDBNull(5))
                    model.SenderGUID = dataReader.GetString(5);
                if (!dataReader.IsDBNull(6))
                    model.SenderRealName = dataReader.GetString(6);
                if (!dataReader.IsDBNull(7))
                    model.SenderDepName = dataReader.GetString(7);
                if (!dataReader.IsDBNull(8))
                    model.SendType = dataReader.GetString(8);
                if (!dataReader.IsDBNull(9))
                    model.Subject = dataReader.GetString(9);
                if (!dataReader.IsDBNull(10))
                    model.IsRead = dataReader.GetInt32(10);
                if (!dataReader.IsDBNull(11))
                    model.FolderType = dataReader.GetInt32(11);
                if (!dataReader.IsDBNull(12))
                    model.SendTime = dataReader.GetDateTime(12);
                if (!dataReader.IsDBNull(13))
                    model.did = dataReader.GetInt32(13);
               
                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.Mails1> GetAll()
        {
            string sql = "SELECT * FROM Mails";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.Mails1> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        public long GetCount()
        {
            string sql = "SELECT COUNT(*) FROM Mails";
            long count;
            return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
        }
        /// <summary>
        /// 根据主键查询一条记录
        /// </summary>
        public Data.Model.Mails1 Get(Int32 id)
        {
            string sql = "SELECT * FROM Mails WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.Int,-1){ Value = id }
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.Mails1> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }

      
    }
}
