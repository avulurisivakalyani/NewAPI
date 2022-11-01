using Newtonsoft.Json;
using RestSharp;
using GWAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TechTalk.SpecFlow;
using GWAPI.Hook;
using Xunit;
using Xunit.Abstractions;

namespace GWAPI.StepDefinitions
{
    [Binding]
    public class VesselimageStepDefinitions
    {
        private readonly RestClient client;
        private readonly string baseUrl;
        private string endPoint;
        private Dictionary<string, string> headers;
        public string BaseURI;
        private RestRequest request;
        private IRestResponse response;
        // private string ResponseBody;
        private readonly ITestOutputHelper Console;
        public VesselimageStepDefinitions(Hooks hooks, ITestOutputHelper output)
        {
            var configuration = hooks.BeforeScenario();
            this.BaseURI = configuration.synergyBaseUrl;
            this.client = new RestClient(BaseURI);
            this.Console = output;
        }


        [Given(@"Iset endpoint as '([^']*)'")]
        public void GivenIsetEndpointAs(string endpoint)
        {
            this.endPoint = endpoint;
        }

        [When(@"I set HCGET method")]
        public void WhenISetHCGETMethod()
        {
            this.request = new RestRequest(BaseURI + endPoint, Method.GET);
        }

        [Then(@"I set Headers")]
        public void ThenISetHeaders(Table table)
       
        {
            this.headers = Utils.APIHelper.ToDictionary(table);
            foreach (KeyValuePair<string, String> header in headers)
            {
                this.request.AddHeader(header.Key, header.Value);
            }
        }

        [Then(@"I should receive valid response code '([^']*)'")]
        public void ThenIShouldReceiveValidResponseCode(string statusCode)
        {
            this.response = client.Execute(request);
            int responseStatusCode = (int)response.StatusCode;
            if (response.IsSuccessful)
            {
                //var user = JsonConvert.DeserializeObject<VesselimageHC>(response.Content);
                Assert.Equal(responseStatusCode.ToString(), statusCode);
                Console.WriteLine(response.Content);
            }
        }

        [Given(@"I set endpoint as'([^']*)'")]
        public void GivenISetEndpointAs(string endpoint)
        {
            this.endPoint = endpoint;
        }

        [When(@"I set GET method")]
        public void WhenISetGETMethod()
        {
            this.request = new RestRequest(BaseURI +endPoint, Method.GET);
        }

      

        [Then(@"I should receive valid Get response code '([^']*)'")]
        public void ThenIShouldReceiveValidGetResponseCode(string statusCode)
        {
            this.response = client.Execute(request);
            int responseStatusCode = (int)response.StatusCode;
            if (response.IsSuccessful)
            {
                //var user = JsonConvert.DeserializeObject<VesselimageGet>(response.Content);
                Assert.Equal(responseStatusCode.ToString(), statusCode);
                Console.WriteLine(response.Content);
            }
        }

        [Given(@"I set endpoint  '([^']*)'")]
        public void GivenISetEndpoint(string endpoint)
        {
            this.endPoint = endpoint;
        }

        [When(@"I set POST method")]
        public void WhenISetPOSTMethod()
        {
            this.request = new RestRequest(BaseURI + endPoint, Method.POST);
        }

        [Then(@"I Set Body to Post")]
        public void ThenISetBodyToPost()
        {
            using (var reader = new StreamReader("./Models/JsonFiles/VesselimagePOST.json"))
            {
                string jsonData = reader.ReadToEnd();
                this.request.AddJsonBody(jsonData);
            }
        }

        [Then(@"I should receive valid POST response code '([^']*)'")]
        public void ThenIShouldReceiveValidPOSTResponseCode(string statusCode)
        {
            this.response = client.Execute(request);
            int responseStatusCode = (int)response.StatusCode;
            if (response.IsSuccessful)
            {
               // var user = JsonConvert.DeserializeObject<VesselimagePOST>(response.Content);

                Assert.Equal(responseStatusCode.ToString(), statusCode);
                HttpStatusCode StatusCode = response.StatusCode;
                var code = (int)StatusCode;
                Assert.Equal(200, code);
                Console.WriteLine(response.Content);
            }
        }
    }
}