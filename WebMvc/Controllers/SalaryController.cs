using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Data.MSSQL;
using System.IO;
using Utility;
using System.Data.SqlClient;

namespace WebMvc.Controllers
{
    public class SalaryController : Controller
    {
        //
        // GET: /Salary/

        private DBHelper dbHelper = new DBHelper();

        public ActionResult Index()
        {

            return Index(null);
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection collection)
        {
            DataSet ds = new DataSet();
            string starttime = string.Empty;
            string endtime = string.Empty;
            if (Request.Form["btnSearch"] != null)
            {
                 starttime = Request.Form["starttime"];
                 endtime = Request.Form["endtime"];
            }
            else
            {
                DateTime dt = DateTime.Now;
                //将本月月数+1  
                DateTime dt2 = dt.AddMonths(1);
                //本月最后一天时间  
                DateTime dt_Last = dt2.AddDays(-(dt.Day));

                starttime = DateTime.Now.Year.ToString()+"-" + DateTime.Now.Month.ToString()+"-01";
                endtime = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-"+dt_Last.Day.ToString();
            }
                ViewBag.starttime = starttime;
                ViewBag.endtime = endtime;
                string sql_condition = string.Empty;
                sql_condition = sql_condition + " and  isconfirm=1 ";
                if (!string.IsNullOrEmpty(starttime))
                {
                    sql_condition = sql_condition + " and inputdate>='{0}'";
                    sql_condition = string.Format(sql_condition, starttime);

                }

                if (!string.IsNullOrEmpty(endtime))
                {
                    sql_condition = sql_condition + " and inputdate<='{0}'";
                    sql_condition = string.Format(sql_condition, endtime);

                }

                

                

                //非编工资
                string SalaryGZ = @"select * from SalaryGZ where  code='{0}'";
                SalaryGZ = string.Format(SalaryGZ, Business.Platform.Users.CurrentUser.Account);
                SalaryGZ = SalaryGZ + sql_condition;
                System.Data.DataTable dt_SalaryGZ = dbHelper.GetDataTable(SalaryGZ);
                ds.Tables.Add(dt_SalaryGZ);

                //非编奖金
                string SalaryJJ = @"select * from SalaryJJ where  code='{0}'";
                SalaryJJ = string.Format(SalaryJJ, Business.Platform.Users.CurrentUser.Account);
                SalaryJJ = SalaryJJ + sql_condition;
                System.Data.DataTable dt_SalaryJJ = dbHelper.GetDataTable(SalaryJJ);
                ds.Tables.Add(dt_SalaryJJ);

                //非编其他
                string SalaryOther = @"select * from SalaryOther where  code='{0}'";
                SalaryOther = string.Format(SalaryOther, Business.Platform.Users.CurrentUser.Account);
                SalaryOther = SalaryOther + sql_condition;
                System.Data.DataTable dt_SalaryOther = dbHelper.GetDataTable(SalaryOther);
                ds.Tables.Add(dt_SalaryOther);


                //在编工资
                string SalaryGZON = @"select * from SalaryGZON where  code='{0}'";
                SalaryGZON = string.Format(SalaryGZON, Business.Platform.Users.CurrentUser.Account);
                SalaryGZON = SalaryGZON + sql_condition;
                System.Data.DataTable dt_SalaryGZON = dbHelper.GetDataTable(SalaryGZON);
                ds.Tables.Add(dt_SalaryGZON);

                //在编奖金
                string SalaryJJON = @"select * from SalaryJJON where  code='{0}'";
                SalaryJJON = string.Format(SalaryJJON, Business.Platform.Users.CurrentUser.Account);
                SalaryJJON = SalaryJJON + sql_condition;
                System.Data.DataTable dt_SalaryJJON = dbHelper.GetDataTable(SalaryJJON);
                ds.Tables.Add(dt_SalaryJJON);

                //在编其他
                string SalaryOtherON = @"select * from SalaryOtherON where  code='{0}'";
                SalaryOtherON = string.Format(SalaryOtherON, Business.Platform.Users.CurrentUser.Account);
                SalaryOtherON = SalaryOtherON + sql_condition;
                System.Data.DataTable dt_SalaryOtherON = dbHelper.GetDataTable(SalaryOtherON);
                ds.Tables.Add(dt_SalaryOtherON);

                //乡村医生工资
                string SalaryCountryDocGZ = @"select * from SalaryCountryDocGZ where  code='{0}'";
                SalaryCountryDocGZ = string.Format(SalaryCountryDocGZ, Business.Platform.Users.CurrentUser.Account);
                SalaryCountryDocGZ = SalaryCountryDocGZ + sql_condition;
                System.Data.DataTable dt_SalaryCountryDocGZ = dbHelper.GetDataTable(SalaryCountryDocGZ);
                ds.Tables.Add(dt_SalaryCountryDocGZ);

                //乡村医生奖金
                string SalaryCountryDocJJ = @"select * from SalaryCountryDocJJ where  code='{0}'";
                SalaryCountryDocJJ = string.Format(SalaryCountryDocJJ, Business.Platform.Users.CurrentUser.Account);
                SalaryCountryDocJJ = SalaryCountryDocJJ + sql_condition;
                System.Data.DataTable dt_SalaryCountryDocJJ = dbHelper.GetDataTable(SalaryCountryDocJJ);
                ds.Tables.Add(dt_SalaryCountryDocJJ);

                //退返人员工资
                string SalaryReturnGZ = @"select * from SalaryReturnGZ where  code='{0}'";
                SalaryReturnGZ = string.Format(SalaryReturnGZ, Business.Platform.Users.CurrentUser.Account);
                SalaryReturnGZ = SalaryReturnGZ + sql_condition;
                System.Data.DataTable dt_SalaryReturnGZ = dbHelper.GetDataTable(SalaryReturnGZ);
                ds.Tables.Add(dt_SalaryReturnGZ);

                //退返人员奖金
                string SalaryReturnJJ = @"select * from SalaryReturnJJ where  code='{0}'";
                SalaryReturnJJ = string.Format(SalaryReturnJJ, Business.Platform.Users.CurrentUser.Account);
                SalaryReturnJJ = SalaryReturnJJ + sql_condition;
                System.Data.DataTable dt_SalaryReturnJJ = dbHelper.GetDataTable(SalaryReturnJJ);
                ds.Tables.Add(dt_SalaryReturnJJ);





            return View(ds);

        }

