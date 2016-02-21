using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Gift_REST.CSharp.Infrastructure;
using System.Dynamic;
using Gift_REST.CSharp.Models;

namespace Gift_REST.CSharp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sale()
        {
            var jsonDict = new Dictionary<string,string>();
            jsonDict.Add("RefNo","1");
            jsonDict.Add("InvoiceNo","1");
            jsonDict.Add("Memo","test");
            jsonDict.Add("Purchase","1.11");
            jsonDict.Add("AcctNo","6050110010032766771");
            jsonDict.Add("OperatorID","test");

            var jsonData = new JavaScriptSerializer().Serialize(jsonDict);
            var response = GiftWebRequest.DoGiftRequest(jsonData, "Sale");
            var paymentResponse = PaymentResponse.Map(response);

            return View(paymentResponse);
        }

        public ActionResult Issue()
        {
            var jsonDict = new Dictionary<string, string>();
            jsonDict.Add("RefNo", "1");
            jsonDict.Add("InvoiceNo", "1");
            jsonDict.Add("Memo", "test");
            jsonDict.Add("Purchase", "50.00");
            jsonDict.Add("AcctNo", "6050110010032766771");
            jsonDict.Add("OperatorID", "test");

            var jsonData = new JavaScriptSerializer().Serialize(jsonDict);
            var response = GiftWebRequest.DoGiftRequest(jsonData, "Issue");
            var paymentResponse = PaymentResponse.Map(response);

            return View(paymentResponse);
        }
    }
}