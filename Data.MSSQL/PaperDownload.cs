using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.MSSQL
{
    public class PaperDownload : Data.Interface.IPaperDownload
    {


         private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
         public PaperDownload()
        {
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="model">Data.Model.PaperDownload实体类</param>
        /// <returns>操作所影响的行数</returns>
         public int Add(Data.Model.PaperDownload model)
        {

            string sql = @"INSERT INTO PaperDownload( guid,DPaperNo,Subject,FileAttech,DPaperSymbol,AddUserid,AddTime) VALUES(@guid,@DPaperNo,@Subject,@FileAttech,@DPaperSymbol,@AddUserid,@AddTime)";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id",SqlDbType.Int,4) { Value = model.id} ,
        new SqlParameter("@guid",SqlDbType.VarChar,100) { Value = model.guid },
        new SqlParameter("@DPaperNo",SqlDbType.VarChar,100) { Value = model.DPaperNo},
        new SqlParameter("@Subject",SqlDbType.VarChar,100) { Value = model.Subject},
        new SqlParameter("@FileAttech",SqlDbType.VarChar,500) { Value = model.FileAttech},
        new SqlParameter("@DPaperSymbol",SqlDbType.VarChar,100) { Value = model.DPaperSymbol},
        new SqlParameter("@AddUserid",SqlDbType.VarChar,500) { Value = model.AddUserid},
        new SqlParameter("@AddTime",SqlDbType.DateTime,8) { Value = model.AddTime}
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model">Data.Model.PaperDownload实体类</param>
         public int Update(Data.Model.PaperDownload model)
        {
               
            string sql = @"UPDATE PaperDownload SET  guid = @guid, DPaperNo = @DPaperNo, Subject = @Subject, FileAttech = @FileAttech, DPaperSymbol=@DPaperSymbol, AddUserid = @AddUserid,AddTime = @AddTime		WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id",SqlDbType.Int,4) { Value = model.id} ,
        new SqlParameter("@guid",SqlDbType.VarChar,100) { Value = model.guid },
        new SqlParameter("@DPaperNo",SqlDbType.VarChar,100) { Value = model.DPaperNo},
        new SqlParameter("@Subject",SqlDbType.VarChar,100) { Value = model.Subject},
        new SqlParameter("@FileAttech",SqlDbType.VarChar,500) { Value = model.FileAttech},
        new SqlParameter("@DPaperSymbol",SqlDbType.VarChar,100) { Value = model.DPaperSymbol},
        new SqlParameter("@AddUserid",SqlDbType.VarChar,500) { Value = model.AddUserid},
        new SqlParameter("@AddTime",SqlDbType.DateTime,8) { Value = model.AddTime}

			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
         public int Delete(Int32 id)
        {
            string sql = "DELETE FROM PaperDownload WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id",SqlDbType.Int,-1) { Value =id} 
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 将DataRedar转换为List
        /// </summary>
        private List<Data.Model.PaperDownload> DataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.PaperDownload> List = new List<Data.Model.PaperDownload>();
            Data.Model.PaperDownload model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.PaperDownload();
                model.id = dataReader.GetInt32(0);
                model.guid = dataReader.GetString(1);
                model.DPaperNo=dataReader.GetString(2);
                model.Subject =dataReader.GetString(3);
                model.FileAttech=dataReader.GetString(4);
                model.DPaperSymbol=dataReader.GetString(5);
                model.AddUserid=dataReader.GetString(6); 
                model.AddTime=dataReader.GetDateTime(7);  
              


                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.PaperDownload> GetAll()
        {
            string sql = "SELECT * from PaperDownload order by AddTime desc";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.PaperDownload> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        public long GetCount()
        {
            string sql = "SELECT COUNT(*) FROM PaperDownload";
            long count;
            return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
        }
        /// <summary>
        /// 根据主键查询一条记录
        /// </summary>
        public Data.Model.PaperDownload Get(Int32 id)
        {
            string sql = "SELECT * FROM PaperDownload WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.Int,4){ Value = id }
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.PaperDownload> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }



    }
}
