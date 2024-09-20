using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace PISWEBAPI.FldrClass
{
    public class ClsAutoNumber
    {
        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader dr;
        public string plsnumber; 
        public async Task<string> ProductAutoNum()
        {
            string pristrNumber;
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            await myconnection.OpenAsync();
            mycommand = new SqlCommand("SELECT TOP 1 ProductCode FROM tblProduct ORDER BY ProductCode DESC", myconnection);
            dr = await mycommand.ExecuteReaderAsync();
            await dr.ReadAsync();
            if (dr.HasRows)
            {
                int no2 = int.Parse(dr["ProductCode"].ToString()) + 1;
                pristrNumber = Convert.ToString(no2).PadLeft(5, '0');
            }
            else
            {
                pristrNumber = "00001";
            }
            await myconnection.CloseAsync();
            return pristrNumber;
        }
        public async Task<string> ProductTypeAutoNum()
        {
            string pristrNumber;
            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            await myconnection.OpenAsync();
            mycommand = new SqlCommand("SELECT TOP 1 PTypeCode FROM tblProductType ORDER BY PTypeCode DESC", myconnection);
            dr = await mycommand.ExecuteReaderAsync();
            await dr.ReadAsync();
            if (dr.HasRows)
            {
                int no2 = int.Parse(dr["PTypeCode"].ToString()) + 1;
                pristrNumber = Convert.ToString(no2).PadLeft(3, '0');
            }
            else
            {
                pristrNumber = "001";
            }
            await myconnection.CloseAsync();
            return pristrNumber;
        }
         
    }
}
