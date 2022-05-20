using System;
using APIAutomationSpecFlow.Drivers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using Xunit.Abstractions;
using Microsoft.Extensions.Configuration;


namespace APIAutomationSpecFlow.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;


        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [BeforeScenario()]
        public void InitializeDriver()
        {
            var config_json = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();
            var reqres_url = config_json.GetSection("Base_urls")["reqres_url"];
            var catfact_url = config_json.GetSection("Base_urls")["catfact_url"];

            if (_scenarioContext.ScenarioInfo.Tags.Contains("reqres"))
            {

                _scenarioContext.Add("baseurl", reqres_url);

            }
            if (_scenarioContext.ScenarioInfo.Tags.Contains("catfact"))
            {
               
                _scenarioContext.Add("baseurl", catfact_url);

            }

            Driver driver = new Driver(_scenarioContext);
        }
    }
}