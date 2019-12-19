using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace Utility
{
   public class ExcelToData
    {



        #region EXCEL数据转换DataSet
        /// <summary>
        /// EXCEL数据转换DataSet
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="search">表名</param>
        /// <returns></returns> 
        public DataSet GetDataSet(string filePath,string fileName)
        {

            string fileExt = Path.GetExtension(fileName);
            string strConn = "";
            if (fileExt == ".xls")
            {
                strConn = "Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source =" + (filePath + fileName) + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
            }
            else
            {
                strConn = "Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source =" + (filePath + fileName) + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1'";
            } 
            //string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + (filePath + fileName) + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";

            //string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + (filePath + fileName) + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";
            
            OleDbConnection objConn = null;
            objConn = new OleDbConnection(strConn);
            objConn.Open();
            DataSet ds = new DataSet();
            List<string> List = new List<string> { };
            DataTable dtSheetName = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            foreach (DataRow dr in dtSheetName.Rows)
            {
                //if (dr["Table_Name"].ToString().Contains("$") && !dr[2].ToString().Trim().EndsWith("$"))
                //{
                //    continue;
                //}
                string s = dr["Table_Name"].ToString();
                List.Add(s);
            }
            try
            {
                for (int i = 0; i < List.Count; i++)
                {
                    ds.Tables.Add(List[i]);
                    string SheetName = List[i];
                    string strSql = "select * from [" + SheetName + "]";
                    OleDbDataAdapter odbcCSVDataAdapter = new OleDbDataAdapter(strSql, objConn);
                    DataTable dt = ds.Tables[i];
                    odbcCSVDataAdapter.Fill(dt);
                }
                objConn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
