namespace PISWEBAPI.FldrModel
{
    public class UserSession
    {
        public string UserCode { get; set; }
        public string UserName { get; set; } 
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
        public DateTime ExpiryTimeStamp { get; set; } 
    }


    public class UserAccount
    {
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; } 
    }

}
