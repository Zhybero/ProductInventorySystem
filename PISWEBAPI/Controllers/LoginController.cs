using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PISWEBAPI.Authentication;
using PISWEBAPI.FldrClass;
using PISWEBAPI.FldrModel;

namespace PISWEBAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        SqlConnection myconnection;
        SqlCommand mycommand; 

        [HttpGet]
        [Route("v1/product/LoginUser/UserExist")]
        public bool UserExist(string Username)
        {
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            myconnection.Open();
            mycommand = new SqlCommand($"SELECT COUNT(1) FROM tblUser WHERE UserName='{Username}'", myconnection);
            int isCount = int.Parse(mycommand.ExecuteScalar().ToString()); 
            if (isCount>0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        [HttpGet]
        [Route("v1/product/tblUserAll/GetLoginlALlUserInfo")]
        public ActionResult<UserSession> GetLoginlALlUserInfo(string Username, string Password)
        {
            var jwtAuthenticationManager = new JwtAuthenticatonManagerAllUser(new AllUserAccountService());
            var userSession = jwtAuthenticationManager.GenerateJwtToken(Username, new ClsM5Hash().getMd5Hash(Password));
            if (userSession is null)
            {
                return Unauthorized();
            }
            else
            {

                return userSession;
            }
        }
    }
}
