using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Gift_REST.CSharp.Infrastructure
{
    public class GiftWebRequest
    {
        public static string DoGiftRequest(string json, string txnType)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://w1.mercurycert.net/PaymentsAPI/PrePaid/" + txnType);
            request.Method = "POST";
            request.ContentType = "application/json";

            var encoded = System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(
                "003503902913105" + ":" + "xyz"));

            request.Headers.Add("Authorization", "Basic " + encoded);
            request.ContentLength = json.Length;
            using (var webStream = request.GetRequestStream())
            using (var requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(json);
            }

            var response = string.Empty;

            try
            {
                var webResponse = request.GetResponse();
                using (var webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (var responseReader = new StreamReader(webStream))
                        {
                            response = responseReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                response = e.ToString();
            }

            return response;
        }
    }
}