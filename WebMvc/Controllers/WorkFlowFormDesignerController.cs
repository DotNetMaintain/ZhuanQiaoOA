using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Globalization;

namespace WebMvc.Controllers
{
    public class WorkFlowFormDesignerController : Controller
    {
        //
        // GET: /WorkFlowFormDesigner/
        [ValidateInput(false)]
        public ActionResult Index()
        {
            return View();
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Index(string Information)
        {
            ViewData["kindeditor"] = Information;
            return View();
   
        }



        public ActionResult ProcessRequest()
        {
            //String aspxUrl = context.Request.Path.Substring(0, context.Request.Path.LastIndexOf("/") + 1);

            //根目录路径，相对路径
            String rootPath = "/UploadImages/";
            //根目录URL，可以指定绝对路径，
            String rootUrl = "/UploadImages/";
            //图片扩展名
            String fileTypes = "gif,jpg,jpeg,png,bmp";

            String currentPath = "";
            String currentUrl = "";
            String currentDirPath = "";
            String moveupDirPath = "";

            //根据path参数，设置各路径和URL
            String path = Request.QueryString["path"];
            path = String.IsNullOrEmpty(path) ? "" : path;
            if (path == "")
            {
                currentPath = Server.MapPath(rootPath);
                currentUrl = rootUrl;
                currentDirPath = "";
                moveupDirPath = "";
            }
            else
            {
                currentPath = Server.MapPath(rootPath) + path;
                currentUrl = rootUrl + path;
                currentDirPath = path;
                moveupDirPath = Regex.Replace(currentDirPath, @"(.*?)[^\/]+\/$", "$1");
            }

            //排序形式，name or size or type
            String order = Request.QueryString["order"];
            order = String.IsNullOrEmpty(order) ? "" : order.ToLower();

            //不允许使用..移动到上一级目录
            if (Regex.IsMatch(path, @"\.\."))
            {
                Response.Write("Access is not allowed.");
                Response.End();
            }
            //最后一个字符不是/
            if (path != "" && !path.EndsWith("/"))
            {
                Response.Write("Parameter is not valid.");
                Response.End();
            }
            //目录不存在或不是目录
            if (!Directory.Exists(currentPath))
            {
                Response.Write("Directory does not exist.");
                Response.End();
            }

            //遍历目录取得文件信息
            string[] dirList = Directory.GetDirectories(currentPath);
            string[] fileList = Directory.GetFiles(currentPath);

            switch (order)
            {
                case "size":
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new SizeSorter());
                    break;
                case "type":
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new TypeSorter());
                    break;
                case "name":
                default:
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new NameSorter());
                    break;
            }

