using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class MailController : Controller
    {
        //
        // GET: /Mail/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Mail_List(FormCollection collection)
        {

            return query();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult query()
        {
            string pager;
            string appid = Request.QueryString["appid"];
            string tabid = Request.QueryString["tabid"];
            int foldtype = Request.QueryString["foldtype"].ToInt32();
            var mailstatus = Request.QueryString["status"];

            //string mailtype=Request.Form["type"].ToString();
            //string mailtext=Request.Form["searchtext"].ToString();


            Business.Platform.Mail email = new Business.Platform.Mail();

            string query = string.Format("&appid={0}&tabid={1}&foldtype={2}",
                        Request.QueryString["appid"],
                        Request.QueryString["tabid"],
                        foldtype);

          //  if()

            string query1 = string.Format("{0}&pagesize={1}&pagenumber={2}", query, Request.QueryString["pagesize"], Request.QueryString["pagenumber"]);
            List<Data.Model.Mails> lstobjmails = email.GetAccount(out pager, Business.Platform.Users.CurrentUserID, foldtype, query);
            // List<Data.Model.AppLibrary> appList = bapp.GetPagerData(out pager, query, title1, typeidstring, address);

            if (mailstatus == "0")
            {
                lstobjmails = lstobjmails.FindAll(p => p.IsRead == 0);

            }

            //switch (mailtype)
            //{
            //    case "receiveid":
            //        lstobjmails = lstobjmails.FindAll(p => p.ReceiverID.Contains(mailtext));
            //        break;
            //    case "sender":
            //        lstobjmails = lstobjmails.FindAll(p => p.SenderIDs.Contains(mailtext));
            //        break;
            //    case "subject":
            //        lstobjmails = lstobjmails.FindAll(p => p.Subject.Contains(mailtext));
            //        break;
            //    case "serdertime":
            //       // lstobjmails = lstobjmails.FindAll(p => p.SenderIDs>=mailtext && );
            //        break;
            //    default:
            //        break;
            //};




            ViewBag.Pager = pager;
            ViewBag.AppID = appid;
            ViewBag.TabID = tabid;
            ViewBag.foldtype = foldtype;

            ViewBag.Query1 = query1;

            return View(lstobjmails);
        }

        public ActionResult MailDel_List()
        {
            return View();
        }

        public ActionResult MailSend_List()
        {
            return View();
        }



        public ActionResult MailAdd()
        {
            return MailAdd(null);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MailAdd(FormCollection collection)
        {
            string Title = string.Empty;
          
            string Content = string.Empty;
            string Attech = string.Empty;
            string ReceiverID = string.Empty;
            string CcIDs = string.Empty;
            string BccIDs = string.Empty;
            string acceptdept = string.Empty;



            Business.Platform.Mail bmails = new Business.Platform.Mail();
            Business.Platform.Mails_Detail bmaildetail = new Business.Platform.Mails_Detail();
            
            Data.Model.Mails mails = new Data.Model.Mails();
            Data.Model.Mails_Detail mailsdetail = new Data.Model.Mails_Detail();

            Business.Platform.WorkGroup bworkgroup = new Business.Platform.WorkGroup();
            

            if (collection != null)
            {


                //using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
                //{

                    Title = Request.Form["Mails.Subject"];
                    Content = Request.Form["Bodys"];
                    Attech = Request.Form["Mails.fileattech"];
                    ReceiverID = Request.Form["Mails.ReceiverID"];

                    if (string.IsNullOrEmpty(ReceiverID))
                    {
                        ViewBag.Script = "alert('邮件发送失败!');";
                        return View();
                    }
                         
                    CcIDs = Request.Form["Mails.CCIDs"];
                    BccIDs = Request.Form["Mails.BccIDs"];
                    string mailGuid = Guid.NewGuid().ToString();

                    mailsdetail.Guid = mailGuid;
                    mailsdetail.ReceiveIDs = ReceiverID;
                    mailsdetail.CcIDs = CcIDs;
                    mailsdetail.BccIDs = BccIDs;
                    mailsdetail.Attachments = Attech;
                    mailsdetail.Bodys = Content;

                    bmaildetail.Add(mailsdetail);

                    Data.Model.Mails_Detail detailid = bmaildetail.GetGuid(mailGuid);
                    int id = detailid.Id;



                    DateTime dt = System.DateTime.Now;

                    mails.guid = Guid.NewGuid().ToString();
                    mails.Subject = Title;
                    mails.IsRead = 0;

                    //SendType发送类型 1为发送  2为收件  3为抄送 4为秘抄
                    //FloderType 为文件夹类型  0为删除文件夹  1为发件箱  2为收件箱  4为彻底删除
                    //IsRead     为是否已读过  0为未读  1为已读

                    mails.ReceiverID = Business.Platform.Users.CurrentUserID.ToString();
                    mails.SendTime = dt;
                    mails.SenderIDs = Business.Platform.Users.CurrentUserID.ToString();
                    mails.SendType = 1;
                    mails.FolderType = 1;
                    mails.did = id;

                    bmails.Add(mails);


                    string[] lstReceiverIDs = ReceiverID.Split(',');


                    foreach (string recever in lstReceiverIDs)
                    {
                        if (recever.Substring(0, 2) == "w_")
                        {
                            Data.Model.WorkGroup wg = bworkgroup.Get(recever.Substring(2).ToGuid());
                            string[] arrwg=wg.Members.Split(',');
                            foreach (var rec in arrwg)
                            {
                                if (string.IsNullOrEmpty(rec))
                                {
                                    continue;
                                }
                                mails.ReceiverID = rec;
                                mails.SendTime = dt;
                                mails.SenderIDs = Business.Platform.Users.CurrentUserID.ToString();
                                mails.SendType = 2;
                                mails.FolderType = 2;
                                mails.did = id;

                                bmails.Add(mails);
                            
                            }

                        }
                        else
                        {

                            mails.ReceiverID = recever;
                            mails.SendTime = dt;
                            mails.SenderIDs = Business.Platform.Users.CurrentUserID.ToString();
                            mails.SendType = 2;
                            mails.FolderType = 2;
                            mails.did = id;

                            bmails.Add(mails);
                        
                        }

                       
                    }








                    if (CcIDs != null)
                    {
                        string[] lstCcIDs = CcIDs.Split(',');

                        foreach (string ccid in lstCcIDs)
                        {
                            mails.ReceiverID = ccid;
                            mails.SendTime = dt;
                            mails.SenderIDs = Business.Platform.Users.CurrentUserID.ToString();
                            mails.SendType = 3;
                            mails.FolderType = 2;
                            mails.did = id;

                            bmails.Add(mails);
                        }

                    }


                    if (BccIDs != null)
                    {
                        string[] lstBccIDs = BccIDs.Split(',');
                        foreach (string bccid in lstBccIDs)
                        {
                            mails.ReceiverID = bccid;
                            mails.SendTime = dt;
                            mails.SenderIDs = Business.Platform.Users.CurrentUserID.ToString();
                            mails.SendType = 4;
                            mails.FolderType = 2;
                            mails.did = id;

                            bmails.Add(mails);
                        }
                    }

                //    scope.Complete();
                //}

                  
                   
                  
                   

                   
                    





                    Business.Platform.Log.Add("新发了一封新邮件", mails.Serialize());
                    ViewBag.Script = "alert('邮件发送成功!');";
                    
                


            }

            return View(mails);
        }





        public ActionResult Mail_View()
        {
            return Mail_View(null);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Mail_View(FormCollection collection)
        {
            string Title = string.Empty;

            string Content = string.Empty;
            string Attech = string.Empty;
            string ReceiverID = string.Empty;
            string CCIDs = string.Empty;
            string BccIDs = string.Empty;
            string acceptdept = string.Empty;



            Business.Platform.Mail bmails = new Business.Platform.Mail();
            Data.Model.Mails mails = new Data.Model.Mails();
            string id = Request.QueryString["id"];
            if (id != null)
            {

                // Guid gnewsid = new Guid(id);
                Data.Model.Mails mailid = bmails.Get(id.ToInt32());
                if (mailid == null)
                {

                    mails.ComID = id.ToInt32();
                    mails.Subject = "";
                    mails.SenderDepName = "";
                    mails.SendTime = System.DateTime.Now;



                }
                else
                {
                    mails = mailid;
                }

            }

            if (collection != null)
            {

                if (!Request.Form["Save"].IsNullOrEmpty() && mails != null)
                {
                    Title = Request.Form["NewsTitle"];
                    Content = Request.Form["Bodys"];
                    Attech = Request.Form["AcceptAttech"];
                    ReceiverID = Request.Form["ReceiverID_text"];

                    CCIDs = Request.Form["CCIDs_text"];
                    BccIDs = Request.Form["BccIDs_text"];

                    mails.guid = Request.QueryString["appid"];
                    mails.Subject = Title;
                    mails.ReceiverID = ReceiverID;
                    mails.CCIDs = CCIDs;
                    mails.BccIDs = BccIDs;
                    mails.fileattech = Attech;
                    mails.body = Content;
                    mails.SendTime = System.DateTime.Now;
                    mails.SenderIDs = Business.Platform.Users.CurrentUserID.ToString();


                    bmails.Add(mails);



                    Business.Platform.Log.Add("新发了一封新邮件", mails.Serialize());
                    ViewBag.Script = "alert('邮件发送成功!');";
                }
                else
                {
                    bmails.Update(mails);
                    Business.Platform.Log.Add("修改了邮件信息", mails.Serialize());
                    ViewBag.Script = "alert('保存成功!');";
                }



            }

            return View(mails);
        }





        public ActionResult Mail_Manage()
        {
            return Mail_Manage(null);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Mail_Manage(FormCollection collection)
        {
            string Title = string.Empty;

            string Content = string.Empty;
            string Attech = string.Empty;
            string ReceiverID = string.Empty;
            string CcIDs = string.Empty;
            string BccIDs = string.Empty;
            string acceptdept = string.Empty;



            Business.Platform.Mail bmails = new Business.Platform.Mail();
            Business.Platform.Mails_Detail bmaildetail = new Business.Platform.Mails_Detail();

            Data.Model.Mails mails = new Data.Model.Mails();
            Data.Model.Mails_Detail mailsdetail = new Data.Model.Mails_Detail();


            if (collection != null)
            {


                Title = Request.Form["Mails.Subject"];
                Content = Request.Form["Bodys"];
                Attech = Request.Form["Mails.fileattech"] +"|"+ Request.Form["arrfile"];
                ReceiverID = Request.Form["Mails.ReceiverID"];

                CcIDs = Request.Form["Mails.CCIDs"];
                BccIDs = Request.Form["Mails.BccIDs"];
                string mailGuid = Guid.NewGuid().ToString();

                mailsdetail.Guid = mailGuid;
                mailsdetail.ReceiveIDs = ReceiverID;
                mailsdetail.CcIDs = CcIDs;
                mailsdetail.BccIDs = BccIDs;
                mailsdetail.Attachments = Attech;
                mailsdetail.Bodys = Content;

                bmaildetail.Add(mailsdetail);

                Data.Model.Mails_Detail detailid = bmaildetail.GetGuid(mailGuid);
                int id = detailid.Id;



                DateTime dt = System.DateTime.Now;

                mails.guid = Guid.NewGuid().ToString();
                mails.Subject = Title;
                mails.IsRead = 0;

                //SendType发送类型 1为发送  2为收件  3为抄送 4为秘抄
                //FloderType 为文件夹类型  0为删除文件夹  1为发件箱  2为收件箱  4为彻底删除
                //IsRead     为是否已读过  0为未读  1为已读

                mails.ReceiverID = Business.Platform.Users.CurrentUserID.ToString();
                mails.SendTime = dt;
                mails.SenderIDs = Business.Platform.Users.CurrentUserID.ToString();
                mails.SendType = 1;
                mails.FolderType = 1;
                mails.did = id;

                bmails.Add(mails);


                string[] lstReceiverIDs = ReceiverID.Split(',');


                foreach (string recever in lstReceiverIDs)
                {
                    mails.ReceiverID = recever;
                    mails.SendTime = dt;
                    mails.SenderIDs = Business.Platform.Users.CurrentUserID.ToString();
                    mails.SendType = 2;
                    mails.FolderType = 2;
                    mails.did = id;

                    bmails.Add(mails);
                }








                if (CcIDs != null)
                {
                    string[] lstCcIDs = CcIDs.Split(',');

                    foreach (string ccid in lstCcIDs)
                    {
                        mails.ReceiverID = ccid;
                        mails.SendTime = dt;
                        mails.SenderIDs = Business.Platform.Users.CurrentUserID.ToString();
                        mails.SendType = 3;
                        mails.FolderType = 2;
                        mails.did = id;

                        bmails.Add(mails);
                    }

                }


                if (BccIDs != null)
                {
                    string[] lstBccIDs = BccIDs.Split(',');
                    foreach (string bccid in lstBccIDs)
                    {
                        mails.ReceiverID = bccid;
                        mails.SendTime = dt;
                        mails.SenderIDs = Business.Platform.Users.CurrentUserID.ToString();
                        mails.SendType = 4;
                        mails.FolderType = 2;
                        mails.did = id;

                        bmails.Add(mails);
                    }
                }











                Business.Platform.Log.Add("新发了一封新邮件", mails.Serialize());
                ViewBag.Script = "alert('邮件发送成功!');";




            }

            return View(mails);
        }





    }
}
