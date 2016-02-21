# Gift_REST.CSharp

* More documentation?  http://developer.mercurypay.com
* Questions?  integrationteam@mercurypay.com
* **Feature request?** Open an issue.
* Feel like **contributing**?  Submit a pull request.

# Overview

This repository demonstrates a web based integration to the Gift platform showing both a Gift Sale and Gift Issue transaction.

The initial page of the application allows a user to select either a Gift Sale or Gift Issue transaction.  The 
application then creates a request, serializes the request to JSON, sends the request to the Mercury platform,
and finally parses the response and displays the resulting transaction data.


![Gift_REST.CSharp](https://github.com/mercurypay/Gift_REST.CSharp/blob/master/initialpage.PNG)


![Gift_REST.CSharp](https://github.com/mercurypay/Gift_REST.CSharp/blob/master/saleresponse.PNG)

# Payment Processing

##Step 1: Collect and Format Transaction Information

Utilizing an object model set parameters needed to process a transaction.  The example below shows a gift sale transaction.  The class object is then serialized to JSON and represented as a string variable.


```
var jsonDict = new Dictionary<string,string>();
jsonDict.Add("RefNo","1");
jsonDict.Add("InvoiceNo","1");
jsonDict.Add("Memo","test");
jsonDict.Add("Purchase","1.11");
jsonDict.Add("AcctNo","6050110010032766771");
jsonDict.Add("OperatorID","test");

var jsonData = new JavaScriptSerializer().Serialize(jsonDict);

```


##Step 2: POST Request to Mercury Platform

Using the .net libraries a web request is made to the Mercury server POSTing the JSON above.  Note that you need a merchantid and password to perform the Basic Auth.  All of the "plumbing" code is included in the DoGiftRequest method.
  The second parameter of this method appends to the base URL which is how you will switch transaction types.  For example to send a Gift Issue command replace "Sale" with "Issue".


```
var response = GiftWebRequest.DoGiftRequest(jsonData, "Sale");
```


##Step 3: Process and Display Response

After receiving the response deserialze the JSON string to a dynamic object, in this case a Dictionary<string,string> and then parse the values into an object so it will be easier to work with.  That object is then passed to the view for display purposes.


```
var paymentResponse = new PaymentResponse();

var giftResponse = new JavaScriptSerializer().Deserialize<dynamic>(json);
if(giftResponse.ContainsKey("ResponseOrigin")){ paymentResponse.ResponseOrigin = giftResponse["ResponseOrigin"];}
if(giftResponse.ContainsKey("DSIXReturnCode")) {paymentResponse.DSIXReturnCode = giftResponse["DSIXReturnCode"];}

```



###©2016 Mercury Payment Systems, LLC - all rights reserved.

Disclaimer:
This software and all specifications and documentation contained herein or provided to you hereunder (the "Software") are provided free of charge strictly on an "AS IS" basis. No representations or warranties are expressed or implied, including, but not limited to, warranties of suitability, quality, merchantability, or fitness for a particular purpose (irrespective of any course of dealing, custom or usage of trade), and all such warranties are expressly and specifically disclaimed. Mercury Payment Systems shall have no liability or responsibility to you nor any other person or entity with respect to any liability, loss, or damage, including lost profits whether foreseeable or not, or other obligation for any cause whatsoever, caused or alleged to be caused directly or indirectly by the Software. Use of the Software signifies agreement with this disclaimer notice.