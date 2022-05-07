using System;
using System.IO;
using System.Net;

namespace udsu_application_client.APIServices
{
    public class RequestToAPI
    {
        HttpWebRequest request;
        string adressUrl;

        public string Response { get; set; }

        public RequestToAPI(string url)
        {
            adressUrl = url;
        }

        public void RunGet()
        {
            request = (HttpWebRequest)WebRequest.Create(adressUrl);
            request.Method = "GET";

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var stream = response.GetResponseStream();
                if(stream != null) Response = new StreamReader(stream).ReadToEnd();
            }
            catch(Exception)
            {

            }

        }
    }
}
