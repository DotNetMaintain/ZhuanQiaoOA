using System;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface IReports
    {

        /// <summary>
        /// 查询所有记录
        /// </summary>
        List<Data.Model.Reports> GetRestReportAll();

        List<Data.Model.Reports> GetRestReportAllPara(string starttime, string endtime);


        List<Data.Model.RestDetailReports> GetRestDetailReportAll();

        List<Data.Model.RestDetailReports> GetRestDetailReportAllPara(string starttime, string endtime);


        List<Data.Model.ReceiveReports> GetReceiveReportAll();

        List<Data.Model.ReceiveReports> GetReceiveReportAllPara(string starttime, string endtime);

    }
}
