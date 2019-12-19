using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class HomeController : MyController
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            Business.Platform.UsersRole buserRole = new Business.Platform.UsersRole();
            Business.Platform.Role brole = new Business.Platform.Role();
            var roles = buserRole.GetByUserID(Business.Platform.Users.CurrentUserID);
            ViewBag.RoleLength = roles.Count;
            ViewBag.DefaultRoleID = string.Empty;
            ViewBag.RolesOptions = string.Empty;
            if (roles.Count > 0)
            {
                var mainRole = roles.Find(p => p.IsDefault);
                ViewBag.defaultRoleID = mainRole != null ? mainRole.RoleID.ToString() : roles.First().RoleID.ToString();
                List<Data.Model.Role> roleList = new List<Data.Model.Role>();
                foreach (var role in roles)
                {
                    var role1 = brole.Get(role.RoleID);
                    if (role1 == null)
                    {
                        continue;
                    }
                    roleList.Add(role1);
                }

                ViewBag.RolesOptions = brole.GetRoleOptions("", "", roleList);
            }

            var user = Business.Platform.Users.CurrentUser;
            ViewBag.UserName = user == null ? "" : user.Name;
            ViewBag.DateTime = Utility.DateTimeNew.Now.ToDateWeekString();

            return View();
        }

        public ActionResult Home()
        {

            Business.Platform.NewsArticle bnewsarticle = new Business.Platform.NewsArticle();
            Business.Platform.UsersRole buserRole = new Business.Platform.UsersRole();
            Business.Platform.UsersRelation buserrelation = new Business.Platform.UsersRelation();
            Business.Platform.Organize borg = new Business.Platform.Organize();

            Business.Platform.Role brole = new Business.Platform.Role();
            var userrelations = buserrelation.GetAllByUserID(Business.Platform.Users.CurrentUserID);
            //var users = buser.GetByAccount(Business.Platform.Users.CurrentUser.Account);
            var roles = buserRole.GetByUserID(Business.Platform.Users.CurrentUserID);


            var typeid = Request.QueryString["typeid"];
            List<Data.Model.NewsArticle> lstnewsarticle = bnewsarticle.GetAll();
            lstnewsarticle.FindAll(p => p.TypeID == typeid);

            List<Data.Model.NewsArticle> lstnewsarticle1 = new List<Data.Model.NewsArticle>();
            lstnewsarticle1 = lstnewsarticle;
            //if (roles.Count > 0)
            //{

            //    List<Data.Model.Role> roleList = new List<Data.Model.Role>();
            //    foreach (var role in roles)
            //    {
            //        var role1 = brole.Get(role.RoleID);
            //        if (role1 == null)
            //        {
            //            continue;
            //        }
            //        roleList.Add(role1);


            //    }
            //    List<Data.Model.NewsArticle> lstnewsarticle = bnewsarticle.GetAll();
            //    lstnewsarticle.FindAll(p => p.TypeID == typeid);

            //    foreach (var news in lstnewsarticle)
            //    {
            //        string[] splitroles = news.ShareDeps.Split(',');
            //        foreach (var role2 in roleList)
            //        {
            //            if (splitroles.Length == 1)
            //            {
            //                if (role2.ID == new Guid(news.ShareDeps))
            //                {
            //                    lstnewsarticle1.Add(news);
            //                    break;
            //                }
            //            }
            //            else
            //            {
            //                foreach (string split in splitroles)
            //                {
            //                    if (role2.ID == new Guid(split))
            //                    {
            //                        lstnewsarticle1.Add(news);
            //                        break;
            //                    }
            //                }
                        
            //            }
                       

            //        }





            //        string[] splitdept = news.ShareDeps.Split(',');

            //        foreach (var dept in splitdept)
            //        {

            //            foreach (var reloations in userrelations)
            //            {
            //                if (dept == reloations.OrganizeID.ToString())
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



            //        }


            //    }





            //}

            //if (lstnewsarticle1.Count > 5)
            //{
            //    lstnewsarticle1 = lstnewsarticle1.GetRange(0, 5);
            //}

            return View(lstnewsarticle1);
        }

        public string Menu()
        { 
            string roleID = Request.QueryString["roleid"];
            string userID = Request.QueryString["userid"];
            Guid gid,uid;
            if(!roleID.IsGuid(out gid) || !userID.IsGuid(out uid))
            {
                return "[]";
            }
            else
            {
                return new Business.Platform.RoleApp().GetRoleAppJsonString(gid, uid, Url.Content("~/").TrimEnd('/'));
            }
        }

        public string MenuRefresh()
        { 
            string roleID=Request.QueryString["roleid"];
            string userID = Request.QueryString["userid"];
            string refreshID = Request.QueryString["refreshid"];
            Guid gid,refreshid,uid;
            if(!roleID.IsGuid(out gid) || !refreshID.IsGuid(out refreshid) || !userID.IsGuid(out uid))
            {
                return "[]";
            }
            else
            {
                return new Business.Platform.RoleApp().GetRoleAppRefreshJsonString(gid, uid, refreshid, Url.Content("~/").TrimEnd('/'));
            }
        }

    }
}
