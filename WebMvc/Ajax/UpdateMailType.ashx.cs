using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvc.Ajax
{
    /// <summary>
    /// UpdateMailType 的摘要说明
    /// </summary>
    public class UpdateMailType : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";
            var text = context.Request["key"];
            var isread = context.Request["IsRead"];
            var action = context.Request["action"];
            string[] idsplit = text.Split(',');
            Data.Model.Mails modrl = new Data.Model.Mails();
            Business.Platform.Mail bmail=new Business.Platform.Mail ();

            foreach(var ids in idsplit)
            {
                modrl = bmail.Get(ids.ToInt32());
                if (isread == "1")
                {
                    modrl.IsRead = 1;
                }
                if (action == "Virtualdelete")
                {
                    modrl.FolderType = 0;
                }
                if (action == "delete")
                {
                    modrl.FolderType = 4;
                }
                
               
               bmail.Update(modrl);
            }


            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}