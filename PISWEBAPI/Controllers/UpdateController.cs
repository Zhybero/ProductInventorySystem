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
    public class UpdateController : ControllerBase
    {

        SqlConnection myconnection;
        SqlCommand mycommand;


        [HttpPut]
        [Route("v1/product/UpdateModelProductType")]
        [Authorize]
        public HttpResponseMessage UpdateModelProductType(ModelProduct Mdl1)
        {
            string SqlStatement = $"UPDATE tblProductType SET PTypeName=@_PTypeName WHERE PTypeCode=@_PTypeCode";
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            myconnection.Open();
            mycommand = new SqlCommand(SqlStatement, myconnection);
            mycommand.Parameters.Add("_PTypeCode", SqlDbType.VarChar).Value = Mdl1.Code;
            mycommand.Parameters.Add("_PTypeName", SqlDbType.VarChar).Value = Mdl1.Name; 
            mycommand.ExecuteNonQuery();

            myconnection.Close();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("v1/product/UpdateModelProductEntry")]
        [Authorize]
        public HttpResponseMessage UpdateModelProductEntry(ModeltblProductEntry Mdl1)
        {
            string SqlStatement = $"UPDATE tblProduct SET ProductName=@_ProductName, ProductDesc=@_ProductDesc, PTypeCode=@_PTypeCode, Qty=@_Qty, UnitPrice=@_UnitPrice WHERE ProductCode=@_ProductCode";
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            myconnection.Open();
            mycommand = new SqlCommand(SqlStatement, myconnection);
            mycommand.Parameters.Add("_ProductCode", SqlDbType.VarChar).Value = Mdl1.ProductCode;
            mycommand.Parameters.Add("_ProductName", SqlDbType.VarChar).Value = Mdl1.ProductName;
            mycommand.Parameters.Add("_ProductDesc", SqlDbType.VarChar).Value = Mdl1.ProductDesc;
            mycommand.Parameters.Add("_PTypeCode", SqlDbType.VarChar).Value = Mdl1.PTypeCode;
            mycommand.Parameters.Add("_Qty", SqlDbType.Int).Value = Mdl1.Qty;
            mycommand.Parameters.Add("_UnitPrice", SqlDbType.Money).Value = Mdl1.UnitPrice;
            mycommand.ExecuteNonQuery();

            myconnection.Close();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
