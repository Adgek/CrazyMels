using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Soa4.Models
{
    public class REST
    {
        /// <summary>
        /// handler calling rest service
        /// </summary>
        /// <param name="xmlinput">post data</param>
        /// <param name="secondUrlPart"> last part of url</param>
        /// <param name="restMethod">the rest method being invoked</param>
        /// <param name="method">rest verb being used</param>
        /// <returns></returns>
        public string MakeRequest(string xmlinput, string secondUrlPart,string restMethod, string method)
        {
            // Restful service URL
            string url = "http://crazymelserver.azurewebsites.net/CrazyMel.svc/" + restMethod + secondUrlPart;

            // declare ascii encoding
            ASCIIEncoding encoding = new ASCIIEncoding();
            string strResult = string.Empty;
            
            // declare httpwebrequet wrt url defined above
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            // set method as post
            webrequest.Method = method;
            // set content type
            webrequest.ContentType = "application/x-www-form-urlencoded";
            // set content length
            if (!(method == "GET"))
            {            
                string postData = xmlinput.ToString();
                // convert xmlstring to byte using ascii encoding
                byte[] data = encoding.GetBytes(postData);
                webrequest.ContentLength = data.Length;
                // get stream data out of webrequest object
                Stream newStream = webrequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();
            }

            try
            {
                // declare & read response from service
                HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

                // set utf8 encoding
                Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                // read response stream from response object
                StreamReader loResponseStream =
            new StreamReader(webresponse.GetResponseStream(), enc);
                // read string from stream data
                strResult = loResponseStream.ReadToEnd();
                // close the stream object
                loResponseStream.Close();
                // close the response object
                webresponse.Close();
                // below steps remove unwanted data from response string
                strResult = strResult.Replace("</string>", "");
            }
            catch (Exception e)
            {
                return e.Message;
            }
           
            return HttpUtility.HtmlDecode(strResult);
        }
    }
}