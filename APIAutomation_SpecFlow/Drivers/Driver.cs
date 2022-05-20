using System;
using RestSharp;
using TechTalk.SpecFlow.Infrastructure;
using Xunit.Abstractions;

namespace APIAutomationSpecFlow.Drivers
{
    public class Driver
    {

        public Driver(ScenarioContext scenarioContext)
        {

            var url = scenarioContext.Get<string>("baseurl");
            var restClientOptions = new RestClientOptions
            {
                BaseUrl = new Uri(url),
                RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
            };

            //Rest Client
            var restClient = new RestClient(restClientOptions);


            //Add into ScenarioContext
            scenarioContext.Add("RestClient", restClient);

        }
    }
}