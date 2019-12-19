using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class NewsController : MyController
    {
        //
        // GET: /News/

        public ActionResult Index()
        {
            Business.Platform.NewsArticle bnewsarticle = new Business.Platform.NewsArticle();
            Business.Platform.UsersRole buserRole = new Business.Platform.UsersRole();
            Business.Platform.UsersRelation  buserrelation=new Business.Platform.UsersRelation ();
            Business.Platform.Organize borg = new Business.Platform.Organize();
            
            Business.Platform.Role brole = new Business.Platform.Role();
            var userrelations=buserrelation.GetAllByUserID(Business.Platform.Users.CurrentUserID);
            //var users = buser.GetByAccount(Business.Platform.Users.CurrentUser.Account);
            var roles = buserRole.GetByUserID(Business.Platform.Users.CurrentUserID);
            

            var typeid=Request .QueryString ["typeid"];
            var status = Request.QueryString["status"];

            List<Data.Model.NewsArticle> lstnewsarticle1 = new List<Data.Model.NewsArticle>();
            //if (roles.Count > 0)
            //{

                //List<Data.Model.Role> roleList = new List<Data.Model.Role>();
                //foreach (var role in roles)
                //{
                //    var role1 = brole.Get(role.RoleID);
                //    if (role1 == null)
                //    {
                //        continue;
                //    }
                //    roleList.Add(role1);


                //}
                List<Data.Model.NewsArticle> lstnewsarticle = new List<Data.Model.NewsArticle>();
                List<Data.Model.NewsArticle> lstnewsarticleAll = bnewsarticle.GetAll();
               Business.Platform.Read_Log rl = new Business.Platform.Read_Log();

                if (typeid == "" || typeid==null)
                {
                    lstnewsarticle = lstnewsarticleAll;
                    
                }
                else
                {
                    lstnewsarticle = lstnewsarticleAll.FindAll(p => p.TypeID == typeid);
                }
                

                if (status == "0")
                {
                    foreach (var newsarticle in lstnewsarticle)
                    {
                        if (!rl.HasRead(newsarticle.id.ToString(), Business.Platform.Users.CurrentUserID.ToString(), "9c92a09f-c9fa-4073-85cb-6fd62c0550dd"))
                        lstnewsarticle1.Add(newsarticle);
                    }
                }
                else
                {
                    lstnewsarticle1 = lstnewsarticle;

                }

                //foreach (var news in lstnewsarticle)
                //{
                //    string[] splitroles = news.ShareDeps.Split(',');
                //    foreach (var role2 in roleList)
                //    {

                //        if (splitroles.Length == 1)
                //        {
                //            if (role2.ID == new Guid(news.ShareDeps))
                //            {
                //                lstnewsarticle1.Add(news);
                //                break;
                //            }
                //        }
                //        else
                //        { 
                //           foreach (string sroles in splitroles)
                //           {
                //               if (role2.ID == new Guid(sroles))
                //               {
                //                   lstnewsarticle1.Add(news);
                //                   break;
                //               }
                //           }
                //        }
                        

                //    }




                    
                //        string[] splitdept = news.ShareDeps.Split(',');
                      
                //        foreach (var dept in splitdept)
                //        {
                           
                //            foreach(var reloations in userrelations)
                //            {
                //               if (dept == reloations.OrganizeID.ToString())
                //                {
                //                    lstnewsarticle1.Add(news);
                //                    break;
                //                }
                //            }

                //            var orgs = borg.GetAllChilds(new Guid(dept));
                //            foreach (var depts in orgs)
                //            {
                //                if (dept == depts.ID.ToString())
                //                {
                //                    lstnewsarticle1.Add(news);
                //                    break;
                //                }
                //            }

                       

                //    }


                //}

               



           // }



            return View(lstnewsarticle1);
        }

        public ActionResult News_Manage()
        {
            return News_Manage(null);
        }


      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult News_Manage(FormCollection collection)
        {
            string Title = string.Empty;
            string Type = string.Empty;
            string Content = string.Empty;
            string Attech = string.Empty;
            string acceptdept = string.Empty;



            Business.Platform.NewsArticle bnewarticles = new Business.Platform.NewsArticle();
            Data.Model.NewsArticle newsarticle = new Data.Model.NewsArticle();
            string id = Request.QueryString["id"];
            if (id != null)
            {

                Guid gnewsid = new Guid(id);
                Data.Model.NewsArticle newsarticleid = bnewarticles.Get(id.ToInt32());
                if (newsarticleid == null)
                {
                    newsarticle.guid = id;
                    newsarticle.ComID = id.ToInt32();
                    newsarticle.TypeID = "";
                    newsarticle.NewsTitle = "";
                    newsarticle.Notes = "";
                    newsarticle.FilePath = "";
                    newsarticle.ShareDeps = "";
                    newsarticle.ShareUsers = "";
                    newsarticle.namelist = "";
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
                    Title = Request.Form["NewsTitle"];
                    Type = Request.Form["TempTest_News.Type"];
                    Content = Request.Form["Bodys"];
                    Attech = Request.Form["AcceptAttech"];
                    acceptdept = "";


                    newsarticle.guid = Request.QueryString["appid"];
                    newsarticle.TypeID = Type;
                    newsarticle.NewsTitle = Title;
                    newsarticle.Notes = Content;
                    newsarticle.FilePath = Attech;
                    newsarticle.ShareDeps = acceptdept;
                    newsarticle.CreatorDepName = Business.Platform.Users.CurrentDeptName;
                    newsarticle.CreatorRealName = Business.Platform.Users.CurrentUserName;
                      
                    newsarticle.ShareUsers = "";
                    newsarticle.namelist = "";
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






        public ActionResult News_Detail()
        {
            return News_Detail(null);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult News_Detail(FormCollection collection)
        {
            string Title = string.Empty;
            string Type = string.Empty;
            string Content = string.Empty;
            string Attech = string.Empty;
            string acceptdept = string.Empty;



            Business.Platform.NewsArticle bnewarticles = new Business.Platform.NewsArticle();
            Data.Model.NewsArticle newsarticle = new Data.Model.NewsArticle();
            string id = Request.QueryString["id"];
            if (id != null)
            {

               // Guid gnewsid = new Guid(id);
                Data.Model.NewsArticle newsarticleid = bnewarticles.Get(id.ToInt32());
                if (newsarticleid == null)
                {
                    newsarticle.guid = id;
                    newsarticle.ComID = id.ToInt32();
                    newsarticle.TypeID = "";
                    newsarticle.NewsTitle = "";
                    newsarticle.Notes = "";
                    newsarticle.FilePath = "";
                    newsarticle.ShareDeps = "";
                    newsarticle.ShareUsers = "";
                    newsarticle.namelist = "";
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
                    Title = Request.Form["NewsTitle"];
                    Type = Request.Form["TempTest_News.Type"];
                    Content = Request.Form["Bodys"];
                    Attech = Request.Form["AcceptAttech"];
                    acceptdept = Request.Form["namelist_dep_text"];


                    newsarticle.guid = Request.QueryString["appid"];
                    newsarticle.TypeID = Type;
                    newsarticle.NewsTitle = Title;
                    newsarticle.Notes = Content;
                    newsarticle.FilePath = Attech;
                    newsarticle.ShareDeps = acceptdept;
                    newsarticle.CreatorDepName = Business.Platform.Users.CurrentDeptName;
                    newsarticle.CreatorRealName = Business.Platform.Users.CurrentUserName;

                    newsarticle.ShareUsers = "";
                    newsarticle.namelist = "";
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




        public ActionResult NewsList()
        {

            Business.Platform.NewsArticle bnewsarticle = new Business.Platform.NewsArticle();
            List<Data.Model.NewsArticle> lstnewsarticle = new List<Data.Model.NewsArticle>();
            List<Data.Model.NewsArticle> lstnewsarticleAll = bnewsarticle.GetAll();
            return View(lstnewsarticleAll);
        }

        [HttpPost]
        public ActionResult Delete(Int32 id)
        {
            Business.Platform.NewsArticle bnewsartilce = new Business.Platform.NewsArticle();
            int delresult = bnewsartilce.Delete(id);

           // string[] lotid = id;
            return RedirectToAction("NewsList");

        }


        [HttpPost]
        public ActionResult DeleteLot()
        {

            string ids = Request["id[]"];
            string[] intids = ids.Split(',');
            Business.Platform.NewsArticle bnewsartilce = new Business.Platform.NewsArticle();
            foreach (string subid in intids)
            {
                int delresult = bnewsartilce.Delete(Convert.ToInt32(subid));
            }

           // int delresult = bnewsartilce.Delete(id);
          //  string[] lotid = id;
            return RedirectToAction("NewsList");

        }



    }
}
