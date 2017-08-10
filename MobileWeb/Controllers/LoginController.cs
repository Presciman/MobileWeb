using MobileWeb.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MobileWeb.Controllers
{
    public class LoginController : Controller
    {
      /*  public static string HttpPost(string Url)
        {
            System.Net.HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Proxy = null;
            request.KeepAlive = false;
            request.Method = "POST";
            //request.ContentType = "application/json; charset=UTF-8";
            request.ContentType = "application/x-www-form-urlencoded";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
                return retString;
            }
            catch (Exception e)
            {
                Trace.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@" + e.Message);
                return e.Message;
            }

    


        }*/
        /// <summary>
        /// POST 方法发送接口调用请求
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string HttpPost(string Url, string content)
        {
            HttpClient client = new HttpClient();
            StringContent httpContent = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");
            var postresult = client.PostAsync(Url, httpContent);
            string result = postresult.Result.Content.ReadAsStringAsync().Result;

            return result;
        }
        // GET: Login
        [HttpGet]
        [ActionName("login")]
        public ActionResult login(int?id)
        {
            return View();
        }

        [HttpPost]
        [ActionName("login")]
        public ActionResult login()
        //public string Marie()
        {

            LoginModel loginModel = new LoginModel();
            loginModel.in_date = "12345678";
            loginModel.interface_id = "123456789987654321";
            loginModel.user_phone = Request["username"];
            loginModel.pass = Request["password"];
            loginModel.device_type = Request["device"];
            loginModel.device_token = "GWY7N16A31000916";
            string Url = "http://120.24.42.134:8080/api/User/UserLogin";
            string content = string.Format("in_date={0}&interface_id={1}&user_phone={2}&pass={3}&device_type={4}&device_token={5}", loginModel.in_date, loginModel.interface_id, loginModel.user_phone, loginModel.pass, loginModel.device_type, loginModel.device_token);
            string result = HttpPost(Url, content);
            //Trace.WriteLine("################  " + result + "  @@@@@@@@@@@@@@@@@@@@@@");
            var jObject = JObject.Parse(result);
            string code = jObject["code"].ToString();
            if(code == "e")
            {

            }
            return Redirect("Success?message="+result);
            //return result;
        }

        //GET: Success
        public ActionResult Success()
        {
            ViewData["message"] = Request["message"];
            return View();
        }

        //GET: Login/gogo
      /*  [HttpGet]
        [ActionName("gogo")]
        public void Matrix()
        {
            Marie();
        }*/
        //如何获取Token
    }
}