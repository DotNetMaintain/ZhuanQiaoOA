using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class NoteBookController : Controller
    {
        //
        // GET: /NoteBook/

        public ActionResult Index()
        {
            Business.Platform.NoteBook  bnotebook = new Business.Platform.NoteBook ();
            Business.Platform.Organize borganize=new Business.Platform.Organize ();


            List<Data.Model.NoteBook> lstnotebook1 = new List<Data.Model.NoteBook>();

            List<Data.Model.NoteBook> lstnotebook = bnotebook.GetAll();

            foreach (var notebooks in lstnotebook)
                {
                    List<Data.Model.Users> lstuser = borganize.GetAllUsers(notebooks.UserID);
                    if(lstuser.Count>0)
                    {
                        foreach (var users in lstuser)
                        {
                            if (users.ID == Business.Platform.Users.CurrentUserID)
                            {
                                lstnotebook1.Add(notebooks);
                            }
                        }
                    
                    }
                   


                }



            return View(lstnotebook1);
            }



            
        

        public ActionResult NoteBookAdd()
        {
            return NoteBookAdd(null);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NoteBookAdd(FormCollection collection)
        {
            string Title = string.Empty;
            string Content = string.Empty;
            string Attech = string.Empty;
            string acceptdept = string.Empty;


            Business.Platform.NoteBook bnotebook = new Business.Platform.NoteBook();
            Data.Model.NoteBook notebook = new Data.Model.NoteBook();

            
            string id = Request.QueryString["id"];
            if (id != null)
            {

                Guid gnewsid = new Guid(id);
                Data.Model.NoteBook notebookid = bnotebook.Get(id.ToInt32());
                if (notebook == null)
                {
                    notebookid.guid = id;
                    notebookid.ComID = id.ToInt32();
                    notebook.Bodys = "";
                    notebook.Subject = "";
                    notebookid.UserID = "";
                    notebook.RealName = "";
                    notebookid.DepName = "";
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
                    acceptdept = Request.Form["namelist_text"];


                    notebook.guid = Request.QueryString["appid"];
                    notebook.Subject = Title;
                    notebook.Bodys = Content;
                    notebook.UserID = acceptdept;
                    notebook.DepName = Business.Platform.Users.CurrentDeptName;
                    notebook.RealName = Business.Platform.Users.CurrentUserName;
                    notebook.AddTime = System.DateTime.Now;


                    bnotebook.Add(notebook);



                    Business.Platform.Log.Add("修改了留言信息", notebook.Serialize());
                    ViewBag.Script = "alert('保存成功!');";
                }
                else
                {
                    bnotebook.Update(notebook);
                    Business.Platform.Log.Add("修改了留言信息", notebook.Serialize());
                    ViewBag.Script = "alert('保存成功!');";
                }



            }

            return View(notebook);
        }



       

    }
}
