using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Gift_REST.CSharp.Models
{
    public class PaymentResponse
    {
        public string ResponseOrigin;
        public string DSIXReturnCode;
        public string CmdStatus;
        public string TextResponse;
        public string UserTraceData;
        public string MerchantID;
        public string TranType;
        public string TranCode;
        public string InvoiceNo;
        public string TerminalName;
        public string OperatorID;
        public string AcctNo;
        public string RefNo;
        public string AuthCode;
        public string Authorize;
        public string Purchase;
        public string Balance;

        public static PaymentResponse Map(string json)
        {
            var paymentResponse = new PaymentResponse();

            var giftResponse = new JavaScriptSerializer().Deserialize<dynamic>(json);
            if(giftResponse.ContainsKey("ResponseOrigin")){ paymentResponse.ResponseOrigin = giftResponse["ResponseOrigin"];}
            if(giftResponse.ContainsKey("DSIXReturnCode")) {paymentResponse.DSIXReturnCode = giftResponse["DSIXReturnCode"];}
            if(giftResponse.ContainsKey("CmdStatus")) {paymentResponse.CmdStatus = giftResponse["CmdStatus"];}
            if(giftResponse.ContainsKey("TextResponse")) {paymentResponse.TextResponse = giftResponse["TextResponse"];}
            if(giftResponse.ContainsKey("UserTraceData")) {paymentResponse.UserTraceData = giftResponse["UserTraceData"];}
            if(giftResponse.ContainsKey("MerchantID")) {paymentResponse.MerchantID = giftResponse["MerchantID"];}
            if(giftResponse.ContainsKey("TranType")) {paymentResponse.TranType = giftResponse["TranType"];}
            if(giftResponse.ContainsKey("TranCode")) {paymentResponse.TranCode = giftResponse["TranCode"];}
            if(giftResponse.ContainsKey("InvoiceNo")) {paymentResponse.InvoiceNo = giftResponse["InvoiceNo"];}
            if(giftResponse.ContainsKey("TerminalName")) {paymentResponse.TerminalName = giftResponse["TerminalName"];}
            if(giftResponse.ContainsKey("OperatorID")) {paymentResponse.OperatorID = giftResponse["OperatorID"];}
            if(giftResponse.ContainsKey("AcctNo")) {paymentResponse.AcctNo = giftResponse["AcctNo"];}
            if(giftResponse.ContainsKey("RefNo")) {paymentResponse.RefNo = giftResponse["RefNo"];}
            if(giftResponse.ContainsKey("AuthCode")) {paymentResponse.AuthCode = giftResponse["AuthCode"];}
            if(giftResponse.ContainsKey("Authorize")) {paymentResponse.Authorize = giftResponse["Authorize"];}
            if(giftResponse.ContainsKey("Purchase")) {paymentResponse.Purchase = giftResponse["Purchase"];}
            if (giftResponse.ContainsKey("Balance")) { paymentResponse.Balance = giftResponse["Balance"]; }


            return paymentResponse;
        }
    }
}