        public ActionResult ImportSalary()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ImportSalary(FormCollection collection)
        {


            DataSet ds_View = new DataSet();
            if (Request.Form["btnSearch"] != null)
            {
               
                string starttime = string.Empty;
                string endtime = string.Empty;
                string salarytype = string.Empty;

                DateTime dt = DateTime.Now;
                //将本月月数+1  
                DateTime dt2 = dt.AddMonths(1);
                //本月最后一天时间  
                DateTime dt_Last = dt2.AddDays(-(dt.Day));


                if (Request.Form["btnSearch"] != null)
                {
                    starttime = Request.Form["starttime"];
                    endtime = Request.Form["endtime"];
                    salarytype = Request.Form["comSalary"];

                    if (starttime == "" || endtime == "")
                    {
                        starttime = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01";
                        endtime = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + dt_Last.Day.ToString();
                    }
                }
                else
                {
                    starttime = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01";
                    endtime = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + dt_Last.Day.ToString();
                }
                ViewBag.starttime = starttime;
                ViewBag.endtime = endtime;
                ViewBag.salarytype = salarytype;
                string sql_condition = string.Empty;

                if (!string.IsNullOrEmpty(starttime))
                {
                    sql_condition = sql_condition + " and inputdate>='{0}'";
                    sql_condition = string.Format(sql_condition, starttime);

                }

                if (!string.IsNullOrEmpty(endtime))
                {
                    sql_condition = sql_condition + " and inputdate<='{0}'";
                    sql_condition = string.Format(sql_condition, endtime);

                }


               
                    //非编工资
                if (salarytype == "SalaryGZ")
                {
                    string SalaryGZ = @"select * from SalaryGZ where  1=1 ";
                    //SalaryGZ = string.Format(SalaryGZ, Business.Platform.Users.CurrentUser.Account);
                    SalaryGZ = SalaryGZ + sql_condition;
                    System.Data.DataTable dt_SalaryGZ = dbHelper.GetDataTable(SalaryGZ);
                    ds_View.Tables.Add(dt_SalaryGZ);
                }


                

                //非编奖金

                if (salarytype == "SalaryJJ")
                { 
                string SalaryJJ = @"select * from SalaryJJ where  1=1";
                //SalaryJJ = string.Format(SalaryJJ, Business.Platform.Users.CurrentUser.Account);
                SalaryJJ = SalaryJJ + sql_condition;
                System.Data.DataTable dt_SalaryJJ = dbHelper.GetDataTable(SalaryJJ);
                ds_View.Tables.Add(dt_SalaryJJ);
                }

                //非编其他

                if (salarytype == "SalaryOther")
                {
                    string SalaryOther = @"select * from SalaryOther where  1=1";
                    // SalaryOther = string.Format(SalaryOther, Business.Platform.Users.CurrentUser.Account);
                    SalaryOther = SalaryOther + sql_condition;
                    System.Data.DataTable dt_SalaryOther = dbHelper.GetDataTable(SalaryOther);
                    ds_View.Tables.Add(dt_SalaryOther);
                }
                


                //在编工资

                if (salarytype == "SalaryGZON")
                { 
                string SalaryGZON = @"select * from SalaryGZON where  1=1";
               // SalaryGZON = string.Format(SalaryGZON, Business.Platform.Users.CurrentUser.Account);
                SalaryGZON = SalaryGZON + sql_condition;
                System.Data.DataTable dt_SalaryGZON = dbHelper.GetDataTable(SalaryGZON);
                ds_View.Tables.Add(dt_SalaryGZON);
                }
                //在编奖金

                if (salarytype == "SalaryJJON")
                {
                    string SalaryJJON = @"select * from SalaryJJON where  1=1";
                    // SalaryJJON = string.Format(SalaryJJON, Business.Platform.Users.CurrentUser.Account);
                    SalaryJJON = SalaryJJON + sql_condition;
                    System.Data.DataTable dt_SalaryJJON = dbHelper.GetDataTable(SalaryJJON);
                    ds_View.Tables.Add(dt_SalaryJJON);
                }
               

                //在编其他

                if (salarytype == "SalaryOtherON")
                {
                    string SalaryOtherON = @"select * from SalaryOtherON where  1=1";
                    // SalaryOtherON = string.Format(SalaryOtherON, Business.Platform.Users.CurrentUser.Account);
                    SalaryOtherON = SalaryOtherON + sql_condition;
                    System.Data.DataTable dt_SalaryOtherON = dbHelper.GetDataTable(SalaryOtherON);
                    ds_View.Tables.Add(dt_SalaryOtherON);
                }
               

                //乡村医生工资

                if (salarytype == "SalaryCountryDocGZ")
                {
                    string SalaryCountryDocGZ = @"select * from SalaryCountryDocGZ where  1=1";
                    // SalaryCountryDocGZ = string.Format(SalaryCountryDocGZ, Business.Platform.Users.CurrentUser.Account);
                    SalaryCountryDocGZ = SalaryCountryDocGZ + sql_condition;
                    System.Data.DataTable dt_SalaryCountryDocGZ = dbHelper.GetDataTable(SalaryCountryDocGZ);
                    ds_View.Tables.Add(dt_SalaryCountryDocGZ);
                }
                

                //乡村医生奖金

                if (salarytype == "SalaryCountryDocJJ")
                {
                    string SalaryCountryDocJJ = @"select * from SalaryCountryDocJJ where  1=1";
                    // SalaryCountryDocJJ = string.Format(SalaryCountryDocJJ, Business.Platform.Users.CurrentUser.Account);
                    SalaryCountryDocJJ = SalaryCountryDocJJ + sql_condition;
                    System.Data.DataTable dt_SalaryCountryDocJJ = dbHelper.GetDataTable(SalaryCountryDocJJ);
                    ds_View.Tables.Add(dt_SalaryCountryDocJJ);
                }
               

                //退返人员工资

                if (salarytype == "SalaryReturnGZ")
                {
                    string SalaryReturnGZ = @"select * from SalaryReturnGZ where  1=1";
                    // SalaryReturnGZ = string.Format(SalaryReturnGZ, Business.Platform.Users.CurrentUser.Account);
                    SalaryReturnGZ = SalaryReturnGZ + sql_condition;
                    System.Data.DataTable dt_SalaryReturnGZ = dbHelper.GetDataTable(SalaryReturnGZ);
                    ds_View.Tables.Add(dt_SalaryReturnGZ);
                }
                

                //退返人员奖金

                if (salarytype == "SalaryReturnJJ")
                {
                    string SalaryReturnJJ = @"select * from SalaryReturnJJ where  1=1";
                    // SalaryReturnJJ = string.Format(SalaryReturnJJ, Business.Platform.Users.CurrentUser.Account);
                    SalaryReturnJJ = SalaryReturnJJ + sql_condition;
                    System.Data.DataTable dt_SalaryReturnJJ = dbHelper.GetDataTable(SalaryReturnJJ);
                    ds_View.Tables.Add(dt_SalaryReturnJJ);
                  
                }
                





                return View(ds_View);

            }


            if (Request.Form["btnPublish"] != null)
            {
                string starttime = string.Empty;
                string endtime = string.Empty;
                string salarytype = string.Empty;

                DateTime dt = DateTime.Now;
                //将本月月数+1  
                DateTime dt2 = dt.AddMonths(1);
                //本月最后一天时间  
                DateTime dt_Last = dt2.AddDays(-(dt.Day));


                starttime = Request.Form["starttime"];
                    endtime = Request.Form["endtime"];
                    salarytype = Request.Form["comSalary"];

                    if (starttime == "" || endtime == "")
                    {
                        starttime = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01";
                        endtime = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + dt_Last.Day.ToString();
                    }
                else
                {
                    starttime = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01";
                    endtime = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + dt_Last.Day.ToString();
                }
                ViewBag.starttime = starttime;
                ViewBag.endtime = endtime;
                ViewBag.salarytype = salarytype;
                string sql_condition = string.Empty;

                if (!string.IsNullOrEmpty(starttime))
                {
                    sql_condition = sql_condition + " and inputdate>='{0}'";
                    sql_condition = string.Format(sql_condition, starttime);

                }

                if (!string.IsNullOrEmpty(endtime))
                {
                    sql_condition = sql_condition + " and inputdate<='{0}'";
                    sql_condition = string.Format(sql_condition, endtime);

                }

                string sql = @"update  " + salarytype + "  set isconfirm=1 where 1=1";
                sql = sql + sql_condition;
                 
         

                dbHelper.Execute(sql);


                ViewBag.Script = "alert('发布成功!');";

                return View();
            }



            
            //导入非编奖金
            HttpPostedFileBase postFile=null;
            string tablename = string.Empty;
            if (!string.IsNullOrEmpty(Request.Files["fileNamefbgz"].FileName))
            {
                postFile = Request.Files["fileNamefbgz"];
                tablename = "SalaryGZ";
            }
            if(!string.IsNullOrEmpty(Request.Files["fileNamefbjj"].FileName))
            {
                postFile = Request.Files["fileNamefbjj"];
                tablename = "SalaryJJ";
            }
            if (!string.IsNullOrEmpty(Request.Files["fileNamefbother"].FileName))
            {
                postFile = Request.Files["fileNamefbother"];
                tablename = "SalaryOther";
            }
            if (!string.IsNullOrEmpty(Request.Files["fileNamereturngz"].FileName))
            {
                postFile = Request.Files["fileNamereturngz"];
                tablename = "SalaryReturnGZ";
            }
            if (!string.IsNullOrEmpty(Request.Files["fileNamereturnother"].FileName))
            {
                postFile = Request.Files["fileNamereturnother"];
                tablename = "SalaryReturnJJ";
            }
            if (!string.IsNullOrEmpty(Request.Files["fileNamecountrydocgz"].FileName))
            {
                postFile = Request.Files["fileNamecountrydocgz"];
                tablename = "SalaryCountryDocGZ";
            }
            if (!string.IsNullOrEmpty(Request.Files["fileNamecountrydocjj"].FileName))
            {
                postFile = Request.Files["fileNamecountrydocjj"];
                tablename = "SalaryCountryDocJJ";
            }
            if (!string.IsNullOrEmpty(Request.Files["fileNamegzon"].FileName))
            {
                postFile = Request.Files["fileNamegzon"];
                tablename = "SalaryGZON";
            }
            if (!string.IsNullOrEmpty(Request.Files["fileNamejjon"].FileName))
            {
                postFile = Request.Files["fileNamejjon"];
                tablename = "SalaryJJON";
            }
            if (!string.IsNullOrEmpty(Request.Files["fileNameotheron"].FileName))
            {
                postFile = Request.Files["fileNameotheron"];
                tablename = "SalaryOtherON";
            }
           // HttpPostedFileBase postFile = Request.Files["fileNamefbjj"];
           



            if (postFile == null)
            {

                return Content("没有文件！", "text/plain");

            }
            string baseUrl = Server.MapPath("/");
            string uploadPath = baseUrl + @"Content\UploadFiles\Salary\";
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Path.GetFileName(postFile.FileName);
            if (fileName != "")
            {

                postFile.SaveAs(uploadPath + fileName);
            }


            // uploadStream = postFile.InputStream;




            //    fs = new FileStream(uploadPath + fileName, FileMode.Create, FileAccess.ReadWrite);  
            ExcelToData etd = new ExcelToData();
            System.Data.DataSet ds = etd.GetDataSet(uploadPath, fileName);
            if (ds != null)
            {

                //存入数据库中


                Data.MSSQL.DBHelper dbHelper = new Data.MSSQL.DBHelper();


                //string checksql = @"select * from Performance_Score where startdate='{0}'";
                //checksql = string.Format(checksql, ds.Tables[0].Rows[0][0].ToString());
                //DataTable dt = dbHelper.GetDataTable(checksql);
                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    //View.Script = "";
                //    return View();
                //}

                string inputid = DateTime.Now.ToString("yyyyMMddHHmmssff");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(ds.Tables[0].Rows[i][0].ToString()))
                    {
                        continue;
                    }

                    if (tablename == "SalaryGZ")
                    {
                        string sql = @"INSERT INTO SalaryGZ				(id,code,name,inputdate,dept,Salary001,Salary002,Salary003,Salary004,Salary005,Salary006,Salary007,Salary008,Salary009,Salary010,Salary011,Salary012,Salary013,Salary014,Salary015,Salary016,Salary017,Salary018,Salary019,Salary020,Salary021,Salary022,Salary023,Salary024) 
				VALUES(@id,@code,@name,@inputdate,@dept,@Salary001,@Salary002,@Salary003,@Salary004,@Salary005,@Salary006,@Salary007,@Salary008,@Salary009,@Salary010,@Salary011,@Salary012,@Salary013,@Salary014,@Salary015,@Salary016,@Salary017,@Salary018,@Salary019,@Salary020,@Salary021,@Salary022,@Salary023,@Salary024)";
                        SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id", SqlDbType.VarChar,50){ Value =inputid},
				new SqlParameter("@code", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][0].ToString()},
                new SqlParameter("@name", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][1].ToString()},
				new SqlParameter("@inputdate", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][2].ToString()+"-01"},
				new SqlParameter("@dept", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][3].ToString() },
                new SqlParameter("@Salary001", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][4].ToString() },
                new SqlParameter("@Salary002", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][5].ToString() },
                new SqlParameter("@Salary003", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][6].ToString() },
                new SqlParameter("@Salary004", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][7].ToString() },
                new SqlParameter("@Salary005", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][8].ToString() },
                new SqlParameter("@Salary006", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][9].ToString() },
                new SqlParameter("@Salary007", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][10].ToString() },
                new SqlParameter("@Salary008", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][11].ToString() },
                new SqlParameter("@Salary009", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][12].ToString() },
                new SqlParameter("@Salary010", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][13].ToString() },
                new SqlParameter("@Salary011", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][14].ToString() },
                new SqlParameter("@Salary012", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][15].ToString() },
                new SqlParameter("@Salary013", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][16].ToString() },
                new SqlParameter("@Salary014", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][17].ToString() },
                new SqlParameter("@Salary015", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][18].ToString() },
                new SqlParameter("@Salary016", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][19].ToString() },
                new SqlParameter("@Salary017", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][20].ToString() },
                new SqlParameter("@Salary018", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][21].ToString() },
                new SqlParameter("@Salary019", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][22].ToString() },
                new SqlParameter("@Salary020", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][23].ToString() },
                new SqlParameter("@Salary021", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][24].ToString() },
                new SqlParameter("@Salary022", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][25].ToString() },
                new SqlParameter("@Salary023", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][26].ToString() },
                new SqlParameter("@Salary024", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][27].ToString() }

                
            };

                        dbHelper.Execute(sql, parameters);
                        ViewBag.SalaryGZ = postFile.FileName;
                    
                    }

                    if (tablename == "SalaryJJ")
                    {
                        string sql = @"INSERT INTO SalaryJJ		(id,code,name,inputdate,dept,Salary001,Salary002,Salary003,Salary004,Salary005,Salary006,Salary007,Salary008,Salary009,Salary010,Salary011,Salary012,Salary013) 
				VALUES(@id,@code,@name,@inputdate,@dept,@Salary001,@Salary002,@Salary003,@Salary004,@Salary005,@Salary006,@Salary007,@Salary008,@Salary009,@Salary010,@Salary011,@Salary012,@Salary013)";
                        SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id", SqlDbType.VarChar,50){ Value =inputid},
				new SqlParameter("@code", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][0].ToString()},
                new SqlParameter("@name", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][1].ToString()},
				new SqlParameter("@inputdate", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][2].ToString()+"-01"},
				new SqlParameter("@dept", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][3].ToString() },
                new SqlParameter("@Salary001", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][4].ToString() },
                new SqlParameter("@Salary002", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][5].ToString() },
                new SqlParameter("@Salary003", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][6].ToString() },
                new SqlParameter("@Salary004", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][7].ToString() },
                new SqlParameter("@Salary005", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][8].ToString() },
                new SqlParameter("@Salary006", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][9].ToString() },
                new SqlParameter("@Salary007", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][10].ToString() },
                new SqlParameter("@Salary008", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][11].ToString() },
                new SqlParameter("@Salary009", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][12].ToString() },
                new SqlParameter("@Salary010", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][13].ToString() },
                new SqlParameter("@Salary011", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][14].ToString() },
                new SqlParameter("@Salary012", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][15].ToString() },
                new SqlParameter("@Salary013", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][16].ToString() }


            };

                        dbHelper.Execute(sql, parameters);
                        ViewBag.SalaryJJ = postFile.FileName;
                    }

                    if (tablename == "SalaryOther")
                    {

                        string sql = @"INSERT INTO SalaryOther
(id,code,name,inputdate,dept,Salary001,Salary002,Salary003,Salary004,Salary005,Salary006,Salary007,Salary008,Salary009,Salary010,Salary011,Salary012,Salary013,Salary014,Salary015,Salary016,Salary017,Salary018,Salary019,Salary020,Salary021,Salary022,Salary023,Salary024,Salary025,Salary026,Salary027) 
				VALUES(@id,@code,@name,@inputdate,@dept,@Salary001,@Salary002,@Salary003,@Salary004,@Salary005,@Salary006,@Salary007,@Salary008,@Salary009,@Salary010,@Salary011,@Salary012,@Salary013,@Salary014,@Salary015,@Salary016,@Salary017,@Salary018,@Salary019,@Salary020,@Salary021,@Salary022,@Salary023,@Salary024,@Salary025,@Salary026,@Salary027)";
                        SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id", SqlDbType.VarChar,50){ Value =inputid},
				new SqlParameter("@code", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][0].ToString()},
                new SqlParameter("@name", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][1].ToString()},
				new SqlParameter("@inputdate", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][2].ToString()+"-01"},
				new SqlParameter("@dept", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][3].ToString() },
                new SqlParameter("@Salary001", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][4].ToString() },
                new SqlParameter("@Salary002", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][5].ToString() },
                new SqlParameter("@Salary003", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][6].ToString() },
                new SqlParameter("@Salary004", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][7].ToString() },
                new SqlParameter("@Salary005", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][8].ToString() },
                new SqlParameter("@Salary006", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][9].ToString() },
                new SqlParameter("@Salary007", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][10].ToString() },
                new SqlParameter("@Salary008", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][11].ToString() },
                new SqlParameter("@Salary009", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][12].ToString() },
                new SqlParameter("@Salary010", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][13].ToString() },
                new SqlParameter("@Salary011", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][14].ToString() },
                new SqlParameter("@Salary012", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][15].ToString() },
                new SqlParameter("@Salary013", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][16].ToString() },
                new SqlParameter("@Salary014", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][17].ToString() },
                new SqlParameter("@Salary015", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][18].ToString() },
                new SqlParameter("@Salary016", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][19].ToString() },
                new SqlParameter("@Salary017", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][20].ToString() },
                new SqlParameter("@Salary018", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][21].ToString() },
                new SqlParameter("@Salary019", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][22].ToString() },
                new SqlParameter("@Salary020", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][23].ToString() },
                new SqlParameter("@Salary021", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][24].ToString() },
                new SqlParameter("@Salary022", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][25].ToString() },
                new SqlParameter("@Salary023", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][26].ToString() },
                new SqlParameter("@Salary024", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][27].ToString() },
                new SqlParameter("@Salary025", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][28].ToString() },
                new SqlParameter("@Salary026", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][29].ToString() },
                new SqlParameter("@Salary027", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][30].ToString() }
            };

                        dbHelper.Execute(sql, parameters);
                        ViewBag.SalaryOther = postFile.FileName;

                    }

                    if (tablename == "SalaryReturnGZ")
                    {

                        string sql = @"INSERT INTO SalaryReturnGZ				(id,code,name,inputdate,dept,Salary001,Salary002,Salary003,Salary004,Salary005,Salary006,Salary007,Salary008,Salary009,Salary010,Salary011,Salary012,Salary013,Salary014,Salary015,Salary016) 
				VALUES(@id,@code,@name,@inputdate,@dept,@Salary001,@Salary002,@Salary003,@Salary004,@Salary005,@Salary006,@Salary007,@Salary008,@Salary009,@Salary010,@Salary011,@Salary012,@Salary013,@Salary014,@Salary015,@Salary016)";
                        SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id", SqlDbType.VarChar,50){ Value =inputid},
				new SqlParameter("@code", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][0].ToString()},
                new SqlParameter("@name", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][1].ToString()},
				new SqlParameter("@inputdate", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][2].ToString()+"-01"},
				new SqlParameter("@dept", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][3].ToString() },
               new SqlParameter("@Salary001", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][4].ToString() },
                new SqlParameter("@Salary002", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][5].ToString() },
                new SqlParameter("@Salary003", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][6].ToString() },
                new SqlParameter("@Salary004", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][7].ToString() },
                new SqlParameter("@Salary005", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][8].ToString() },
                new SqlParameter("@Salary006", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][9].ToString() },
                new SqlParameter("@Salary007", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][10].ToString() },
                new SqlParameter("@Salary008", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][11].ToString() },
                new SqlParameter("@Salary009", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][12].ToString() },
                new SqlParameter("@Salary010", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][13].ToString() },
                new SqlParameter("@Salary011", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][14].ToString() },
                new SqlParameter("@Salary012", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][15].ToString() },
                new SqlParameter("@Salary013", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][16].ToString() },
                new SqlParameter("@Salary014", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][17].ToString() },
                new SqlParameter("@Salary015", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][18].ToString() },
                new SqlParameter("@Salary016", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][19].ToString() }
                
            };

                        dbHelper.Execute(sql, parameters);
                        ViewBag.SalaryReturnGZ = postFile.FileName;

                    }

                    if (tablename == "SalaryReturnJJ")
                    {

                        string sql = @"INSERT INTO SalaryReturnJJ			(id,code,name,inputdate,dept,Salary001,Salary002,Salary003,Salary004,Salary005,Salary006,Salary007,Salary008,Salary009,Salary010,Salary011,Salary012,Salary013,Salary014,Salary015,Salary016,Salary017,Salary018,Salary019,Salary020,Salary021,Salary022,Salary023,Salary024,Salary025,Salary026) 
				VALUES(@id,@code,@name,@inputdate,@dept,@Salary001,@Salary002,@Salary003,@Salary004,@Salary005,@Salary006,@Salary007,@Salary008,@Salary009,@Salary010,@Salary011,@Salary012,@Salary013,@Salary014,@Salary015,@Salary016,@Salary017,@Salary018,@Salary019,@Salary020,@Salary021,@Salary022,@Salary023,@Salary024,@Salary025,@Salary026)";
                        SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id", SqlDbType.VarChar,50){ Value =inputid},
				new SqlParameter("@code", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][0].ToString()},
                new SqlParameter("@name", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][1].ToString()},
				new SqlParameter("@inputdate", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][2].ToString()+"-01"},
				new SqlParameter("@dept", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][3].ToString() },
                new SqlParameter("@Salary001", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][4].ToString() },
                new SqlParameter("@Salary002", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][5].ToString() },
                new SqlParameter("@Salary003", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][6].ToString() },
                new SqlParameter("@Salary004", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][7].ToString() },
                new SqlParameter("@Salary005", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][8].ToString() },
                new SqlParameter("@Salary006", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][9].ToString() },
                new SqlParameter("@Salary007", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][10].ToString() },
                new SqlParameter("@Salary008", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][11].ToString() },
                new SqlParameter("@Salary009", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][12].ToString() },
                new SqlParameter("@Salary010", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][13].ToString() },
                new SqlParameter("@Salary011", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][14].ToString() },
                new SqlParameter("@Salary012", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][15].ToString() },
                new SqlParameter("@Salary013", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][16].ToString() },
                new SqlParameter("@Salary014", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][17].ToString() },
                new SqlParameter("@Salary015", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][18].ToString() },
                new SqlParameter("@Salary016", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][19].ToString() },
                new SqlParameter("@Salary017", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][20].ToString() },
                new SqlParameter("@Salary018", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][21].ToString() },
                new SqlParameter("@Salary019", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][22].ToString() },
                new SqlParameter("@Salary020", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][23].ToString() },
                new SqlParameter("@Salary021", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][24].ToString() },
                new SqlParameter("@Salary022", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][25].ToString() },
                new SqlParameter("@Salary023", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][26].ToString() },
                new SqlParameter("@Salary024", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][27].ToString() },
                new SqlParameter("@Salary025", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][28].ToString() },
                new SqlParameter("@Salary026", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][29].ToString() }
                
            };

                        dbHelper.Execute(sql, parameters);
                        ViewBag.SalaryReturnJJ = postFile.FileName;

                    }

                    if (tablename == "SalaryCountryDocGZ")
                    {

                        string sql = @"INSERT INTO SalaryCountryDocGZ				(id,code,name,inputdate,dept,Salary001,Salary002,Salary003,Salary004,Salary005,Salary006,Salary007,Salary008,Salary009,Salary010,Salary011,Salary012,Salary013,Salary014) 
				VALUES(@id,@code,@name,@inputdate,@dept,@Salary001,@Salary002,@Salary003,@Salary004,@Salary005,@Salary006,@Salary007,@Salary008,@Salary009,@Salary010,@Salary011,@Salary012,@Salary013,@Salary014)";
                        SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id", SqlDbType.VarChar,50){ Value =inputid},
				new SqlParameter("@code", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][0].ToString()},
                new SqlParameter("@name", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][1].ToString()},
				new SqlParameter("@inputdate", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][2].ToString()+"-01"},
				new SqlParameter("@dept", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][3].ToString() },
                new SqlParameter("@Salary001", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][4].ToString() },
                new SqlParameter("@Salary002", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][5].ToString() },
                new SqlParameter("@Salary003", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][6].ToString() },
                new SqlParameter("@Salary004", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][7].ToString() },
                new SqlParameter("@Salary005", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][8].ToString() },
                new SqlParameter("@Salary006", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][9].ToString() },
                new SqlParameter("@Salary007", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][10].ToString() },
                new SqlParameter("@Salary008", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][11].ToString() },
                new SqlParameter("@Salary009", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][12].ToString() },
                new SqlParameter("@Salary010", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][13].ToString() },
                new SqlParameter("@Salary011", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][14].ToString() },
                new SqlParameter("@Salary012", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][15].ToString() },
                new SqlParameter("@Salary013", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][16].ToString() },
                new SqlParameter("@Salary014", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][17].ToString() }
                
            };

                        dbHelper.Execute(sql, parameters);
                        ViewBag.SalaryCountryDocGZ = postFile.FileName;

                    }

                    if (tablename == "SalaryCountryDocJJ")
                    {

                        string sql = @"INSERT INTO SalaryCountryDocJJ			(id,code,name,inputdate,dept,Salary001,Salary002,Salary003,Salary004,Salary005,Salary006,Salary007,Salary008) 
				VALUES(@id,@code,@name,@inputdate,@dept,@Salary001,@Salary002,@Salary003,@Salary004,@Salary005,@Salary006,@Salary007,@Salary008)";
                        SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id", SqlDbType.VarChar,50){ Value =inputid},
				new SqlParameter("@code", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][0].ToString()},
                new SqlParameter("@name", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][1].ToString()},
				new SqlParameter("@inputdate", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][2].ToString()+"-01"},
				new SqlParameter("@dept", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][3].ToString() },
                new SqlParameter("@Salary001", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][4].ToString() },
                new SqlParameter("@Salary002", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][5].ToString() },
                new SqlParameter("@Salary003", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][6].ToString() },
                new SqlParameter("@Salary004", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][7].ToString() },
                new SqlParameter("@Salary005", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][8].ToString() },
                new SqlParameter("@Salary006", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][9].ToString() },
                new SqlParameter("@Salary007", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][10].ToString() },
                new SqlParameter("@Salary008", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][11].ToString() }
                
            };

                        dbHelper.Execute(sql, parameters);
                        ViewBag.SalaryCountryDocJJ = postFile.FileName;

                    }

                    if (tablename == "SalaryGZON")
                    {

                        string sql = @"INSERT INTO SalaryGZON
(id,code,name,inputdate,dept,Salary001,Salary002,Salary003,Salary004,Salary005,Salary006,Salary007,Salary008,Salary009,Salary010,Salary011,Salary012,Salary013,Salary014,Salary015,Salary016,Salary017,Salary018,Salary019,Salary020,Salary021,Salary022,Salary023,Salary024,Salary025,Salary026,Salary027,Salary028,Salary029,Salary030,Salary031) 
				VALUES(@id,@code,@name,@inputdate,@dept,@Salary001,@Salary002,@Salary003,@Salary004,@Salary005,@Salary006,@Salary007,@Salary008,@Salary009,@Salary010,@Salary011,@Salary012,@Salary013,@Salary014,@Salary015,@Salary016,@Salary017,@Salary018,@Salary019,@Salary020,@Salary021,@Salary022,@Salary023,@Salary024,@Salary025,@Salary026,@Salary027,@Salary028,@Salary029,@Salary030,@Salary031)";
                        SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id", SqlDbType.VarChar,50){ Value =inputid},
				new SqlParameter("@code", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][0].ToString()},
                new SqlParameter("@name", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][1].ToString()},
				new SqlParameter("@inputdate", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][2].ToString()+"-01"},
				new SqlParameter("@dept", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][3].ToString() },
                new SqlParameter("@Salary001", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][4].ToString() },
                new SqlParameter("@Salary002", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][5].ToString() },
                new SqlParameter("@Salary003", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][6].ToString() },
                new SqlParameter("@Salary004", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][7].ToString() },
                new SqlParameter("@Salary005", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][8].ToString() },
                new SqlParameter("@Salary006", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][9].ToString() },
                new SqlParameter("@Salary007", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][10].ToString() },
                new SqlParameter("@Salary008", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][11].ToString() },
                new SqlParameter("@Salary009", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][12].ToString() },
                new SqlParameter("@Salary010", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][13].ToString() },
                new SqlParameter("@Salary011", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][14].ToString() },
                new SqlParameter("@Salary012", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][15].ToString() },
                new SqlParameter("@Salary013", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][16].ToString() },
                new SqlParameter("@Salary014", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][17].ToString() },
                new SqlParameter("@Salary015", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][18].ToString() },
                new SqlParameter("@Salary016", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][19].ToString() },
                new SqlParameter("@Salary017", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][20].ToString() },
                new SqlParameter("@Salary018", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][21].ToString() },
                new SqlParameter("@Salary019", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][22].ToString() },
                new SqlParameter("@Salary020", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][23].ToString() },
                new SqlParameter("@Salary021", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][24].ToString() },
                new SqlParameter("@Salary022", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][25].ToString() },
                new SqlParameter("@Salary023", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][26].ToString() },
                new SqlParameter("@Salary024", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][27].ToString() },
                new SqlParameter("@Salary025", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][28].ToString() },
                new SqlParameter("@Salary026", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][29].ToString() },
                new SqlParameter("@Salary027", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][30].ToString() },
                new SqlParameter("@Salary028", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][31].ToString() },
                new SqlParameter("@Salary029", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][32].ToString() },
                new SqlParameter("@Salary030", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][33].ToString() },
                new SqlParameter("@Salary031", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][34].ToString() }
                
            };

                        dbHelper.Execute(sql, parameters);
                        ViewBag.SalaryGZON = postFile.FileName;

                    }

                    if (tablename == "SalaryJJON")
                    {

                        string sql = @"INSERT INTO SalaryJJON
(id,code,name,inputdate,dept,Salary001,Salary002,Salary003,Salary004,Salary005,Salary006,Salary007,Salary008,Salary009,Salary010,Salary011,Salary012,Salary013,Salary014) 
				VALUES(@id,@code,@name,@inputdate,@dept,@Salary001,@Salary002,@Salary003,@Salary004,@Salary005,@Salary006,@Salary007,@Salary008,@Salary009,@Salary010,@Salary011,@Salary012,@Salary013,@Salary014)";
                        SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id", SqlDbType.VarChar,50){ Value =inputid},
				new SqlParameter("@code", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][0].ToString()},
                new SqlParameter("@name", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][1].ToString()},
				new SqlParameter("@inputdate", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][2].ToString()+"-01"},
				new SqlParameter("@dept", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][3].ToString() },
                new SqlParameter("@Salary001", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][4].ToString() },
                new SqlParameter("@Salary002", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][5].ToString() },
                new SqlParameter("@Salary003", SqlDbType.Float){ Value = 0.ToString() },
                new SqlParameter("@Salary004", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][6].ToString() },
                new SqlParameter("@Salary005", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][7].ToString() },
                new SqlParameter("@Salary006", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][8].ToString() },
                new SqlParameter("@Salary007", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][9].ToString() },
                new SqlParameter("@Salary008", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][10].ToString() },
                new SqlParameter("@Salary009", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][11].ToString() },
                new SqlParameter("@Salary010", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][12].ToString() },
                new SqlParameter("@Salary011", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][13].ToString() },
                new SqlParameter("@Salary012", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][14].ToString() },
                new SqlParameter("@Salary013", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][15].ToString() },
                new SqlParameter("@Salary014", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][16].ToString() }

            };

                        dbHelper.Execute(sql, parameters);
                        ViewBag.SalaryJJON = postFile.FileName;

                    }

                    if (tablename == "SalaryOtherON")
                    {

                        string sql = @"INSERT INTO SalaryOtherON				(id,code,name,inputdate,dept,Salary001,Salary002,Salary003,Salary004,Salary005,Salary006,Salary007,Salary008,Salary009,Salary010,Salary011,Salary012,Salary013,Salary014,Salary015,Salary016,Salary017,Salary018,Salary019,Salary020,Salary021,Salary022,Salary023,Salary024,Salary025,Salary026,Salary027,Salary028) 
				VALUES(@id,@code,@name,@inputdate,@dept,@Salary001,@Salary002,@Salary003,@Salary004,@Salary005,@Salary006,@Salary007,@Salary008,@Salary009,@Salary010,@Salary011,@Salary012,@Salary013,@Salary014,@Salary015,@Salary016,@Salary017,@Salary018,@Salary019,@Salary020,@Salary021,@Salary022,@Salary023,@Salary024,@Salary025,@Salary026,@Salary027,@Salary028)";
                        SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id", SqlDbType.VarChar,50){ Value =inputid},
				new SqlParameter("@code", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][0].ToString()},
                new SqlParameter("@name", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][1].ToString()},
				new SqlParameter("@inputdate", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][2].ToString()+"-01"},
				new SqlParameter("@dept", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][3].ToString() },
                new SqlParameter("@account", SqlDbType.VarChar,50){ Value = ds.Tables[0].Rows[i][4].ToString() },
                new SqlParameter("@Salary001", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][4].ToString() },
                new SqlParameter("@Salary002", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][5].ToString() },
                new SqlParameter("@Salary003", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][6].ToString() },
                new SqlParameter("@Salary004", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][7].ToString() },
                new SqlParameter("@Salary005", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][8].ToString() },
                new SqlParameter("@Salary006", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][9].ToString() },
                new SqlParameter("@Salary007", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][10].ToString() },
                new SqlParameter("@Salary008", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][11].ToString() },
                new SqlParameter("@Salary009", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][12].ToString() },
                new SqlParameter("@Salary010", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][13].ToString() },
                new SqlParameter("@Salary011", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][14].ToString() },
                new SqlParameter("@Salary012", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][15].ToString() },
                new SqlParameter("@Salary013", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][16].ToString() },
                new SqlParameter("@Salary014", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][17].ToString() },
                new SqlParameter("@Salary015", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][18].ToString() },
                new SqlParameter("@Salary016", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][19].ToString() },
                new SqlParameter("@Salary017", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][20].ToString() },
                new SqlParameter("@Salary018", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][21].ToString() },
                new SqlParameter("@Salary019", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][22].ToString() },
                new SqlParameter("@Salary020", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][23].ToString() },
                new SqlParameter("@Salary021", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][24].ToString() },
                new SqlParameter("@Salary022", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][25].ToString() },
                new SqlParameter("@Salary023", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][26].ToString() },
                new SqlParameter("@Salary024", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][27].ToString() },
                new SqlParameter("@Salary025", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][28].ToString() },
                new SqlParameter("@Salary026", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][29].ToString() },
                new SqlParameter("@Salary027", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][30].ToString() },
                new SqlParameter("@Salary028", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][31].ToString() }

                
            };

                        dbHelper.Execute(sql, parameters);
                        ViewBag.SalaryOtherON = postFile.FileName;

                    }

                    


                }



                ViewBag.Script = "alert('导入成功!');";


            }







            return View();
        }

    }
}
