using RestSharp;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Newtonsoft.Json;
using Xunit;
using System.Net;
using GWAPI.Models;
using Xunit.Abstractions;
using GWAPI.Hook;

namespace GWAPI.StepDefinitions
{
    [Binding]
    public class AggregateAPIStepDefinitions
    {
        private readonly RestClient client;
        private string endPoint;
        private Dictionary<string, string> headers;
        private RestRequest request;
        private IRestResponse response;
        private string ResponseBody;
        private readonly ITestOutputHelper Console;
        public string BaseURI;
        public AggregateAPIStepDefinitions(Hooks hooks, ITestOutputHelper output)
        {
            var configuration = hooks.BeforeScenario();
            this.BaseURI = configuration.synergyBaseUrl;
            this.client = new RestClient(BaseURI);
            this.Console = output;
        }
        [Given(@"I set endpoint as '([^']*)'")]
        public void GivenISetEndpointAs(string endpoint)
        {
            this.endPoint = endpoint;
        }

        [When(@"I set method  GET")]
        public void WhenISetMethodGET()
        {
            this.request = new RestRequest(endPoint, Method.GET);
        }

        [Then(@"I set Get Header param request content type Get")]
        public void ThenISetGetHeaderParamRequestContentTypeGet(Table table)
        

        {
            this.headers = Utils.APIHelper.ToDictionary(table);
            foreach (KeyValuePair<string, String> header in headers)
            {
                this.request.AddHeader(header.Key, header.Value);
            }

        }

        [Then(@"I should receive valid HTTP response code '([^']*)'")]
        public void ThenIShouldReceiveValidHTTPResponseCode(string statusCode)

        {
            this.response = client.Execute(request);
            int responseStatusCode = (int)response.StatusCode;
            if (response.IsSuccessful)
            {
               // var user = JsonConvert.DeserializeObject<AggregateHC>(response.Content);

                Assert.Equal(responseStatusCode.ToString(), statusCode);
                HttpStatusCode StatusCode = response.StatusCode;
                var code = (int)StatusCode;
                Assert.Equal(200, code);
                Console.WriteLine(response.Content);

            }
        }
    }
}
