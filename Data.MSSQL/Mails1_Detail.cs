using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.MSSQL
{
    public class Mails1_Detail : Data.Interface.IMails1_Detail
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
        public Mails1_Detail()
        {
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="model">Data.Model.Users实体类</param>
        /// <returns>操作所影响的行数</returns>
        public int Add(Data.Model.Mails_Detail1 model)
        {
            string sql = @"INSERT INTO dbo.Mails_Detail
				(guid,ComID,SendIDs,SendRealNames,CcIDs,CcRealNames,BccIDs,BccRealNames,Bodys,Attachments) 
				VALUES(@guid,@ComID,@SendIDs,@SendRealNames,@CcIDs,@CcRealNames,@BccIDs,@BccRealNames,@Bodys,@Attachments)";
            SqlParameter[] parameters = new SqlParameter[]{
				
				new SqlParameter("@guid", SqlDbType.NVarChar, 500){ Value = model.guid  },
				new SqlParameter("@ComID", SqlDbType.Int, -1){ Value = model.ComID  },
				new SqlParameter("@SendIDs", SqlDbType.Text){ Value = model.SendIDs  },
				new SqlParameter("@SendRealNames", SqlDbType.Text){ Value = model.SendRealNames },
				new SqlParameter("@CcIDs", SqlDbType.Text){ Value = model.SendRealNames },
                new SqlParameter("@CcRealNames", SqlDbType.Text){ Value = model.CcIDs },
				new SqlParameter("@BccIDs", SqlDbType.Text){ Value = model.CcRealNames },
                new SqlParameter("@BccRealNames", SqlDbType.Text){ Value = model.BccRealNames },
                new SqlParameter("@Bodys", SqlDbType.Text){ Value = model.Bodys },
                new SqlParameter("@Attachments", SqlDbType.Text){ Value = model.Attachments }
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model">Data.Model.Users实体类</param>
        public int Update(Data.Model.Mails_Detail1 model)
        {
            string sql = @"UPDATE Mails_Detail SET 
				guid=@guid,ComID=@ComID,SendIDs=@SendIDs,SendRealNames=@SendRealNames,CcIDs=@CcIDs,CcRealNames=@CcRealNames,BccIDs=@BccIDs,BccRealNames=@BccRealNames,Bodys=@Bodys,Attachments=@Attachments
				WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@ID", SqlDbType.Int, -1){ Value = model.ID  },
				new SqlParameter("@guid", SqlDbType.NVarChar, 500){ Value = model.guid  },
				new SqlParameter("@ComID", SqlDbType.Int, -1){ Value = model.ComID  },
				new SqlParameter("@SendIDs", SqlDbType.Text){ Value = model.SendIDs  },
				new SqlParameter("@SendRealNames", SqlDbType.Text){ Value = model.SendRealNames },
				new SqlParameter("@CcIDs", SqlDbType.Text){ Value = model.CcIDs },
                new SqlParameter("@CcRealNames", SqlDbType.Text){ Value = model.CcRealNames },
				new SqlParameter("@BccIDs", SqlDbType.Text){ Value = model.BccIDs },
                new SqlParameter("@BccRealNames", SqlDbType.Text){ Value = model.BccRealNames },
                new SqlParameter("@Bodys", SqlDbType.Text){ Value = model.Bodys },
                new SqlParameter("@Attachments", SqlDbType.Text){ Value = model.Attachments }
				
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        public int Delete(Guid id)
        {
            string sql = "DELETE FROM Mails_Detail WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.Int, -1){ Value = id  }
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 将DataRedar转换为List
        /// </summary>
        private List<Data.Model.Mails_Detail1> DataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.Mails_Detail1> List = new List<Data.Model.Mails_Detail1>();
            Data.Model.Mails_Detail1 model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.Mails_Detail1();
                model.ID = dataReader.GetInt32(0);
                model.guid = dataReader.GetString(1);
                model.ComID = dataReader.GetInt32(2);
                if (!dataReader.IsDBNull(3))
                    model.SendIDs = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4))
                    model.SendRealNames = dataReader.GetString(4);
                if (!dataReader.IsDBNull(5))
                    model.CcIDs = dataReader.GetString(5);
                if (!dataReader.IsDBNull(6))
                    model.CcRealNames = dataReader.GetString(6);
                if (!dataReader.IsDBNull(7))
                    model.BccIDs = dataReader.GetString(7);
                if (!dataReader.IsDBNull(8))
                    model.BccRealNames = dataReader.GetString(8);
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
        public List<Data.Model.Mails_Detail1> GetAll()
        {
            string sql = "SELECT * FROM Mails_Detail";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.Mails_Detail1> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        public long GetCount()
        {
            string sql = "SELECT COUNT(*) FROM Mails_Detail";
            long count;
            return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
        }
        /// <summary>
        /// 根据主键查询一条记录
        /// </summary>
        public Data.Model.Mails_Detail1 Get(Int32 id)
        {
            string sql = "SELECT * FROM Mails_Detail WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier){ Value = id }
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.Mails_Detail1> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }

      
    }
}
