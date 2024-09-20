using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.FldrModel
{
    public class UserSession
    {
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
        public DateTime ExpiryTimeStamp { get; set; }
    }
    public class ModelProduct
    {
        public string Code { get; set; } 
        public string Name { get; set; } 
    }
    public class ModeltblProductEntry
    {
        public string ProductCode { get; set; } 
        public string ProductName { get; set; } 
        public string ProductDesc { get; set; } 
        public string PTypeCode { get; set; } 
        public int Qty { get; set; } 
        public double UnitPrice { get; set; } 
    }
    public class ModelDelete
    {
        public List<string> Code { get; set; }  
    }
}
