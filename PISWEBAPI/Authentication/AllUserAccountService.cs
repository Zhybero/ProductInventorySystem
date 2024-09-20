﻿using Microsoft.Data.SqlClient;
using PISWEBAPI.FldrClass;
using PISWEBAPI.FldrModel;

namespace PISWEBAPI.Authentication
{
    public class AllUserAccountService
    {
        SqlConnection myconnection;
        SqlCommand mycommand;
        SqlDataReader dr;
        private List<UserAccount> _userAccountList;
        public AllUserAccountService()
        {

            _userAccountList = new List<UserAccount>();
            string SqlSentenceView = $"SELECT * FROM tblUser";

            myconnection = new SqlConnection(new ClsGetConnection().PlsConnect());
            myconnection.Open();
            mycommand = new SqlCommand(SqlSentenceView, myconnection);
            dr = mycommand.ExecuteReader();
            while (dr.Read())
            {
                UserAccount Mdl1 = new UserAccount
                {
                    UserCode = dr["UserCode"].ToString(),
                    UserName = dr["UserName"].ToString(),
                    Password = dr["PWord"].ToString(), 
                };
                _userAccountList.Add(Mdl1);
            }
            myconnection.Close();
        }



        public UserAccount? GetAllUserAccountByUserName(string userName)
        {
            return _userAccountList.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
