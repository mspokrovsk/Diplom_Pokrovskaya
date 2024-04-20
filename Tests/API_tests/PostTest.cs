using Allure.NUnit.Attributes;
using Allure.Net.Commons;
using RestSharp;
using System.Net;
using NLog;
using Allure.NUnit;
using Diplom_Pokrovskaya.Models;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureEpic("API")]
        
    public class PostTest
    {
        protected readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private const string BaseRestUri = "https://mspokrovsk.testmo.net";
        private readonly Runs _runIdManager = new Runs();

        [Test(Description = "�������� ��������� ������� ������������� � ������� �������"), Order(1)]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("API POST")]

        public void CheckSuccessfulResponse_WhenPostRuns()
        {
            const string endpoint = "/api/v1/projects/{project_id}/automation/runs";
            const string token = "testmo_api_eyJpdiI6IkZGcDJ4M2JFTkFacCtBVG51dTZST2c9PSIsInZhbHVlIjoiQUZJbnlQVElTOVBockNDeVk5WVlqcHlPeTBpQis1bnpZb1hSbzUrVVR1Zz0iLCJtYWMiOiJiNzE5ZDEzZTc3OTgxYzliZmQzN2Q3OTFmNGY0ZGZkZGE1YTU4MzIyNWY0MDFhMDdkZjZlZjFlMzFiMzk3MzUxIiwidGFnIjoiIn0=";

            Runs expectedRun = new Runs
            {
                Name = "Run 1",
                Source = "backend",
            };
            // Setup Rest Client
            var client = new RestClient(BaseRestUri);

            // Setup Request
            var request = new RestRequest(endpoint)
                .AddUrlSegment("project_id", 41)
                .AddJsonBody(expectedRun); 

            request.AddHeader("Authorization", $"Bearer {token}");

            // Execute Request
            var response = client.ExecutePost<Runs>(request);
            Runs actualRun = response.Data;

            Logger.Info(actualRun);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            // �������� �������� ���� "id"
            int id = actualRun.Id;

            // ��������� �������� "id" ��� ������������� � ��������� �����
            _runIdManager.SaveRunId(id);

            Logger.Info($"�������� ���� 'id': {id}");
        }

        [Test(Description = "�������� ��������� ���������� ������� ������������� � ������� �������"), Order(2)]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("API POST")]

        public void CheckSuccessfulResponse_WhenPostRunsComplete()
        {
            const string endpoint = "/api/v1/automation/runs/{automation_run_id}/complete";
            const string token = "testmo_api_eyJpdiI6IkZGcDJ4M2JFTkFacCtBVG51dTZST2c9PSIsInZhbHVlIjoiQUZJbnlQVElTOVBockNDeVk5WVlqcHlPeTBpQis1bnpZb1hSbzUrVVR1Zz0iLCJtYWMiOiJiNzE5ZDEzZTc3OTgxYzliZmQzN2Q3OTFmNGY0ZGZkZGE1YTU4MzIyNWY0MDFhMDdkZjZlZjFlMzFiMzk3MzUxIiwidGFnIjoiIn0=";

            // �������� �������� "id" �� ����������� �����
            int runId = _runIdManager.GetRunId();

            // Setup Rest Client
            var client = new RestClient(BaseRestUri);

            // Setup Request
            var request = new RestRequest(endpoint)
                .AddUrlSegment("automation_run_id", runId)
                .AddHeader("Content-Type", "application/json")
                .AddHeader("Authorization", $"Bearer {token}");

            request.AddHeader("Authorization", $"Bearer {token}");

            // Execute Request
            var response = client.ExecutePost(request);

            Logger.Info(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
    }
}
   