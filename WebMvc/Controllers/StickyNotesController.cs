using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class StickyNotesController : Controller
    {
        //
        // GET: /StickyNotes/

        public ActionResult Index()
        {
            Business.Platform.StickyNotes bnotebook = new Business.Platform.StickyNotes();
            Business.Platform.Organize borganize = new Business.Platform.Organize();


            List<Data.Model.StickyNotes> lstnotebook1 = new List<Data.Model.StickyNotes>();

            List<Data.Model.StickyNotes> lstnotebook = bnotebook.GetAll();

            foreach (var notebooks in lstnotebook)
            {
               
                        if (notebooks.UserID == Business.Platform.Users.CurrentUserID.ToString())
                        {
                            lstnotebook1.Add(notebooks);
                        }
                  

           }



            return View(lstnotebook1);
        }





        public ActionResult StickyNotesAdd()
        {
            return StickyNotesAdd(null);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StickyNotesAdd(FormCollection collection)
        {
            string Title = string.Empty;
            string Content = string.Empty;
            string Attech = string.Empty;
            string acceptdept = string.Empty;


            Business.Platform.StickyNotes bnotebook = new Business.Platform.StickyNotes();
            Data.Model.StickyNotes notebook = new Data.Model.StickyNotes();


            string id = Request.QueryString["id"];
            if (id != null)
            {

                Guid gnewsid = new Guid(id);
                Data.Model.StickyNotes notebookid = bnotebook.Get(id.ToInt32());
                if (notebook == null)
                {
                    notebookid.guid = id;
                    notebookid.ComID = id.ToInt32();
                    notebook.Bodys = "";
                   
                    notebookid.UserID = "";
                    
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
                    Title = Request.Form["Subject"];

                    Content = Request.Form["Bodys"];
                    Attech = "";
                    acceptdept = Business.Platform.Users.CurrentUserID.ToString();


                    notebook.guid = Request.QueryString["appid"];
                    
                    notebook.Bodys = Content;
                    notebook.UserID = acceptdept;
                    
                    notebook.AddTime = System.DateTime.Now;


                    bnotebook.Add(notebook);



                    Business.Platform.Log.Add("修改了便签信息", notebook.Serialize());
                    ViewBag.Script = "alert('保存成功!');";
                }
                else
                {
                    bnotebook.Update(notebook);
                    Business.Platform.Log.Add("修改了便签信息", notebook.Serialize());
                    ViewBag.Script = "alert('保存成功!');";
                }



            }

            return View(notebook);
        }



    }
}
