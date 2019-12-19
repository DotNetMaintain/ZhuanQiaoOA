using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.MSSQL
{
    public class Mails : Data.Interface.IMails
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
        public Mails()
        {
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="model">Data.Model.Mails实体类</param>
        /// <returns>新增记录的ID</returns>
        public int Add(Data.Model.Mails model)
        {
            string sql = @"INSERT INTO Mails
				(guid,ComID,ReceiverID,SenderIDs,CCIDs,BccIDs,SenderGUID,SenderRealName,SenderDepName,SendType,Subject,IsRead,FolderType,SendTime,did,body,fileattech) 
				VALUES(@guid,@ComID,@ReceiverID,@SenderIDs,@CCIDs,@BccIDs,@SenderGUID,@SenderRealName,@SenderDepName,@SendType,@Subject,@IsRead,@FolderType,@SendTime,@did,@body,@fileattech);
				SELECT SCOPE_IDENTITY();";
            SqlParameter[] parameters = new SqlParameter[]{
                model.guid == null ? new SqlParameter("@guid", SqlDbType.NVarChar, 100) { Value = DBNull.Value } : new SqlParameter("@guid", SqlDbType.NVarChar, 100) { Value = model.guid },
				model.ComID == null ? new SqlParameter("@ComID", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@ComID", SqlDbType.Int, -1) { Value = model.ComID },
				model.ReceiverID == null ? new SqlParameter("@ReceiverID", SqlDbType.NVarChar,-1) { Value = DBNull.Value } : new SqlParameter("@ReceiverID", SqlDbType.NVarChar, -1) { Value = model.ReceiverID },
				model.SenderIDs == null ? new SqlParameter("@SenderIDs", SqlDbType.NVarChar, -1) { Value = DBNull.Value } : new SqlParameter("@SenderIDs", SqlDbType.NVarChar, -1) { Value = model.SenderIDs },
				model.CCIDs == null ? new SqlParameter("@CCIDs", SqlDbType.NVarChar, -1) { Value = DBNull.Value } : new SqlParameter("@CCIDs", SqlDbType.NVarChar, -1) { Value = model.CCIDs },
				model.BccIDs == null ? new SqlParameter("@BccIDs", SqlDbType.NVarChar, -1) { Value = DBNull.Value } : new SqlParameter("@BccIDs", SqlDbType.NVarChar, -1) { Value = model.BccIDs },
				model.SenderGUID == null ? new SqlParameter("@SenderGUID", SqlDbType.NVarChar, 100) { Value = DBNull.Value } : new SqlParameter("@SenderGUID", SqlDbType.NVarChar, 100) { Value = model.SenderGUID },
				model.SenderRealName == null ? new SqlParameter("@SenderRealName", SqlDbType.NVarChar, 100) { Value = DBNull.Value } : new SqlParameter("@SenderRealName", SqlDbType.NVarChar, 100) { Value = model.SenderRealName },
				model.SenderDepName == null ? new SqlParameter("@SenderDepName", SqlDbType.NVarChar, 100) { Value = DBNull.Value } : new SqlParameter("@SenderDepName", SqlDbType.NVarChar, 100) { Value = model.SenderDepName },
				model.SendType == null ? new SqlParameter("@SendType", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@SendType", SqlDbType.Int, -1) { Value = model.SendType },
				model.Subject == null ? new SqlParameter("@Subject", SqlDbType.NVarChar, 1000) { Value = DBNull.Value } : new SqlParameter("@Subject", SqlDbType.NVarChar, 1000) { Value = model.Subject },
				model.IsRead == null ? new SqlParameter("@IsRead", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@IsRead", SqlDbType.Int, -1) { Value = model.IsRead },
				model.FolderType == null ? new SqlParameter("@FolderType", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@FolderType", SqlDbType.Int, -1) { Value = model.FolderType },
				model.SendTime == null ? new SqlParameter("@SendTime", SqlDbType.DateTime, 8) { Value = DBNull.Value } : new SqlParameter("@SendTime", SqlDbType.DateTime, 8) { Value = model.SendTime },
				new SqlParameter("@did", SqlDbType.Int, -1){ Value = model.did },
				model.body == null ? new SqlParameter("@body", SqlDbType.Text, -1) { Value = DBNull.Value } : new SqlParameter("@body", SqlDbType.Text, -1) { Value = model.body },
				model.fileattech == null ? new SqlParameter("@fileattech", SqlDbType.NVarChar, -1) { Value = DBNull.Value } : new SqlParameter("@fileattech", SqlDbType.NVarChar, -1) { Value = model.fileattech }
			};
            int maxID;
            return int.TryParse(dbHelper.ExecuteScalar(sql, parameters), out maxID) ? maxID : -1;
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model">Data.Model.Mails实体类</param>
        public int Update(Data.Model.Mails model)
        {
            string sql = @"UPDATE Mails SET 
				guid=@guid,ComID=@ComID,ReceiverID=@ReceiverID,SenderIDs=@SenderIDs,CCIDs=@CCIDs,BccIDs=@BccIDs,SenderGUID=@SenderGUID,SenderRealName=@SenderRealName,SenderDepName=@SenderDepName,SendType=@SendType,Subject=@Subject,IsRead=@IsRead,FolderType=@FolderType,SendTime=@SendTime,did=@did,body=@body,fileattech=@fileattech
				WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{

            model.guid == null ? new SqlParameter("@guid", SqlDbType.NVarChar, 100) { Value = DBNull.Value } : new SqlParameter("@guid", SqlDbType.NVarChar, 100) { Value = model.guid },
				model.ComID == null ? new SqlParameter("@ComID", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@ComID", SqlDbType.Int, -1) { Value = model.ComID },
				model.ReceiverID == null ? new SqlParameter("@ReceiverID", SqlDbType.NVarChar, 100) { Value = DBNull.Value } : new SqlParameter("@ReceiverID", SqlDbType.NVarChar, 100) { Value = model.ReceiverID },
				model.SenderIDs == null ? new SqlParameter("@SenderIDs", SqlDbType.NVarChar, -1) { Value = DBNull.Value } : new SqlParameter("@SenderIDs", SqlDbType.NVarChar, -1) { Value = model.SenderIDs },
				model.CCIDs == null ? new SqlParameter("@CCIDs", SqlDbType.NVarChar, -1) { Value = DBNull.Value } : new SqlParameter("@CCIDs", SqlDbType.NVarChar, -1) { Value = model.CCIDs },
				model.BccIDs == null ? new SqlParameter("@BccIDs", SqlDbType.NVarChar, -1) { Value = DBNull.Value } : new SqlParameter("@BccIDs", SqlDbType.NVarChar, -1) { Value = model.BccIDs },
				model.SenderGUID == null ? new SqlParameter("@SenderGUID", SqlDbType.NVarChar, 100) { Value = DBNull.Value } : new SqlParameter("@SenderGUID", SqlDbType.NVarChar, 100) { Value = model.SenderGUID },
				model.SenderRealName == null ? new SqlParameter("@SenderRealName", SqlDbType.NVarChar, 100) { Value = DBNull.Value } : new SqlParameter("@SenderRealName", SqlDbType.NVarChar, 100) { Value = model.SenderRealName },
				model.SenderDepName == null ? new SqlParameter("@SenderDepName", SqlDbType.NVarChar, 100) { Value = DBNull.Value } : new SqlParameter("@SenderDepName", SqlDbType.NVarChar, 100) { Value = model.SenderDepName },
				model.SendType == null ? new SqlParameter("@SendType", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@SendType", SqlDbType.Int, -1) { Value = model.SendType },
				model.Subject == null ? new SqlParameter("@Subject", SqlDbType.NVarChar, 1000) { Value = DBNull.Value } : new SqlParameter("@Subject", SqlDbType.NVarChar, 1000) { Value = model.Subject },
				model.IsRead == null ? new SqlParameter("@IsRead", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@IsRead", SqlDbType.Int, -1) { Value = model.IsRead },
				model.FolderType == null ? new SqlParameter("@FolderType", SqlDbType.Int, -1) { Value = DBNull.Value } : new SqlParameter("@FolderType", SqlDbType.Int, -1) { Value = model.FolderType },
				model.SendTime == null ? new SqlParameter("@SendTime", SqlDbType.DateTime, 8) { Value = DBNull.Value } : new SqlParameter("@SendTime", SqlDbType.DateTime, 8) { Value = model.SendTime },
				new SqlParameter("@did", SqlDbType.Int, -1){ Value = model.did },
				model.body == null ? new SqlParameter("@body", SqlDbType.Text, -1) { Value = DBNull.Value } : new SqlParameter("@body", SqlDbType.Text, -1) { Value = model.body },
				model.fileattech == null ? new SqlParameter("@fileattech", SqlDbType.NVarChar, -1) { Value = DBNull.Value } : new SqlParameter("@fileattech", SqlDbType.NVarChar, -1) { Value = model.fileattech },
				new SqlParameter("@id", SqlDbType.Int, -1){ Value = model.id }
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        public int Delete(int id)
        {
            string sql = "DELETE FROM Mails WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id", SqlDbType.Int){ Value = id }
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 将DataRedar转换为List
        /// </summary>
        private List<Data.Model.Mails> DataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.Mails> List = new List<Data.Model.Mails>();
            Data.Model.Mails model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.Mails();
                model.id = dataReader.GetInt32(0);
                if (!dataReader.IsDBNull(1))
                     model.guid = dataReader.GetString(1);
                if (!dataReader.IsDBNull(2))
                    model.ComID = dataReader.GetInt32(2);
                if (!dataReader.IsDBNull(3))
                    model.ReceiverID = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4))
                    model.SenderIDs = dataReader.GetString(4);
                if (!dataReader.IsDBNull(5))
                    model.CCIDs = dataReader.GetString(5);
                if (!dataReader.IsDBNull(6))
                    model.BccIDs = dataReader.GetString(6);
                if (!dataReader.IsDBNull(7))
                    model.SenderGUID = dataReader.GetString(7);
                if (!dataReader.IsDBNull(8))
                    model.SenderRealName = dataReader.GetString(8);
                if (!dataReader.IsDBNull(9))
                    model.SenderDepName = dataReader.GetString(9);
                if (!dataReader.IsDBNull(10))
                    model.SendType = dataReader.GetInt32(10);
                if (!dataReader.IsDBNull(11))
                    model.Subject = dataReader.GetString(11);
                if (!dataReader.IsDBNull(12))
                    model.IsRead = dataReader.GetInt32(12);
                if (!dataReader.IsDBNull(13))
                    model.FolderType = dataReader.GetInt32(13);
                if (!dataReader.IsDBNull(14))
                    model.SendTime = dataReader.GetDateTime(14);
                model.did = dataReader.GetInt32(15);
                if (!dataReader.IsDBNull(16))
                    model.body = dataReader.GetString(16);
                if (!dataReader.IsDBNull(17))
                    model.fileattech = dataReader.GetString(17);
                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.Mails> GetAll()
        {
            string sql = "SELECT * FROM Mails";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.Mails> List = DataReaderToList(dataReader);
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
        public Data.Model.Mails Get(int id)
        {
            string sql = "SELECT * FROM Mails WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id", SqlDbType.Int){ Value = id }
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.Mails> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }


        /// <summary>
        /// 根据该用户收件对象
        /// </summary>
        public List<Data.Model.Mails> GetAccount(out string pager,Guid UserID, int foldtype, string query = "")
        {




            string user = "%"+UserID.ToString()+"%";
            string sql = string.Empty;
            string SqlWhere=string.Empty ;
            sql = @"select * from (
SELECT a.*,ROW_NUMBER() OVER(ORDER BY a.SendTime DESC) AS PagerAutoRowNumber FROM (select * from (select mails.*,UsersRelation.UserID from Mails left join UsersRelation
on mails.ReceiverID=Convert(NVARCHAR(50),UsersRelation.OrganizeID)) Mails where 1=1 {0} ) a
                WHERE a.ID=(SELECT TOP 1 ID FROM  Mails WHERE id=a.id  ORDER BY SendTime DESC)) aa where 1=1  ";
           
            if (foldtype == 0)
            {
                SqlWhere = SqlWhere + @" and  (ReceiverID like @ReceiverID and FolderType=@FolderType) or (SenderIDs like @ReceiverID and FolderType=@FolderType)";
            }

            if (foldtype == 1)
            {
                SqlWhere = SqlWhere + @" and  (SenderIDs like @ReceiverID and FolderType=@FolderType and SendType=1)";
            }

            if (foldtype == 2)
            {
                SqlWhere = SqlWhere + @" and  (ReceiverID like @ReceiverID and FolderType=@FolderType) or (UserID like @ReceiverID and FolderType=@FolderType)";
            }

            sql = string.Format(sql, SqlWhere);

          // string sql = "SELECT * FROM Mails WHERE ReceiverID like '@ReceiverID' or CCIDs like '@CCIDs' or BccIDs like '@BccIDs'";
            
            SqlParameter[] parameters = new SqlParameter[]{
               //new SqlParameter("@SenderIDs", SqlDbType.NVarChar,500 ){ Value = user }
                new SqlParameter("@ReceiverID", SqlDbType.NVarChar,500 ){ Value = user },
                new SqlParameter("@FolderType", SqlDbType.Int, -1){ Value = foldtype }
                //new SqlParameter("@CCIDs", SqlDbType.NVarChar,500){ Value = user },
                //new SqlParameter("@BccIDs", SqlDbType.NVarChar,500){ Value =user}
			};



            long count;
            int size = Utility.Tools.GetPageSize();
            int number = Utility.Tools.GetPageNumber();
            string sql1 = dbHelper.GetPaerSql(sql.ToString(), size, number, out count, parameters);
            pager = Utility.Tools.GetPagerHtml(count, size, number, query);

            SqlDataReader dataReader = dbHelper.GetDataReader(sql1, parameters);
            List<Data.Model.Mails> List = DataReaderToList(dataReader);
            dataReader.Close();


            
            return List;
        }




        /// <summary>
        /// 根据该用户收件对象
        /// </summary>
        public List<Data.Model.Mails> GetSendAccount(Guid UserID)
        {
            string user =UserID.ToString();

            string sql = "SELECT * FROM Mails WHERE SenderIDs=@SenderIDs and SendType>0";
            //string sql = @"SELECT * FROM Mails WHERE ReceiverID like @ReceiverID or CCIDs like @CCIDs or  BccIDs like @BccIDs";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@SenderIDs", SqlDbType.NVarChar,500 ){ Value = user }
                //new SqlParameter("@ReceiverID", SqlDbType.NVarChar,500 ){ Value = user },
                //new SqlParameter("@CCIDs", SqlDbType.NVarChar,500){ Value = user },
                //new SqlParameter("@BccIDs", SqlDbType.NVarChar,500){ Value =user}
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.Mails> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }


        /// <summary>
        /// 根据该用户收件对象
        /// </summary>
        public List<Data.Model.Mails> GetDelAccount(Guid UserID)
        {
            string user = "%" + UserID.ToString() + "%";


            string sql = @"SELECT * FROM Mails WHERE (SenderIDs=@SenderIDs  and SendType='0') or (ReceiverID like @ReceiverID  and SendType='0') or (CCIDs like @CCIDs and SendType=0) or  (BccIDs like @BccIDs and SendType=0)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@SenderIDs", SqlDbType.NVarChar,500 ){ Value = user },
                new SqlParameter("@ReceiverID", SqlDbType.NVarChar,500 ){ Value = user },
                new SqlParameter("@CCIDs", SqlDbType.NVarChar,500){ Value = user },
                new SqlParameter("@BccIDs", SqlDbType.NVarChar,500){ Value =user}
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.Mails> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }



    }
}