            Hashtable result = new Hashtable();
            result["moveup_dir_path"] = moveupDirPath;
            result["current_dir_path"] = currentDirPath;
            result["current_url"] = currentUrl;
            result["total_count"] = dirList.Length + fileList.Length;
            List<Hashtable> dirFileList = new List<Hashtable>();
            result["file_list"] = dirFileList;
            for (int i = 0; i < dirList.Length; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(dirList[i]);
                Hashtable hash = new Hashtable();
                hash["is_dir"] = true;
                hash["has_file"] = (dir.GetFileSystemInfos().Length > 0);
                hash["filesize"] = 0;
                hash["is_photo"] = false;
                hash["filetype"] = "";
                hash["filename"] = dir.Name;
                hash["datetime"] = dir.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                dirFileList.Add(hash);
            }
            for (int i = 0; i < fileList.Length; i++)
            {
                FileInfo file = new FileInfo(fileList[i]);
                Hashtable hash = new Hashtable();
                hash["is_dir"] = false;
                hash["has_file"] = false;
                hash["filesize"] = file.Length;
                hash["is_photo"] = (Array.IndexOf(fileTypes.Split(','), file.Extension.Substring(1).ToLower()) >= 0);
                hash["filetype"] = file.Extension.Substring(1);
                hash["filename"] = file.Name;
                hash["datetime"] = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                dirFileList.Add(hash);
            }
            //Response.AddHeader("Content-Type", "application/json; charset=UTF-8");
            //context.Response.Write(JsonMapper.ToJson(result));
            //context.Response.End();
            return Json(result, "text/html;charset=UTF-8", JsonRequestBehavior.AllowGet);
        }

        public class NameSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x == null && y == null)
                {
                    return 0;
                }
                if (x == null)
                {
                    return -1;
                }
                if (y == null)
                {
                    return 1;
                }
                FileInfo xInfo = new FileInfo(x.ToString());
                FileInfo yInfo = new FileInfo(y.ToString());

                return xInfo.FullName.CompareTo(yInfo.FullName);
            }
        }


        public class SizeSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x == null && y == null)
                {
                    return 0;
                }
                if (x == null)
                {
                    return -1;
                }
                if (y == null)
                {
                    return 1;
                }
                FileInfo xInfo = new FileInfo(x.ToString());
                FileInfo yInfo = new FileInfo(y.ToString());

                return xInfo.Length.CompareTo(yInfo.Length);
            }
        }

        public class TypeSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x == null && y == null)
                {
                    return 0;
                }
                if (x == null)
                {
                    return -1;
                }
                if (y == null)
                {
                    return 1;
                }
                FileInfo xInfo = new FileInfo(x.ToString());
                FileInfo yInfo = new FileInfo(y.ToString());

                return xInfo.Extension.CompareTo(yInfo.Extension);
            }
        }


        [HttpPost]
        public ActionResult UploadImage()
        {
            string savePath = "/UploadImages/";
            string saveUrl = "/UploadImages/";
            string fileTypes = "gif,jpg,jpeg,png,bmp";
            int maxSize = 1000000;

            Hashtable hash = new Hashtable();

            HttpPostedFileBase file = Request.Files["imgFile"];
            if (file == null)
            {
                hash = new Hashtable();
                hash["error"] = 1;
                hash["message"] = "请选择文件";
                return Json(hash, "text/html;charset=UTF-8");
            }

            string dirPath = Server.MapPath(savePath);
            if (!Directory.Exists(dirPath))
            {
                hash = new Hashtable();
                hash["error"] = 1;
                hash["message"] = "上传目录不存在";
                return Json(hash, "text/html;charset=UTF-8");
            }

            string fileName = file.FileName;
            string fileExt = Path.GetExtension(fileName).ToLower();

            ArrayList fileTypeList = ArrayList.Adapter(fileTypes.Split(','));

            if (file.InputStream == null || file.InputStream.Length > maxSize)
            {
                hash = new Hashtable();
                hash["error"] = 1;
                hash["message"] = "上传文件大小超过限制";
                return Json(hash, "text/html;charset=UTF-8");
            }

            if (string.IsNullOrEmpty(fileExt) || Array.IndexOf(fileTypes.Split(','), fileExt.Substring(1).ToLower()) == -1)
            {
                hash = new Hashtable();
                hash["error"] = 1;
                hash["message"] = "上传文件扩展名是不允许的扩展名";
                return Json(hash, "text/html;charset=UTF-8");
            }

            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
            string filePath = dirPath + newFileName;
            file.SaveAs(filePath);
            string fileUrl = saveUrl + newFileName;

            hash = new Hashtable();
            hash["error"] = 0;
            hash["url"] = fileUrl;

            return Json(hash, "text/html;charset=UTF-8");
        }


        public string GetHtml()
        {
            string id = Request["id"];
            Guid gid;
            if (!id.IsGuid(out gid))
            {
                return "";
            }

            var wff = new Business.Platform.WorkFlowForm().Get(gid);
            if (wff == null)
            {
                return "";
            }
            else
            {
                return wff.Html;
            }
        }

        public string GetAttribute()
        {
            string id = Request["id"];
            Guid gid;
            if (!id.IsGuid(out gid))
            {
                return "";
            }

            var wff = new Business.Platform.WorkFlowForm().Get(gid);
            if (wff == null)
            {
                return "";
            }
            else
            {
                return wff.Attribute;
            }
        }

        public string Getsubtable()
        {
            string id = Request["id"];
            Guid gid;
            if (!id.IsGuid(out gid))
            {
                return "";
            }

            var wff = new Business.Platform.WorkFlowForm().Get(gid);
            if (wff == null)
            {
                return "";
            }
            else
            {
                return wff.SubTableJson;
            }
        }

        public string GetEvents()
        {
            string id = Request["id"];
            Guid gid;
            if (!id.IsGuid(out gid))
            {
                return "";
            }

            var wff = new Business.Platform.WorkFlowForm().Get(gid);
            if (wff == null)
            {
                return "";
            }
            else
            {
                return wff.EventsJson;
            }
        }

        public string TestSql()
        {
            string sql = Request["sql"];
            string dbconn = Request["dbconn"];

            if (sql.IsNullOrEmpty() || !dbconn.IsGuid())
            {
                return "SQL语句为空或未设置数据连接";
            }

            Business.Platform.DBConnection bdbconn = new Business.Platform.DBConnection();
            var dbconn1 = bdbconn.Get(dbconn.ToGuid());
            if (bdbconn.TestSql(dbconn1, sql))
            {
                return "SQL语句测试正确";
            }
            else
            {
                return "SQL语句测试错误";
            }
        }

        public string Save()
        {
            string html = Request["html"];
            string name = Request["name"];
            string att = Request["att"];
            string id = Request["id"];
            string type = Request["type"];
            string subtable = Request["subtable"];
            string formEvents = Request["formEvents"];
            if (name.IsNullOrEmpty())
            {
                return "表单名称不能为空!";
            }

            Guid formID;
            if (!id.IsGuid(out formID))
            {
                return "表单ID无效!";
            }

            Business.Platform.WorkFlowForm WFF = new Business.Platform.WorkFlowForm();
            Data.Model.WorkFlowForm wff = WFF.Get(formID);
            bool isAdd = false;
            string oldXML = string.Empty;
            if (wff == null)
            {
                wff = new Data.Model.WorkFlowForm();
                wff.ID = formID;
                wff.Type = type.ToGuid();
                wff.CreateUserID = Business.Platform.Users.CurrentUserID;
                wff.CreateUserName = Business.Platform.Users.CurrentUserName;
                wff.CreateTime = Utility.DateTimeNew.Now;
                wff.Status = 0;
                isAdd = true;
            }
            else
            {
                oldXML = wff.Serialize();
            }

            wff.Attribute = att;
            wff.Html = html;
            wff.LastModifyTime = Utility.DateTimeNew.Now;
            wff.Name = name;
            wff.SubTableJson = subtable;
            wff.EventsJson = formEvents;

            if (isAdd)
            {
                WFF.Add(wff);
                Business.Platform.Log.Add("添加了流程表单", wff.Serialize(), Business.Platform.Log.Types.流程相关);
            }
            else
            {
                WFF.Update(wff);
                Business.Platform.Log.Add("修改了流程表单", "", Business.Platform.Log.Types.流程相关, oldXML, wff.Serialize());
            }
            return "保存成功!";
        }

        public string GetSubTableData()
        {
            string secondtable = Request["secondtable"];
            string primarytablefiled = Request["primarytablefiled"];
            string secondtableprimarykey = Request["secondtableprimarykey"];
            string primarytablefiledvalue = Request["primarytablefiledvalue"];
            string secondtablerelationfield = Request["secondtablerelationfield"];
            string dbconnid = Request["dbconnid"];
            LitJson.JsonData data = new Business.Platform.WorkFlow().GetSubTableData(dbconnid, secondtable, secondtablerelationfield, primarytablefiledvalue, secondtableprimarykey);
            return data.ToJson();
        }

        
        public string Publish()
        {
            string html = Request["html"];
            string name = Request["name"];
            string att = Request["att"];
            string id = Request["id"];

            Guid gid;
            if (!id.IsGuid(out gid) || name.IsNullOrEmpty() || att.IsNullOrEmpty() || html.IsNullOrEmpty())
            {
                return "参数错误!";
            }
            Business.Platform.WorkFlowForm WFF = new Business.Platform.WorkFlowForm();

            Data.Model.WorkFlowForm wff = WFF.Get(gid);
            if (wff == null)
            {
                return "未找到表单!";
            }

            string fileName = id + ".cshtml";

            System.Text.StringBuilder serverScript = new System.Text.StringBuilder("@{\r\n");
            var attrJSON = LitJson.JsonMapper.ToObject(att);
            serverScript.Append("\tstring FlowID = Request.QueryString[\"flowid\"];\r\n");
            serverScript.Append("\tstring StepID = Request.QueryString[\"stepid\"];\r\n");
            serverScript.Append("\tstring GroupID = Request.QueryString[\"groupid\"];\r\n");
            serverScript.Append("\tstring TaskID = Request.QueryString[\"taskid\"];\r\n");
            serverScript.Append("\tstring InstanceID = Request.QueryString[\"instanceid\"];\r\n");
            serverScript.Append("\tstring DisplayModel = Request.QueryString[\"display\"] ?? \"0\";\r\n");
            serverScript.AppendFormat("\tstring DBConnID = \"{0}\";\r\n", attrJSON["dbconn"].ToString());
            serverScript.AppendFormat("\tstring DBTable = \"{0}\";\r\n", attrJSON["dbtable"].ToString());
            serverScript.AppendFormat("\tstring DBTablePK = \"{0}\";\r\n", attrJSON["dbtablepk"].ToString());
            serverScript.AppendFormat("\tstring DBTableTitle = \"{0}\";\r\n", attrJSON["dbtabletitle"].ToString());

            serverScript.Append("\tBusiness.Platform.Dictionary BDictionary = new Business.Platform.Dictionary();\r\n");
            serverScript.Append("\tBusiness.Platform.WorkFlow BWorkFlow = new Business.Platform.WorkFlow();\r\n");
            serverScript.Append("\tBusiness.Platform.WorkFlowTask BWorkFlowTask = new Business.Platform.WorkFlowTask();\r\n");
            serverScript.Append("\tstring fieldStatus = BWorkFlow.GetFieldStatus(FlowID, StepID);\r\n");
            serverScript.Append("\tLitJson.JsonData initData = BWorkFlow.GetFormData(DBConnID, DBTable, DBTablePK, InstanceID, fieldStatus);\r\n");
            serverScript.Append("\tstring TaskTitle = BWorkFlow.GetFromFieldData(initData, DBTable, DBTableTitle);\r\n");

            serverScript.Append("}\r\n");
            serverScript.Append("<link href=\"~/Scripts/FlowRun/Forms/flowform.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
            serverScript.Append("<script src=\"~/Scripts/FlowRun/Forms/common.js\" type=\"text/javascript\" ></script>\r\n");

            if (attrJSON.ContainsKey("hasEditor") && "1" == attrJSON["hasEditor"].ToString())
            {
                serverScript.Append("<script src=\"~/Scripts/Ueditor/ueditor.config.js\" type=\"text/javascript\" ></script>\r\n");
                serverScript.Append("<script src=\"~/Scripts/Ueditor/ueditor.all.min.js\" type=\"text/javascript\" ></script>\r\n");
                serverScript.Append("<script src=\"~/Scripts/Ueditor/lang/zh-cn/zh-cn.js\" type=\"text/javascript\" ></script>\r\n");
                serverScript.Append("<input type=\"hidden\" id=\"Form_HasUEditor\" name=\"Form_HasUEditor\" value=\"1\" />\r\n");
            }
            string validatePropType = attrJSON.ContainsKey("validatealerttype") ? attrJSON["validatealerttype"].ToString() : "2";
            serverScript.Append("<input type=\"hidden\" id=\"Form_ValidateAlertType\" name=\"Form_ValidateAlertType\" value=\"" + validatePropType + "\" />\r\n");
            if (attrJSON.ContainsKey("autotitle") && attrJSON["autotitle"].ToString().ToLower() == "true")
            {
                serverScript.AppendFormat("<input type=\"hidden\" id=\"{0}\" name=\"{0}\" value=\"{1}\" />\r\n",
                    string.Concat(attrJSON["dbtable"].ToString(), ".", attrJSON["dbtabletitle"].ToString()),
                    "@(TaskTitle.IsNullOrEmpty() ? BWorkFlow.GetAutoTaskTitle(FlowID, StepID, Request.QueryString[\"groupid\"]) : TaskTitle)"
                    );
            }
            serverScript.AppendFormat("<input type=\"hidden\" id=\"Form_TitleField\" name=\"Form_TitleField\" value=\"{0}\" />\r\n", string.Concat(attrJSON["dbtable"].ToString(), ".", attrJSON["dbtabletitle"].ToString()));
            //serverScript.AppendFormat("<input type=\"hidden\" id=\"Form_Name\" name=\"Form_Name\" value=\"{0}\" />\r\n", attrJSON["name"].ToString());
            serverScript.AppendFormat("<input type=\"hidden\" id=\"Form_DBConnID\" name=\"Form_DBConnID\" value=\"{0}\" />\r\n", attrJSON["dbconn"].ToString());
            serverScript.AppendFormat("<input type=\"hidden\" id=\"Form_DBTable\" name=\"Form_DBTable\" value=\"{0}\" />\r\n", attrJSON["dbtable"].ToString());
            serverScript.AppendFormat("<input type=\"hidden\" id=\"Form_DBTablePk\" name=\"Form_DBTablePk\" value=\"{0}\" />\r\n", attrJSON["dbtablepk"].ToString());
            serverScript.AppendFormat("<input type=\"hidden\" id=\"Form_DBTableTitle\" name=\"Form_DBTableTitle\" value=\"{0}\" />\r\n", attrJSON["dbtabletitle"].ToString());
            serverScript.AppendFormat("<input type=\"hidden\" id=\"Form_AutoSaveData\" name=\"Form_AutoSaveData\" value=\"{0}\" />\r\n", "1");
            serverScript.Append("<script type=\"text/javascript\">\r\n");
            serverScript.Append("\tvar initData = @Html.Raw(BWorkFlow.GetFormDataJsonString(initData));\r\n");
            serverScript.Append("\tvar fieldStatus = @Html.Raw(fieldStatus);\r\n");
            serverScript.Append("\tvar displayModel = '@DisplayModel';\r\n");
            serverScript.Append("\t$(function (){\r\n");
            serverScript.AppendFormat("\t\tformrun.initData(initData, \"{0}\", fieldStatus, displayModel);\r\n", attrJSON["dbtable"].ToString());
            serverScript.Append("\t});\r\n");
            serverScript.Append("</script>\r\n");


            string file = Server.MapPath("~/Views/WorkFlowFormDesigner/Forms/" + fileName);
            System.IO.Stream stream = System.IO.File.Open(file, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            stream.SetLength(0);
           
            StreamWriter sw = new StreamWriter(stream, System.Text.Encoding.UTF8);
            sw.Write(serverScript.ToString());
            sw.Write(Server.HtmlDecode(html));
            
            sw.Close();
            stream.Close();


            string attr = wff.Attribute;
            string appType = LitJson.JsonMapper.ToObject(attr)["apptype"].ToString();
            Business.Platform.AppLibrary App = new Business.Platform.AppLibrary();
            var app = App.GetByCode(id);
            bool isAdd = false;
            if (app == null)
            {
                app = new Data.Model.AppLibrary();
                app.ID = Guid.NewGuid();
                app.Code = id;
                isAdd = true;
            }
            app.Address = "/Views/WorkFlowFormDesigner/Forms/" + fileName;
            app.Note = "流程表单";
            app.OpenMode = 0;
            app.Params = "";
            app.Title = name.Trim();
            app.Type = appType.IsGuid() ? appType.ToGuid() : new Business.Platform.Dictionary().GetIDByCode("FormTypes");
            if (isAdd)
            {
                App.Add(app);
            }
            else
            {
                App.Update(app);
            }

            Business.Platform.Log.Add("发布了流程表单", app.Serialize() + "内容：" + html, Business.Platform.Log.Types.流程相关);
            wff.Status = 1;
            WFF.Update(wff);
            return "发布成功!";
        }
    }
}
