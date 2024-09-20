using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Net;
using PISWEBAPI.FldrClass;

namespace PISWEBAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {

        SqlConnection myconnection;
        SqlCommand mycommand;

        [HttpPost]
        [Route("v1/product/DeleteProductType")]
        public async Task<HttpResponseMessage> DeleteProductType(ModelDelete Mdl1)
        {
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            myconnection.Open();
            foreach (var code in Mdl1.Code)
            { 
                string SqlStatement = $"DELETE FROM tblProductType WHERE PTypeCode='{code}'";
                mycommand = new SqlCommand(SqlStatement, myconnection);
                mycommand.ExecuteNonQuery();
            }
            myconnection.Close();
            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        [HttpPost]
        [Route("v1/product/DeleteProductEntry")]
        public async Task<HttpResponseMessage> DeleteProductEntry(ModelDelete Mdl1)
        {
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            myconnection.Open();
            foreach (var code in Mdl1.Code)
            { 
                string SqlStatement = $"DELETE FROM tblProduct WHERE ProductCode='{code}'";
                mycommand = new SqlCommand(SqlStatement, myconnection);
                mycommand.ExecuteNonQuery();
            }
            myconnection.Close();
            return new HttpResponseMessage(HttpStatusCode.OK);

        }
    }
}
