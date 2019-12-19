using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Areas.Controls.Controllers
{
    public class SelectMemberController : MyController
    {
        //
        // GET: /Controls/SelectMember/

        public ActionResult Index()
        {
            return Index(null);
            //return View();
        }


        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {

            Business.Platform.Users buser = new Business.Platform.Users();
            Business.Platform.Organize borg = new Business.Platform.Organize();
            string search = "";
            List<Data.Model.Users> listusers = new List<Data.Model.Users>();

            if(Request.Form["Search"]=="搜索")
            {
                var UserList = buser.GetAll();
                 listusers = UserList.FindAll(p => p.Name == search);
            }
            ViewBag.search = search;




           
            
            return View(listusers);
        
        }



        public string GetNames()
        {
            string values = Request.QueryString["values"];
            return new Business.Platform.Organize().GetNames(values);
        }

        public JsonResult GetDetailNote()
        {

            List<Data.Model.Users> lstuser = new List<Data.Model.Users>();
            string id = Request.QueryString["id"];

            Guid gid;
            
            Business.Platform.Organize borg = new Business.Platform.Organize();
            Business.Platform.Users buser = new Business.Platform.Users();
            
            if (id.StartsWith(Business.Platform.Users.PREFIX))
            {
                Guid uid = buser.RemovePrefix1(id).ToGuid();
                lstuser.Add(buser.Get(uid));


                return Json(lstuser);
                //  return string.Concat(borg.GetAllParentNames(buser.GetMainStation(uid)), " / ", buser.GetName(uid));
            }
            else if (id.StartsWith(Business.Platform.WorkGroup.PREFIX))
            {
                Business.Platform.WorkGroup bwg = new Business.Platform.WorkGroup();
                Data.Model.WorkGroup wg = bwg.Get(Business.Platform.WorkGroup.RemovePrefix(id).ToGuid());
                string[] arrystr = wg.Members.Split(',');
                foreach (var str in arrystr)
                {
                    if (str.StartsWith(Business.Platform.Users.PREFIX))
                    {
                        Guid uid = buser.RemovePrefix1(str).ToGuid();
                        lstuser.Add(buser.Get(uid));
                        
                       // String json =  JSONArray.fromObject(list).toString();   
                    }
                    if (str.Substring(0, 2) != "u_")
                    {
                        lstuser.Add(buser.Get(str.ToGuid()));


                        
                    }
                                      
                }

                return Json(lstuser);

                // return new Business.Platform.WorkGroup().GetUsersNames(Business.Platform.WorkGroup.RemovePrefix(id).ToGuid(), '、');
            }
            else if (id.IsGuid(out gid))
            {
                return Json(borg.GetAllParentNames(gid));
            }


            return Json(lstuser);
        }



        public string GetNote()
        {
           
            string id = Request.QueryString["id"];
            Guid gid;
            if (id.IsNullOrEmpty())
            {
                return "";
            }
            Business.Platform.Organize borg = new Business.Platform.Organize();
            Business.Platform.Users buser = new Business.Platform.Users();
            if (id.StartsWith(Business.Platform.Users.PREFIX))
            {
                Guid uid = buser.RemovePrefix1(id).ToGuid();
                
                  return string.Concat(borg.GetAllParentNames(buser.GetMainStation(uid)), " / ", buser.GetName(uid));
            }
            else if (id.StartsWith(Business.Platform.WorkGroup.PREFIX))
            {
                Business.Platform.WorkGroup bwg = new Business.Platform.WorkGroup();
                Data.Model.WorkGroup wg = bwg.Get(Business.Platform.WorkGroup.RemovePrefix(id).ToGuid());
               

              //  return lstdc;

                 return new Business.Platform.WorkGroup().GetUsersNames(Business.Platform.WorkGroup.RemovePrefix(id).ToGuid(), '、');
            }
            else if (id.IsGuid(out gid))
            {
                
                return borg.GetAllParentNames(gid);
            }
            
            return "";
        }

    }
}
