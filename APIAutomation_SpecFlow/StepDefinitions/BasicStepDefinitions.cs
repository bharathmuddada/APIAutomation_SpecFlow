using APIAutomation_SpecFlow.Drivers;
using RestSharp;
using TechTalk.SpecFlow.Infrastructure;

namespace APIAutomationSpecFlow.StepDefinitions
{
    [Binding]
    public sealed class BasicStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        private RestClient _restClient;
        private ISpecFlowOutputHelper _output;
        private string? token = null;


        public BasicStepDefinitions(ScenarioContext scenarioContext, ISpecFlowOutputHelper output)
        {
            //_settings = settings;
            _scenarioContext = scenarioContext;
            _restClient = _scenarioContext.Get<RestClient>("RestClient");
            _output = output;
        }

        [Given(@"I perform a GET operation ""(.*)""")]
        public async Task GetOperation(string path)
        {


            //var token = _scenarioContext.Get<String>("BearerToken");

            //Rest Request
            var request = new RestRequest(path);




            //Perform GET operation
            var _response = await _restClient.GetAsync(request);

            _output.WriteLine("Get Brand Response");
            _output.WriteLine(_response.Content);

            _output.WriteLine(_response.StatusCode + " " + _response.StatusDescription);

            _scenarioContext.Add("GetResponse", _response.Content);
            _scenarioContext.Add("GetStatusCode", ((int)_response.StatusCode).ToString());
        }

        [Then(@"Status code should be ""(.*)""")]
        public void StatusCode(string path)
        {

            var statuscode = _scenarioContext.Get<string>("GetStatusCode");
            statuscode.Should().Be(path);

        }

        [Then(@"count of stores should be equal")]
        public void SqlCount()
        {
            var count =DBDriver.SqlTestData();
            _output.WriteLine(count+"  Sales count");

        }
    }
}