using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Platform
{
    public class Reports
    {

        private Data.Interface.IReports dataReports;
        public Reports()
        {
            this.dataReports = Data.Factory.Platform.GetReportsInstance();
        }

        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.Reports> GetRestReportAll()
        {
            return dataReports.GetRestReportAll();
        }

        public List<Data.Model.Reports> GetRestReportAllPara(string starttime, string endtime)
        {
            return dataReports.GetRestReportAllPara(starttime, endtime);
        }


        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.RestDetailReports> GetRestDetailReportAll()
        {
            return dataReports.GetRestDetailReportAll();
        }

        public List<Data.Model.RestDetailReports> GetRestDetailReportAllPara(string starttime, string endtime)
        {
            return dataReports.GetRestDetailReportAllPara(starttime, endtime);
        }


        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.ReceiveReports> GetReceiveReportAll()
        {
            return dataReports.GetReceiveReportAll();
        }

        public List<Data.Model.ReceiveReports> GetReceiveReportAllPara(string starttime, string endtime)
        {
            return dataReports.GetReceiveReportAllPara(starttime, endtime);
        }


    }
}
