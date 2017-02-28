using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace CSC.Auxiliary
{
    public class GetAddressIPMethod
    {
        /// <summary>
        /// 获取IP
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            string result;
            try
            {
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (null == result || result == String.Empty)
                {
                    result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                if (null == result || result == String.Empty)
                {
                    result = HttpContext.Current.Request.UserHostAddress;
                }
            }
            catch { result = ""; }
            return result;
        }
        /// <summary>
        /// 通过IP获取城市
        /// </summary>
        /// <returns></returns>
        public string GetCityName()
        {
            string ip = GetClientIP();
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=&ip=" + ip);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/GB2312";
            HttpWebResponse HttpWResp = (HttpWebResponse)myRequest.GetResponse();

            Stream myStream = HttpWResp.GetResponseStream();
            StreamReader sr = new StreamReader(myStream, Encoding.GetEncoding("GB2312"));
            string strBuilder = "";
            while (-1 != sr.Peek())
            {
                strBuilder += sr.ReadLine();
            }
            myStream.Close();
            sr.Close();
            string[] res = strBuilder.Trim().Split('\t');
            if (res.Length > 5)
            {
                return res[5] + "市";
            }
            return "";
        }

        //#region POST提交参数
        ///// <summary>
        ///// POST提交参数
        ///// </summary>
        ///// <param name="path">POST的地址，需要传送的地址</param>
        ///// <param name="posturl">POST提交参数，例如“client_id=2866517568&client_secret=9c”和get的链接类似</param>
        ///// <returns></returns>
        //public string SendRequest(string path, string posturl)
        //{
        //    try
        //    {
        //        //拼接提交数据的格式
        //        string s = posturl;
        //        //转换为字节数组
        //        byte[] bytesRequestData = Encoding.UTF8.GetBytes(s);
        //        //path不是登录界面，是登录界面向服务器提交数据的界面
        //        HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(path);
        //        myReq.Method = "post";
        //        myReq.ContentType = "application/x-www-form-urlencoded";
        //        myReq.Headers.Add("Cookie", Session.SessionID);
        //        //填充POST数据
        //        myReq.ContentLength = bytesRequestData.Length;
        //        Stream requestStream = myReq.GetRequestStream();
        //        requestStream.Write(bytesRequestData, 0, bytesRequestData.Length);
        //        requestStream.Close();
        //        //发送POST数据请求服务器
        //        HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
        //        //获取服务器返回信息
        //        Stream myStream = HttpWResp.GetResponseStream();
        //        StreamReader reader = new StreamReader(myStream, Encoding.UTF8);
        //        string content = reader.ReadToEnd();
        //        return content;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }
        //}
        //#endregion

        /// <summary>
        /// 获取用户所在城市
        /// </summary>
        /// <returns></returns>
        public string GetUserCurrentCityName(HiddenField hdCity)
        {
            string cityName = "";
            if (!String.IsNullOrWhiteSpace(hdCity.Value))
            {
                cityName = hdCity.Value;
            }
            else
            {
                cityName = new GetAddressIPMethod().GetCityName();
                hdCity.Value = cityName;
            }
            return cityName;
        }

        //获取mac地址 
        public static string GetCustomerMac()
        {
            try
            {
                string IP = GetClientIP();
                string dirResults = "";
                ProcessStartInfo psi = new ProcessStartInfo();
                Process proc = new Process();
                psi.FileName = "nbtstat";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = "-a " + IP;
                psi.UseShellExecute = false;
                proc = Process.Start(psi);
                dirResults = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();
                //匹配mac地址 
                Match m = Regex.Match(dirResults, "\\w+\\-\\w+\\-\\w+\\-\\w+\\-\\w+\\-\\w\\w");
                //若匹配成功则返回mac，否则返回找不到主机信息             
                if (m.ToString() != "")
                {
                    return m.ToString();
                }
                else
                {
                    return "找不到主机信息";
                }
            }
            catch (Exception)
            {

                return "找不到主机信息";
            }
        }
    }
}
