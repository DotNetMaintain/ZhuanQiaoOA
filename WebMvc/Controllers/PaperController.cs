using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class PaperController : MyController
    {
        //
        // GET: /Paper/

        public ActionResult Index()
        {
            return View();
        }


        

        public ActionResult PaperManage()
        {
            return PaperManage(null);
           
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PaperManage(FormCollection collection)
        {

            string Title = string.Empty;
            string Type = string.Empty;
            string Content = string.Empty;
            string Attech = string.Empty;


            Business.Platform.PaperDownload bnewarticles = new Business.Platform.PaperDownload();
            Data.Model.PaperDownload newsarticle = new Data.Model.PaperDownload();
            string id = Request.QueryString["id"];
            if (id != null)
            {

                Guid gnewsid = new Guid(id);
                Data.Model.PaperDownload newsarticleid = bnewarticles.Get(id.ToInt32());
                if (newsarticleid == null)
                {
                    newsarticle.guid = id;
                    newsarticle.DPaperNo = "";
                    newsarticle.DPaperSymbol = "";
                    newsarticle.FileAttech = "";
                    newsarticle.Subject = "";
                    newsarticle.AddUserid = "";
                    newsarticle.AddTime = System.DateTime.Now;



                }
                else
                {
                    newsarticle = newsarticleid;
                }

            }

            if (collection != null)
            {

                if (!Request.Form["Save"].IsNullOrEmpty() && newsarticle != null)
                {
                    Title = Request.Form["PaperName"];
                    Type = Request.Form["Type"];
                    Attech = Request.Form["AcceptAttech"];
                    

                    newsarticle.guid = Request.QueryString["appid"];
                    newsarticle.DPaperSymbol = "";
                    newsarticle.Subject = Title;
                    newsarticle.DPaperNo = "";
                    newsarticle.FileAttech = Attech;
                    newsarticle.AddUserid = Business.Platform.Users.CurrentUserName;
                    newsarticle.AddTime = System.DateTime.Now;


                    bnewarticles.Add(newsarticle);



                    Business.Platform.Log.Add("修改了通知通告信息", newsarticle.Serialize());
                    ViewBag.Script = "alert('保存成功!');";
                }
                else
                {
                    bnewarticles.Update(newsarticle);
                    Business.Platform.Log.Add("修改了通知通告信息", newsarticle.Serialize());
                    ViewBag.Script = "alert('保存成功!');";
                }



            }




            return View();
        }






        public ActionResult PaperList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Int32 id)
        {
            Business.Platform.PaperDownload bnewarticles = new Business.Platform.PaperDownload();
            int delresult=bnewarticles.Delete(id);

            return RedirectToAction("PaperList");

        }






        public ActionResult Paper_Detail()
        {
            return Paper_Detail(null);

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Paper_Detail(FormCollection collection)
        {

            string Title = string.Empty;
            string Type = string.Empty;
            string Content = string.Empty;
            string Attech = string.Empty;


            Business.Platform.PaperDownload bnewarticles = new Business.Platform.PaperDownload();
            Data.Model.PaperDownload newsarticle = new Data.Model.PaperDownload();
            string id = Request.QueryString["id"];
            if (id != null)
            {

               // Guid gnewsid = new Guid(id);
                Data.Model.PaperDownload newsarticleid = bnewarticles.Get(id.ToInt32());
                if (newsarticleid == null)
                {
                    newsarticle.guid = id;
                    newsarticle.DPaperNo = "";
                    newsarticle.DPaperSymbol = "";
                    newsarticle.FileAttech = "";
                    newsarticle.Subject = "";
                    newsarticle.AddUserid = "";
                    newsarticle.AddTime = System.DateTime.Now;



                }
                else
                {
                    newsarticle = newsarticleid;
                }

            }

            if (collection != null)
            {

                if (!Request.Form["Save"].IsNullOrEmpty() && newsarticle != null)
                {
                    Title = Request.Form["PaperName"];
                    Type = Request.Form["Type"];
                    Attech = Request.Form["AcceptAttech"];


                    newsarticle.guid = Request.QueryString["appid"];
                    newsarticle.DPaperSymbol = "";
                    newsarticle.Subject = Title;
                    newsarticle.DPaperNo = "";
                    newsarticle.FileAttech = Attech;
                    newsarticle.AddUserid = Business.Platform.Users.CurrentUserName;
                    newsarticle.AddTime = System.DateTime.Now;


                    bnewarticles.Add(newsarticle);



                    Business.Platform.Log.Add("修改了通知通告信息", newsarticle.Serialize());
                    ViewBag.Script = "alert('保存成功!');";
                }
                else
                {
                    bnewarticles.Update(newsarticle);
                    Business.Platform.Log.Add("修改了通知通告信息", newsarticle.Serialize());
                    ViewBag.Script = "alert('保存成功!');";
                }



            }




            return View(newsarticle);
        }







    }
}
