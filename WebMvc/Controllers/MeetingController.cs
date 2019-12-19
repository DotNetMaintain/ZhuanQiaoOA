using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class MeetingController : MyController
    {
        //
        // GET: /Meeting/

        public ActionResult Index()
        {
            Business.Platform.Meeting bmeeting = new Business.Platform.Meeting();
            Business.Platform.Organize borganize = new Business.Platform.Organize();


            List<Data.Model.Meeting> lstmeeting = bmeeting.GetAll();


            return View(lstmeeting);
        }

        public ActionResult Meeting_Manage()
        {
            return Meeting_Manage(null);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Meeting_Manage(FormCollection collection)
        {
            string Title = string.Empty;
            string Address = string.Empty;
            string Chaired = string.Empty;
            string Recorder = string.Empty;
            string CTime = string.Empty;
            string acceptdept = string.Empty;
   
            Business.Platform.Meeting bnotebook = new Business.Platform.Meeting();
            Data.Model.Meeting notebook = new Data.Model.Meeting();


            string id = Request.QueryString["id"];
            if (id != null)
            {

               // Guid gnewsid = new Guid(id);
                Data.Model.Meeting notebookid = bnotebook.Get(id.ToInt32());
                if (notebook == null)
                {
                    notebookid.guid = id;
                    notebook.Bodys = "";
                    notebook.AbsencePerson = "";
                    notebookid.UserID = "";
                    notebook.Address = "";
                    notebookid.MainTopics = "";
                    notebookid.AddTime = System.DateTime.Now;


                }
                else
                {
                    notebook = notebookid;
                }

            }

            if (collection != null)
            {

                if (!Request.Form["Save"].IsNullOrEmpty() && notebook != null)
                {
                    Title = Request.Form["MainTopics"];

                    CTime = Request.Form["CTime"];
                    Address = Request.Form["Address"];
                    Chaired = "";
                    Recorder = Request.Form["AcceptAttech"];


                    notebook.guid = Request.QueryString["appid"];
                    notebook.MainTopics = Title;
                    notebook.Bodys = Recorder;
                    notebook.UserID = Business.Platform.Users.CurrentUserName;
                    notebook.Address = Address;
                    notebook.AbsencePerson = Chaired;
                    notebook.AddTime =Convert.ToDateTime(CTime);


                    bnotebook.Add(notebook);



                    Business.Platform.Log.Add("新增了会议室信息", notebook.Serialize());
                    ViewBag.Script = "alert('保存成功!');";
                }
                else
                {
                    bnotebook.Update(notebook);
                    Business.Platform.Log.Add("修改了会议室信息", notebook.Serialize());
                    ViewBag.Script = "alert('保存成功!');";
                }



            }

            return View(notebook);
        }



        public ActionResult Meeting_View()
        {
            return Meeting_View(null);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Meeting_View(FormCollection collection)
        {
            string Title = string.Empty;
            string Address = string.Empty;
            string Chaired = string.Empty;
            string Recorder = string.Empty;
            string CTime = string.Empty;
            string acceptdept = string.Empty;

            Business.Platform.Meeting bnotebook = new Business.Platform.Meeting();
            Data.Model.Meeting notebook = new Data.Model.Meeting();


            string id = Request.QueryString["id"];
            if (id != null)
            {

                // Guid gnewsid = new Guid(id);
                Data.Model.Meeting notebookid = bnotebook.Get(id.ToInt32());
                if (notebook == null)
                {
                    notebookid.guid = id;
                    notebook.Bodys = "";
                    notebook.AbsencePerson = "";
                    notebookid.UserID = "";
                    notebook.Address = "";
                    notebookid.MainTopics = "";
                    notebookid.AddTime = System.DateTime.Now;


                }
                else
                {
                    notebook = notebookid;
                }

            }

            return View(notebook);
        }





        public ActionResult MeetingList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Int32 id)
        {
            Business.Platform.Meeting bnotebook = new Business.Platform.Meeting();
            int delresult = bnotebook.Delete(id);

            return RedirectToAction("MeetingList");

        }




    }
}
