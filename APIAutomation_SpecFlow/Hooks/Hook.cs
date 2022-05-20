using System;
using APIAutomationSpecFlow.Drivers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using Xunit.Abstractions;

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
            if (_scenarioContext.ScenarioInfo.Tags.Contains("reqres"))
            {
                var searchservice_url = "https://reqres.in/";

                _scenarioContext.Add("baseurl", searchservice_url);



            }
            if (_scenarioContext.ScenarioInfo.Tags.Contains("genderize"))
            {
                var catfact_url = "https://api.genderize.io/";
                _scenarioContext.Add("baseurl", catfact_url);



            }

            Driver driver = new Driver(_scenarioContext);
        }
    }
}