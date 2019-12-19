using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.MSSQL
{
    public class Mails_Detail : Data.Interface.IMails_Detail
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
        public Mails_Detail()
        {
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="model">Data.Model.Mails_Detail实体类</param>
        /// <returns>新增记录的ID</returns>
        public int Add(Data.Model.Mails_Detail model)
        {
            string sql = @"INSERT INTO dbo.Mails_Detail
				(guid,ComID,ReceiveIDs,CcIDs,BccIDs,Bodys,Attachments) 
				VALUES(@guid,@ComID,@ReceiverID,@CCIDs,@BccIDs,@body,@fileattech);
				SELECT SCOPE_IDENTITY();";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@guid", SqlDbType.NVarChar, 100){ Value = model.Guid },
				model.ComID == null ? new SqlParameter("@ComID", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@ComID", SqlDbType.Int, -1) { Value = model.ComID },
				model.ReceiveIDs == null ? new SqlParameter("@ReceiverID", SqlDbType.NVarChar, -1) { Value = DBNull.Value } : new SqlParameter("@ReceiverID", SqlDbType.NVarChar, -1) { Value = model.ReceiveIDs },
				model.CcIDs == null ? new SqlParameter("@CCIDs", SqlDbType.NVarChar, -1) { Value = DBNull.Value } : new SqlParameter("@CCIDs", SqlDbType.NVarChar, -1) { Value = model.CcIDs },
				model.BccIDs == null ? new SqlParameter("@BccIDs", SqlDbType.NVarChar, -1) { Value = DBNull.Value } : new SqlParameter("@BccIDs", SqlDbType.NVarChar, -1) { Value = model.BccIDs },
				model.Bodys == null ? new SqlParameter("@body", SqlDbType.Text, -1) { Value = DBNull.Value } : new SqlParameter("@body", SqlDbType.Text, -1) { Value = model.Bodys },
				model.Attachments == null ? new SqlParameter("@fileattech", SqlDbType.NVarChar, -1) { Value = DBNull.Value } : new SqlParameter("@fileattech", SqlDbType.NVarChar, -1) { Value = model.Attachments }
			};
            int maxID;
            return int.TryParse(dbHelper.ExecuteScalar(sql, parameters), out maxID) ? maxID : -1;
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model">Data.Model.Mails_Detail实体类</param>
        public int Update(Data.Model.Mails_Detail model)
        {
            string sql = @"UPDATE dbo.Mails_Detail SET 
	guid=@guid,ComID=@ComID,ReceiveIDs=@ReceiverID,CcIDs=@CCIDs,BccIDs=@BccIDs,Bodys=@body,Attachments=@fileattech
				WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@guid", SqlDbType.NVarChar, 100){ Value = model.Guid },
				model.ComID == null ? new SqlParameter("@ComID", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@ComID", SqlDbType.Int, -1) { Value = model.ComID },
				model.ReceiveIDs == null ? new SqlParameter("@ReceiverID", SqlDbType.NVarChar, 100) { Value = DBNull.Value } : new SqlParameter("@ReceiverID", SqlDbType.NVarChar, 100) { Value = model.ReceiveIDs },
				model.CcIDs == null ? new SqlParameter("@CCIDs", SqlDbType.NVarChar, -1) { Value = DBNull.Value } : new SqlParameter("@CCIDs", SqlDbType.NVarChar, -1) { Value = model.CcIDs },
				model.BccIDs == null ? new SqlParameter("@BccIDs", SqlDbType.NVarChar, -1) { Value = DBNull.Value } : new SqlParameter("@BccIDs", SqlDbType.NVarChar, -1) { Value = model.BccIDs },
				model.Bodys == null ? new SqlParameter("@body", SqlDbType.Text, -1) { Value = DBNull.Value } : new SqlParameter("@body", SqlDbType.Text, -1) { Value = model.Bodys },
				model.Attachments == null ? new SqlParameter("@fileattech", SqlDbType.NVarChar, -1) { Value = DBNull.Value } : new SqlParameter("@fileattech", SqlDbType.NVarChar, -1) { Value = model.Attachments },
				new SqlParameter("@id", SqlDbType.Int, -1){ Value = model.Id }
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        public int Delete(int id)
        {
            string sql = "DELETE FROM dbo.Mails_Detail WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id", SqlDbType.Int){ Value = id }
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 将DataRedar转换为List
        /// </summary>
        private List<Data.Model.Mails_Detail> DataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.Mails_Detail> List = new List<Data.Model.Mails_Detail>();
            Data.Model.Mails_Detail model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.Mails_Detail();
                model.Id = dataReader.GetInt32(0);
                model.Guid = dataReader.GetString(1);
                if (!dataReader.IsDBNull(2))
                    model.ComID = dataReader.GetInt32(2);
                if (!dataReader.IsDBNull(3))
                    model.ReceiveIDs = dataReader.GetString(3);
                if (!dataReader.IsDBNull(5))
                    model.CcIDs = dataReader.GetString(5);
                if (!dataReader.IsDBNull(7))
                    model.BccIDs = dataReader.GetString(7);
                if (!dataReader.IsDBNull(9))
                    model.Bodys = dataReader.GetString(9);
                if (!dataReader.IsDBNull(10))
                    model.Attachments = dataReader.GetString(10);
                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.Mails_Detail> GetAll()
        {
            string sql = "SELECT * FROM dbo.Mails_Detail";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.Mails_Detail> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        public long GetCount()
        {
            string sql = "SELECT COUNT(*) FROM dbo.Mails_Detail";
            long count;
            return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
        }
        /// <summary>
        /// 根据主键查询一条记录
        /// </summary>
        public Data.Model.Mails_Detail Get(int id)
        {
            string sql = "SELECT * FROM dbo.Mails_Detail WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id", SqlDbType.Int){ Value = id }
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.Mails_Detail> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }



        public Data.Model.Mails_Detail GetGuid(string guid)
        {
            string sql = "SELECT * FROM dbo.Mails_Detail WHERE guid=@guid";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@guid", SqlDbType.NVarChar, 100){ Value = guid }
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.Mails_Detail> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }

    }
}