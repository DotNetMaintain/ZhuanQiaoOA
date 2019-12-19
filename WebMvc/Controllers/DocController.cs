using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class DocController : MyController
    {
        //
        // GET: /Doc/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Doc_Manage()
        {
            return View();
        }

        

    }
}
