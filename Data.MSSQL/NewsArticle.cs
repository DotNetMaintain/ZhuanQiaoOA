using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.MSSQL
{
    public class NewsArticle : Data.Interface.INewsArticle
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
        public NewsArticle()
        {
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="model">Data.Model.Users实体类</param>
        /// <returns>操作所影响的行数</returns>
        public int Add(Data.Model.NewsArticle model)
        {
            string sql = @"INSERT INTO News_Article( guid,ComID,NewsTitle,FilePath,Notes,TypeID,CreatorID,CreatorRealName,CreatorDepName,AddTime,ShareUsers,ShareDeps,namelist) VALUES(@guid,@ComID,@NewsTitle,@FilePath,@Notes,@TypeID,@CreatorID,@CreatorRealName,@CreatorDepName,@AddTime,@ShareUsers,@ShareDeps,@namelist)";
            SqlParameter[] parameters = new SqlParameter[]{
        new SqlParameter("@guid",SqlDbType.VarChar,100) { Value = model.guid },
        new SqlParameter("@ComID",SqlDbType.Int,4) { Value = model.ComID},
        new SqlParameter("@NewsTitle",SqlDbType.VarChar,500) { Value = model.NewsTitle},
        new SqlParameter("@FilePath",SqlDbType.VarChar,-1) { Value = model.FilePath},
        new SqlParameter("@Notes",SqlDbType.VarChar,-1) { Value = model.Notes},
        new SqlParameter("@TypeID",SqlDbType.VarChar,-1) { Value = model.TypeID},
        new SqlParameter("@CreatorID",SqlDbType.Int,4) { Value = model.CreatorID},
        new SqlParameter("@CreatorRealName",SqlDbType.VarChar,100) { Value = model.CreatorRealName},
        new SqlParameter("@CreatorDepName",SqlDbType.VarChar,100) { Value = model.CreatorDepName},
        new SqlParameter("@AddTime",SqlDbType.DateTime,8) { Value = model.AddTime},
        new SqlParameter("@ShareUsers",SqlDbType.VarChar,-1) { Value = model.ShareUsers},
        new SqlParameter("@ShareDeps",SqlDbType.VarChar,-1) { Value = model.ShareDeps},
        new SqlParameter("@namelist",SqlDbType.VarChar,-1) { Value = model.namelist}
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model">Data.Model.Users实体类</param>
        public int Update(Data.Model.NewsArticle model)
        {
            string sql = @"UPDATE News_Article SET  guid = @guid, ComID = @ComID, NewsTitle = @NewsTitle, FilePath = @FilePath, Notes = @Notes, TypeID = @TypeID, CreatorID = @CreatorID, CreatorRealName = @CreatorRealName, CreatorDepName = @CreatorDepName, AddTime = @AddTime, ShareUsers = @ShareUsers, ShareDeps = @ShareDeps, namelist = @namelist		WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id",SqlDbType.Int,4) { Value = model.id} ,
        new SqlParameter("@guid",SqlDbType.VarChar,100) { Value = model.guid },
        new SqlParameter("@ComID",SqlDbType.Int,4) { Value = model.ComID},
        new SqlParameter("@NewsTitle",SqlDbType.VarChar,500) { Value = model.NewsTitle},
        new SqlParameter("@FilePath",SqlDbType.VarChar,-1) { Value = model.FilePath},
        new SqlParameter("@Notes",SqlDbType.VarChar,-1) { Value = model.Notes},
        new SqlParameter("@TypeID",SqlDbType.VarChar,-1) { Value = model.TypeID},
        new SqlParameter("@CreatorID",SqlDbType.Int,4) { Value = model.CreatorID},
        new SqlParameter("@CreatorRealName",SqlDbType.VarChar,100) { Value = model.CreatorRealName},
        new SqlParameter("@CreatorDepName",SqlDbType.VarChar,100) { Value = model.CreatorDepName},
        new SqlParameter("@AddTime",SqlDbType.DateTime,8) { Value = model.AddTime},
        new SqlParameter("@ShareUsers",SqlDbType.VarChar,-1) { Value = model.ShareUsers},
        new SqlParameter("@ShareDeps",SqlDbType.VarChar,-1) { Value = model.ShareDeps},
        new SqlParameter("@namelist",SqlDbType.VarChar,-1) { Value = model.namelist}
				
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        public int Delete(Int32 id)
        {
            string sql = "DELETE FROM News_Article WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id",SqlDbType.Int,-1) { Value =id} 
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 将DataRedar转换为List
        /// </summary>
        private List<Data.Model.NewsArticle> DataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.NewsArticle> List = new List<Data.Model.NewsArticle>();
            Data.Model.NewsArticle model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.NewsArticle();
                model.id = dataReader.GetInt32(0);
                model.guid = dataReader.GetString(1);
                model.ComID = dataReader.GetInt32(2);
                if (!dataReader.IsDBNull(3))
                    model.NewsTitle = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4))
                    model.FilePath = dataReader.GetString(4);
                if (!dataReader.IsDBNull(5))
                    model.Notes = dataReader.GetString(5);
                model.TypeID = dataReader.GetString(6);               
                model.CreatorID = dataReader.GetInt32(7);
                model.CreatorRealName = dataReader.GetString(8);
                model.CreatorDepName = dataReader.GetString(9);
                model.AddTime = dataReader.GetDateTime(10);
                if (!dataReader.IsDBNull(11))
                model.ShareUsers = dataReader.GetString(11);
                if (!dataReader.IsDBNull(12))
                model.ShareDeps = dataReader.GetString(12);
                if (!dataReader.IsDBNull(14))
                model.namelist = dataReader.GetString(14);
                if (!dataReader.IsDBNull(15))
                model.TypeName = dataReader.GetString(15);
                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.NewsArticle> GetAll()
        {
            string sql = "SELECT news.*,dic.title FROM News_Article news inner join Dictionary dic on news.typeid=dic.id order by AddTime desc";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.NewsArticle> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        public long GetCount()
        {
            string sql = "SELECT COUNT(*) FROM News_Article";
            long count;
            return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
        }
        /// <summary>
        /// 根据主键查询一条记录
        /// </summary>
        public Data.Model.NewsArticle Get(Int32 id)
        {
            string sql = "select * from (SELECT news.*,dic.title FROM News_Article news inner join Dictionary dic on news.typeid=dic.id) news WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.Int,4){ Value = id }
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.NewsArticle> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }

      
    }
}
