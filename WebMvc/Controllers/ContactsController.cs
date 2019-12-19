using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class ContactsController : MyController
    {
        //
        // GET: /Contacts/

        public ActionResult Index()
        {
            return Index(null);
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection collection)
        {
            Business.Platform.Users busers = new Business.Platform.Users();
            Business.Platform.UsersInfo buserInfos = new Business.Platform.UsersInfo();
            Data.Model.UsersInfo userinfo = new Data.Model.UsersInfo();
            List<Data.Model.UsersInfo> userinfolist = buserInfos.GetAll();
            foreach (Data.Model.UsersInfo userinfoins in userinfolist)
            {
                userinfoins.Officer = busers.Get(userinfoins.UserID).Name;
                userinfoins.MSN = busers.Get(userinfoins.UserID).Account ;
            }

            return View(userinfolist);
        }

    }
}
