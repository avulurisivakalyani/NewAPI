using Newtonsoft.Json;
using RestSharp;
//using GWAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using TechTalk.SpecFlow;
using GWAPI.Hook;
using Xunit;
using Xunit.Abstractions;

namespace GWAPI.StepDefinitions
{
    [Binding]
    public class VesselAPIStepDefinitions
    {
        private readonly RestClient client;
        private readonly string baseUrl;
        private string endPoint;
        private Dictionary<string, string> headers;
        private RestRequest request;
        private IRestResponse response;
        // private string ResponseBody;
        private readonly ITestOutputHelper Console;
        public string BaseURI;
       // private VesselSearch _requestSearch;
        public VesselAPIStepDefinitions(Hooks hooks, ITestOutputHelper output)
        {
            var configuration = hooks.BeforeScenario();
            this.BaseURI = configuration.Url;
            this.client = new RestClient(BaseURI); 

            this.Console = output;
        }
       // private List<VesselPostSearch> _responseSearch;


        [Given(@"I set GET endpoint '([^']*)'")]
        public void GivenISetGETEndpoint(string endpoint)
        {
            this.endPoint = endpoint;
        }

        [When(@"I set HC method")]
        public void WhenISetHCMethod()
        {
            this.request = new RestRequest(BaseURI + endPoint, Method.GET);
        }

        [Then(@"I set  headers")]
        public void ThenISetHeaders(Table table)

        {
            this.headers = Utils.APIHelper.ToDictionary(table);
            foreach (KeyValuePair<string, String> header in headers)
            {
                this.request.AddHeader(header.Key, header.Value);
            }
        }

        [Then(@"I shouldreceive valid response code as'([^']*)'")]
        public void ThenIShouldreceiveValidResponseCodeAs(string statusCode)
        {
            this.response = client.Execute(request);
            int responseStatusCode = (int)response.StatusCode;
            if (response.IsSuccessful)
            {
                Assert.Equal(responseStatusCode.ToString(), statusCode);
                Console.WriteLine(response.Content);
            }
        }

        [Given(@"I set Post endpoint '([^']*)'")]
        public void GivenISetPostEndpoint(string endpoint)
        {
            this.endPoint = endpoint;
        }

        [When(@"I set VesselSearch POST method")]
        public void WhenISetVesselSearchPOSTMethod()
        {
            this.request = new RestRequest(BaseURI + endPoint, Method.POST);
        }
        [Then(@"I set headers to Post")]
        public void ThenISetHeadersToPost(Table table)
        {
            this.headers = Utils.APIHelper.ToDictionary(table);
            foreach (KeyValuePair<string, String> header in headers)
            {
                this.request.AddHeader(header.Key, header.Value);
            }
        }

        [Then(@"I set Payload")]
        public void ThenISetPayload()
        {
            using (var reader = new StreamReader("./Models/JsonFiles/VesselPost Search.json"))
            {
                string jsonData = reader.ReadToEnd();
                request.AddJsonBody(jsonData);
               // var user = JsonConvert.DeserializeObject<VesselSearch>(jsonData);
               // _requestSearch = user;

            }

        }

        [Then(@"I should Post receive valid response code as'(.*)'")]
        public void ThenIShouldPostReceiveValidResponseCodeAs(string statusCode)

        {
            response = client.Execute(request);
            int responseStatusCode = (int)response.StatusCode;
            Assert.Equal(responseStatusCode.ToString(), statusCode);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
               // var user = JsonConvert.DeserializeObject<List<VesselPostSearch>>(response.Content);
                Console.WriteLine(response.Content);
                //_responseSearch = user;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {

            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {

            }
            else
            {
                throw new Exception(string.Format("No puede API: {0}", response.ErrorException));
            }
        }

        }
    }
