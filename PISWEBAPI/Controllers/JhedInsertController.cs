using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Net;
using PISWEBAPI.FldrClass;
using Microsoft.AspNetCore.Authorization;

namespace PISWEBAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class JhedInsertController : ControllerBase
    {

        SqlConnection myconnection;
        SqlCommand mycommand;

        [HttpPost]
        [Route("v1/product/ProductType")]
        [Authorize]
        public async Task<HttpResponseMessage> InsertUsers(ModelProduct Mdl1)
        {
            string varAutoNum = await new ClsAutoNumber().ProductTypeAutoNum();
            string SqltblUser = "INSERT INTO tblProductType (PTypeCode, PTypeName) Values (@_PTypeCode, @_PTypeName)";
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            await myconnection.OpenAsync();
            mycommand = new SqlCommand(SqltblUser, myconnection);
            mycommand.Parameters.Add("_PTypeCode", SqlDbType.VarChar).Value = varAutoNum; 
            mycommand.Parameters.Add("_PTypeName", SqlDbType.VarChar).Value = Mdl1.Name; 
            await mycommand.ExecuteNonQueryAsync();

            await myconnection.CloseAsync();
            return new HttpResponseMessage(HttpStatusCode.OK);
        } 

        [HttpPost]
        [Route("v1/product/ProductEntry")]
        [Authorize]
        public async Task<HttpResponseMessage> ProductEntry(ModeltblProductEntry Mdl1)
        {
            string varAutoNum = await new ClsAutoNumber().ProductAutoNum();
            string SqltblUser = "INSERT INTO tblProduct (ProductCode, ProductName, ProductDesc, PTypeCode, Qty, UnitPrice) Values (@_ProductCode, @_ProductName, @_ProductDesc, @_PTypeCode, @_Qty, @_UnitPrice)";
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            await myconnection.OpenAsync();
            mycommand = new SqlCommand(SqltblUser, myconnection);
            mycommand.Parameters.Add("_ProductCode", SqlDbType.VarChar).Value = varAutoNum; 
            mycommand.Parameters.Add("_ProductName", SqlDbType.VarChar).Value = Mdl1.ProductName; 
            mycommand.Parameters.Add("_ProductDesc", SqlDbType.VarChar).Value = Mdl1.ProductDesc; 
            mycommand.Parameters.Add("_PTypeCode", SqlDbType.VarChar).Value = Mdl1.PTypeCode; 
            mycommand.Parameters.Add("_Qty", SqlDbType.Int).Value = Mdl1.Qty; 
            mycommand.Parameters.Add("_UnitPrice", SqlDbType.Money).Value = Mdl1.UnitPrice; 
            await mycommand.ExecuteNonQueryAsync();

            await myconnection.CloseAsync();
            return new HttpResponseMessage(HttpStatusCode.OK);
        } 
    }
}
