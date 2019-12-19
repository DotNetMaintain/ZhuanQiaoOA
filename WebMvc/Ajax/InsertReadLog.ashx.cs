using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Platform;

namespace WebMvc.Ajax
{
    /// <summary>
    /// InsertReadLog 的摘要说明
    /// </summary>
    public class InsertReadLog : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";
            string guid = context.Request["guid"];
            string table_name = context.Request["table_name"];
            string userid = context.Request["userid"];

            Read_Log rl = new Read_Log();
            Data.Model.Read_Log modrl = new Data.Model.Read_Log();
            bool isread = rl.HasRead(guid, userid,table_name);
            if (!isread)
            {
                Guid id = Guid.NewGuid();
                modrl.id = id;
                modrl.guid = guid;
                modrl.userid = userid;
                modrl.table_name = table_name;
                modrl.modify_date = System.DateTime.Now;
                rl.Add(modrl);
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