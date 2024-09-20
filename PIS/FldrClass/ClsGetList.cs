using Newtonsoft.Json;
using PIS.FldrModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PIS.FldrClass
{
    public class ClsGetList
    {
        //User
        public async Task<bool> UserExist(string Username)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"{new ClsGetIPAddress().IPAddress()}/v1/product/LoginUser/UserExist?Username={Username}");
            bool data = bool.Parse(response.Trim('"'));
            return data;
        }
        //AutoNumber 
        public async Task<string> GetProductAutoNum()
        {
            var clientGet = new HttpClient();
            clientGet.BaseAddress = new Uri($"{new ClsGetIPAddress().IPAddress()}/v1/product/AutoNumber/ProductAutoNum");
            HttpResponseMessage response = await clientGet.GetAsync("");
            string strresult = await response.Content.ReadAsStringAsync();
            string strresultFinal = strresult.Trim('"');
            return strresultFinal;
        }
        
        public async Task<string> ProductTypeAutoNum()
        {
            var clientGet = new HttpClient();
            clientGet.BaseAddress = new Uri($"{new ClsGetIPAddress().IPAddress()}/v1/product/AutoNumber/ProductTypeAutoNum");
            HttpResponseMessage response = await clientGet.GetAsync("");
            string strresult = await response.Content.ReadAsStringAsync();
            string strresultFinal = strresult.Trim('"');
            return strresultFinal;
        }

        //List 
        public async Task<List<ModelProduct>> GetModelProductTypeList()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"{new ClsGetIPAddress().IPAddress()}/v1/product/GetModelProductTypeList");
            var data = JsonConvert.DeserializeObject<List<ModelProduct>>(response);
            return data;
        }
        public async Task<List<ModeltblProductEntry>> GetModelProductEntryList()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"{new ClsGetIPAddress().IPAddress()}/v1/product/GetModelProductEntryList");
            var data = JsonConvert.DeserializeObject<List<ModeltblProductEntry>>(response);
            return data;
        }

        //Count 
        public async Task<int> GetCountProducts()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"{new ClsGetIPAddress().IPAddress()}/v1/product/GetCountProducts");
            int data = int.Parse(response.Trim('"'));
            return data;
        }
        public async Task<int> GetCountProductsType()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"{new ClsGetIPAddress().IPAddress()}/v1/product/GetCountProductsType");
            int data = int.Parse(response.Trim('"'));
            return data;
        }
        public async Task<int> GetCountUser()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"{new ClsGetIPAddress().IPAddress()}/v1/product/GetCountUser");
            int data = int.Parse(response.Trim('"'));
            return data;
        }

    }
}
