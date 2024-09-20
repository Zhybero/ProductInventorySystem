using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using PISWEBAPI.FldrClass;
using PISWEBAPI.FldrModel;

namespace PISWEBAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class JhedListController : ControllerBase
    {

        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader dr;
        string SqlSentenceView;


        //VALIDATION
        [HttpGet]
        [Route("v1/product/Duplicate/CheckDuplicate")]
        public string CheckIfDuplicate(string FldTableName, string FldFieldName, string FldValueFieldName)
        {
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            myconnection.Open();
            string CheckNoTransact = string.Format("SELECT Count(*) FROM {0} WHERE {1}='" + FldValueFieldName + "'", FldTableName, FldFieldName);
            SqlCommand com = new SqlCommand(CheckNoTransact, myconnection);
            int CountData = int.Parse(com.ExecuteScalar().ToString());
            myconnection.Close();
            if (CountData > 0)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }


        // Products
        [HttpGet]
        [Route("v1/product/GetModelProductTypeList")]
        public async Task<IEnumerable<ModelProduct>> GetModelProductTypeList()
        {
            List<ModelProduct> MSSQL = new List<ModelProduct>(); 
            SqlSentenceView = "SELECT * FROM tblProductType ORDER BY PTypeName"; 
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            await myconnection.OpenAsync();
            mycommand = new SqlCommand(SqlSentenceView, myconnection);
            dr = mycommand.ExecuteReader();
            while (dr.Read())
            {
                var listData = new ModelProduct
                {
                    Code = dr["PTypeCode"].ToString(),
                    Name = dr["PTypeName"].ToString(),
                };
                MSSQL.Add(listData);
            }
            myconnection.Close();
            return MSSQL;
        }

        [HttpGet]
        [Route("v1/product/GetModelProductEntryList")]
        public async Task<IEnumerable<ModeltblProductEntry>> GetModelProductEntryList()
        {
            List<ModeltblProductEntry> MSSQL = new List<ModeltblProductEntry>(); 
            SqlSentenceView = "SELECT * FROM tblProduct ORDER BY ProductName"; 
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            await myconnection.OpenAsync();
            mycommand = new SqlCommand(SqlSentenceView, myconnection);
            dr = mycommand.ExecuteReader();
            while (dr.Read())
            {
                var listData = new ModeltblProductEntry
                {
                    ProductCode = dr["ProductCode"].ToString(),
                    ProductName = dr["ProductName"].ToString(),
                    ProductDesc = dr["ProductDesc"].ToString(),
                    PTypeCode = dr["PTypeCode"].ToString(),
                    Qty = int.Parse(dr["Qty"].ToString()),
                    UnitPrice = double.Parse(dr["UnitPrice"].ToString()),
                };
                MSSQL.Add(listData);
            }
            myconnection.Close();
            return MSSQL;
        }


        [HttpGet]
        [Route("v1/product/GetCountProducts")]
        public async Task<int> GetCountProducts()
        {
            int varCount = 0;
            string SqlSentenceView = $"SELECT COUNT(*) FROM tblProduct";
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            await myconnection.OpenAsync();
            mycommand = new SqlCommand(SqlSentenceView, myconnection);
            varCount = int.Parse(mycommand.ExecuteScalar().ToString());
            await myconnection.CloseAsync();
            return varCount;
        }
        [HttpGet]
        [Route("v1/product/GetCountProductsType")]
        public async Task<int> GetCountProductsType()
        {
            int varCount = 0;
            string SqlSentenceView = $"SELECT COUNT(*) FROM tblProductType";
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            await myconnection.OpenAsync();
            mycommand = new SqlCommand(SqlSentenceView, myconnection);
            varCount = int.Parse(mycommand.ExecuteScalar().ToString());
            await myconnection.CloseAsync();
            return varCount;
        }
        [HttpGet]
        [Route("v1/product/GetCountUser")]
        public async Task<int> GetCountUser()
        {
            int varCount = 0;
            string SqlSentenceView = $"SELECT COUNT(*) FROM tblUser";
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            await myconnection.OpenAsync();
            mycommand = new SqlCommand(SqlSentenceView, myconnection);
            varCount = int.Parse(mycommand.ExecuteScalar().ToString());
            await myconnection.CloseAsync();
            return varCount;
        }
    }
}
