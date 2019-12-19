using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class ReportsController : MyController
    {
        //
        // GET: /Reports/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Print()
        {
            return View();
        }

         public ActionResult RestReport()
        {
            return RestReport(null);
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult RestReport(FormCollection collection)
         {
             string starttime = Request.Form["starttime"];
             string endtime = Request.Form["endtime"];
             List<Data.Model.Reports> taskList=new List<Data.Model.Reports> ();
             Business.Platform.Reports  breports = new Business.Platform.Reports ();
             if (collection != null && starttime != null)
             {
                 taskList = breports.GetRestReportAllPara(starttime, endtime);
             }
             else
             {
                 taskList = breports.GetRestReportAll();
             }
             


             //if(Request .Form["Import"]!=null)
             //{
             //    ToHtmlExcelT(taskList);
             //}



             return View(taskList);
         }


         public ActionResult RestDetailReport()
         {
             return RestDetailReport(null);
         }

         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult RestDetailReport(FormCollection collection)
         {
             string starttime = Request.Form["starttime"];
             string endtime = Request.Form["endtime"];
             List<Data.Model.RestDetailReports> taskList = new List<Data.Model.RestDetailReports>();
             Business.Platform.Reports breports = new Business.Platform.Reports();
             if (collection != null && starttime != null)
             {
                 taskList = breports.GetRestDetailReportAllPara(starttime, endtime);
             }
             else
             {
                 taskList = breports.GetRestDetailReportAll();
             }



            

             return View(taskList);
         }




         public void ToHtmlExcelT( List<Data.Model.Reports> taskList)
         {
             try
             {
                 // string Date = QueryStore.Get_SYSTIME();
                 // Date = Date.Substring(0, 4) + Date.Substring(5, 2) + Date.Substring(8, 2);
                 string FileName = "Data.xls";

                 Response.Clear();

                 Response.ContentType = "application/x-msdownload";
                 Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
                 string strfinal = "<HTML><head><meta HTTP-EQUIV = \"content-type\" CONTENT = \"text/html; charset = utf-8\"></head>";

                 System.Text.StringBuilder htmlCode = new System.Text.StringBuilder("<BODY><table align='center' border='1'>");

                 //報表名稱
                 htmlCode.Append("<tr align='center'>");
                 htmlCode.Append("<td align='center' colspan='3' ");
                 htmlCode.Append(" style='font-size:12pt; color:Black; background:silver'  >");
                 htmlCode.Append("</td>");
                 htmlCode.Append("</tr>");

                 htmlCode.Append("<tr align='center'>");
                 htmlCode.Append("<td ");
                 htmlCode.Append(" style='color:White; background:#5D7B9D' > ");
                 htmlCode.Append("<img id='Chart1' ChartDashStyle='solid' src='/ChartImg.axd?i=chart_d0707ff2380f4cfeab20ade22b8c2c58_0.jpeg&amp;g=84d2e939953b4868ae03b695ce8c977e' alt='' style='height:400px;width:1200px;border-width:0px;margin-bottom: 0px' />");
                 htmlCode.Append("</td>");

                 htmlCode.Append("</tr>");


                 //表頭
                 htmlCode.Append("<tr align='center'>");
                 htmlCode.Append("<td ");
                 htmlCode.Append(" style='color:White; background:#5D7B9D' > ");
                 htmlCode.Append("TEST");
                 htmlCode.Append("</td>");

                 htmlCode.Append("</tr>");
                 htmlCode.Append("<tr>");
                 htmlCode.Append("<td style='mso-number-format:\\@' x:str >");
                 htmlCode.Append("AAA");
                 htmlCode.Append("</td>");
                 htmlCode.Append("</tr>");

                 htmlCode.Append("</table></BODY></HTML>");

                 strfinal = strfinal + htmlCode.ToString();

                 Response.Write(strfinal);
                 //HttpContext.Current.ApplicationInstance.CompleteRequest();
                 Response.End();
             }
            
             finally
             {
                 GC.Collect();
                 Response.Write(" <script> window.close(); </script> ");
             }
         }



         public ActionResult ReceiveReport()
         {
             return ReceiveReport(null);
         }

         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult ReceiveReport(FormCollection collection)
         {
             string starttime = Request.Form["starttime"];
             string endtime = Request.Form["endtime"];
             List<Data.Model.ReceiveReports> taskList = new List<Data.Model.ReceiveReports>();
             Business.Platform.Reports breports = new Business.Platform.Reports();
             
             if (collection != null && starttime != null)
             {
                 taskList = breports.GetReceiveReportAllPara(starttime, endtime);
             }
             else
             {
                 taskList = breports.GetReceiveReportAll();
             }



          

             return View(taskList);
         }



    }
}
