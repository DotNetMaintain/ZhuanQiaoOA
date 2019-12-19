using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.MSSQL
{
    public class Reports : Data.Interface.IReports
    {
        private DBHelper dbHelper = new DBHelper();
        public Reports()
        {
        }



        /// <summary>
        /// 将DataRedar转换为List
        /// </summary>
        private List<Data.Model.Reports> DataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.Reports> List = new List<Data.Model.Reports>();
            Data.Model.Reports model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.Reports();
                model.DeptName = dataReader.GetString(0);
                model.UserName = dataReader.GetString(1);
                model.AffairDays = dataReader.GetDouble(2);
                model.WeddingDays = dataReader.GetDouble(3);
                model.SickDays = dataReader.GetDouble(4);
                model.MaternityDays = dataReader.GetDouble(5);
                model.ChaperonageDays = dataReader.GetDouble(6);
                model.YearDays = dataReader.GetDouble(7);
                model.HomeDays = dataReader.GetDouble(8);
                model.LastPublicDays = dataReader.GetDecimal(9);
                model.PublicDays = dataReader.GetDecimal(10);
                model.RestDays = dataReader.GetDecimal(11);
                model.subLastPublicDate = dataReader.GetDouble(12);
                model.subPublicDate = dataReader.GetDouble(13);
                model.subRestDate = dataReader.GetDouble(14);
               
                List.Add(model);
            }
            return List;
        }



        private List<Data.Model.RestDetailReports> RestDetailDataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.RestDetailReports> List = new List<Data.Model.RestDetailReports>();
            Data.Model.RestDetailReports model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.RestDetailReports();
                model.DeptName = dataReader.GetString(0);
                model.UserName = dataReader.GetString(1);
                model.RestType = dataReader.GetString(2);
                model.Days = dataReader.GetDouble(3);
                model.StartTime = dataReader.GetDateTime(4);
                model.EndTime = dataReader.GetDateTime(5);
              

                List.Add(model);
            }
            return List;
        }



        private List<Data.Model.ReceiveReports> ReceiveDataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.ReceiveReports> List = new List<Data.Model.ReceiveReports>();
            Data.Model.ReceiveReports model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.ReceiveReports();
                model.Name = dataReader.GetString(0);
                model.BeginDate = dataReader.GetDateTime(1);
                model.EndDate = dataReader.GetDateTime(2);
                model.Model = dataReader.GetInt32(3);
                model.Unit = dataReader.GetInt32(4);
                model.Type = dataReader.GetInt32(5);
                model.Fresequence = dataReader.GetInt32(6);
               

                List.Add(model);
            }
            return List;
        }

        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.Reports> GetRestReportAllPara(string starttime,string endtime)
        {
            //DateTime dt1 =DateTime.TryParseExact(starttime,@"YYYY/MM/DD");
            //DateTime dt2 = Convert.ToDateTime(endtime,DATE);

            string sql = @"select *,
case when LastPublicDate-yeardays>0 then LastPublicDate-yeardays else 0 end as 'subLastPublicDate',
case when LastPublicDate-yeardays<0 and LastPublicDate+PublicDate-yeardays>0 then LastPublicDate+PublicDate-yeardays else 
   case  when LastPublicDate+PublicDate-yeardays<0 then 0 else PublicDate end  end as 'subPublicDate',
case when LastPublicDate-yeardays<0 and LastPublicDate+PublicDate-yeardays<0 and LastPublicDate+PublicDate+RestDate-yeardays>0 then LastPublicDate+PublicDate+RestDate-yeardays else 
case when LastPublicDate+PublicDate-yeardays<0 then LastPublicDate+PublicDate-yeardays else RestDate  end end as 'subRestDate'
from (select distinct  deptname,username,
SUM(CASE WHEN Type='事假' then Days else 0 end) as 'AffairDays',
SUM(CASE WHEN Type='婚假' then Days else 0 end) as 'WeddingDays',
SUM(CASE WHEN Type='病假' then Days else 0 end) as 'SickDays',
SUM(CASE WHEN Type='产假' then Days else 0 end) as 'MaternityDays',
SUM(CASE WHEN Type='陪护假' then Days else 0 end) as 'ChaperonageDays',
SUM(CASE WHEN Type='年假' then Days else 0 end) as 'YearDays',
SUM(CASE WHEN Type='探亲假' then Days else 0 end) as 'HomeDays',
isnull(LastPublicDate,0) as LastPublicDate ,isnull(PublicDate,0) as PublicDate ,isnull(RestDate,0) as RestDate 
 from 
(select temp.Type,temp.date1,temp.date2,temp.days,users.Name as username,Organize .Name as deptname,UsersInfo.LastPublicDate,UsersInfo.PublicDate ,UsersInfo.RestDate    from (select * from TempTest ) temp 
inner join Users on substring(temp.UserID,3,LEN(temp.userid)) =convert(varchar(50),users.ID)
inner join Organize  on Temp.DeptID =convert(varchar(50),Organize .ID)
inner join (select * from workflowtask where status='2' and Comment='同意') task on  task.InstanceID=Convert(varchar(50),temp.id)
left join UsersInfo on users.id=usersinfo.userid where date1>='{0}' and date2<='{1}') as record
group by deptname ,username,LastPublicDate,PublicDate,RestDate) last";
            sql = string.Format(sql, starttime, endtime); 
            // SqlParameter[] parameters = new SqlParameter[]{
            //    new SqlParameter("@starttime", SqlDbType.DateTime){ Value =DateTime.Parse(starttime) },
            //    new SqlParameter("@endtime", SqlDbType.DateTime){ Value =DateTime.Parse(endtime) }			
				
            //};
             SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.Reports> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }




        /// <summary>
        /// 查询有条件的记录
        /// </summary>
        public List<Data.Model.Reports> GetRestReportAll()
        {
            string sql = @"select *,
case when LastPublicDate-yeardays>0 then LastPublicDate-yeardays else 0 end as 'subLastPublicDate',
case when LastPublicDate-yeardays<0 and LastPublicDate+PublicDate-yeardays>0 then LastPublicDate+PublicDate-yeardays else 
   case  when LastPublicDate+PublicDate-yeardays<0 then 0 else PublicDate end  end as 'subPublicDate',
case when LastPublicDate-yeardays<0 and LastPublicDate+PublicDate-yeardays<0 and LastPublicDate+PublicDate+RestDate-yeardays>0 then LastPublicDate+PublicDate+RestDate-yeardays else 
case when LastPublicDate+PublicDate-yeardays<0 then LastPublicDate+PublicDate-yeardays else RestDate  end end as 'subRestDate'
from (select distinct  deptname,username,
SUM(CASE WHEN Type='事假' then Days else 0 end) as 'AffairDays',
SUM(CASE WHEN Type='婚假' then Days else 0 end) as 'WeddingDays',
SUM(CASE WHEN Type='病假' then Days else 0 end) as 'SickDays',
SUM(CASE WHEN Type='产假' then Days else 0 end) as 'MaternityDays',
SUM(CASE WHEN Type='陪护假' then Days else 0 end) as 'ChaperonageDays',
SUM(CASE WHEN Type='年假' then Days else 0 end) as 'YearDays',
SUM(CASE WHEN Type='探亲假' then Days else 0 end) as 'HomeDays',
isnull(LastPublicDate,0) as LastPublicDate ,isnull(PublicDate,0) as PublicDate ,isnull(RestDate,0) as RestDate 
 from 
(select temp.Type,temp.date1,temp.date2,temp.days,users.Name as username,Organize .Name as deptname,UsersInfo.LastPublicDate,UsersInfo.PublicDate ,UsersInfo.RestDate    from (select * from TempTest ) temp 
inner join Users on substring(temp.UserID,3,LEN(temp.userid)) =convert(varchar(50),users.ID)
inner join Organize  on Temp.DeptID =convert(varchar(50),Organize .ID)
inner join (select * from workflowtask where status='2' and Comment='同意') task on  task.InstanceID=Convert(varchar(50),temp.id)
left join UsersInfo on users.id=usersinfo.userid
) as record
group by deptname ,username,LastPublicDate,PublicDate,RestDate) last";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.Reports> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }






        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.RestDetailReports> GetRestDetailReportAllPara(string starttime, string endtime)
        {
            
            string sql = @"select temp.date1,temp.date2,Organize .Name as deptname,users.Name as username,temp.Type,temp.days   from TempTest temp 
                inner join Users on substring(temp.UserID,3,LEN(temp.userid)) =convert(varchar(50),users.ID)
                inner join Organize  on Temp.DeptID =convert(varchar(50),Organize .ID)
                where date1>='{0}' and date2<='{1}'";
            sql = string.Format(sql, starttime, endtime);
           
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.RestDetailReports> List = RestDetailDataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }


        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.RestDetailReports> GetRestDetailReportAll()
        {

            string sql = @"select temp.date1,temp.date2,Organize .Name as deptname,users.Name as username,temp.Type,temp.days   from TempTest temp 
                inner join Users on substring(temp.UserID,3,LEN(temp.userid)) =convert(varchar(50),users.ID)
                inner join Organize  on Temp.DeptID =convert(varchar(50),Organize .ID)";
            sql = string.Format(sql);

            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.RestDetailReports> List = RestDetailDataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }


        /// <summary>
        /// 台帐交接报表
        /// 查询有条件的记录
        /// </summary>
        public List<Data.Model.ReceiveReports> GetReceiveReportAll()
        {
            string sql = @"select dictionary.title as name,record.begintime as begintime,record.endtime as endtime,record.Model as Model,
record.Unit as Unit,record.Type as Type,record.Fresequence as Fresequence
 from(
select name,min(SqDateTime) as begintime,max(SqDateTime) as endtime,sum(cast(Model as int)) as Model,
sum(cast(Unit as int)) as Unit,
sum(cast(Type as int)) as Type,count(name) as Fresequence from FixSet_Record
group by name) as record inner join 
dictionary on record.name=dictionary.id";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.ReceiveReports> List = ReceiveDataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }






        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.ReceiveReports> GetReceiveReportAllPara(string starttime, string endtime)
        {

            string sql = @"select dictionary.title as name,record.begintime as begintime,record.endtime as endtime,record.Model as Model,
record.Unit as Unit,record.Type as Type,record.Fresequence as Fresequence from (
select name,cast('{0}' as datetime) as begintime,cast('{1}' as datetime) as endtime,sum(cast(Model as int)) as Model,
sum(cast(Unit as int)) as Unit,
sum(cast(Type as int)) as Type,count(name) as Fresequence from FixSet_Record  where SqDateTime>='{0}' and SqDateTime<='{1}'
group by name) as  record inner join 
dictionary on record.name=dictionary.id ";
            sql = string.Format(sql, starttime, endtime);

            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.ReceiveReports> List = ReceiveDataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }



    }
}
