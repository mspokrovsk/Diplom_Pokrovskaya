using Allure.NUnit.Attributes;
using Allure.Net.Commons;
using RestSharp;
using System.Net;
using NLog;
using Allure.NUnit;
using System.Text.Json.Serialization;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.All)]
    [AllureNUnit]
    [AllureEpic("API")]
        
    public class GetTest
    {
        protected readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private const string BaseRestUri = "https://mspokrovsk.testmo.net";

        [Test(Description = "�������� ��������� ������ �� ������� ��� ������� �������� � ���������")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("API NFE")]

        public void CheckSuccessfulResponse_WhenGetProjects()
        {
            const string endpoint = "/api/v1/projects?page=1";
            const string token = "testmo_api_eyJpdiI6IkZGcDJ4M2JFTkFacCtBVG51dTZST2c9PSIsInZhbHVlIjoiQUZJbnlQVElTOVBockNDeVk5WVlqcHlPeTBpQis1bnpZb1hSbzUrVVR1Zz0iLCJtYWMiOiJiNzE5ZDEzZTc3OTgxYzliZmQzN2Q3OTFmNGY0ZGZkZGE1YTU4MzIyNWY0MDFhMDdkZjZlZjFlMzFiMzk3MzUxIiwidGFnIjoiIn0=";

            // Setup Rest Client
            var client = new RestClient(BaseRestUri);

            // Setup Request
            var request = new RestRequest(endpoint);

            request.AddHeader("Authorization", $"Bearer {token}");

            // Execute Request
            var response = client.ExecuteGet(request);

            Logger.Info(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test(Description = "�������� ��������� ������ �� ������� ��� ������� ������������")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("API NFE")]

        public void CheckSuccessfulResponse_WhenGetUser()
        {
            const string endpoint = "/api/v1/users/{user_id}";
            const string token = "testmo_api_eyJpdiI6IkZGcDJ4M2JFTkFacCtBVG51dTZST2c9PSIsInZhbHVlIjoiQUZJbnlQVElTOVBockNDeVk5WVlqcHlPeTBpQis1bnpZb1hSbzUrVVR1Zz0iLCJtYWMiOiJiNzE5ZDEzZTc3OTgxYzliZmQzN2Q3OTFmNGY0ZGZkZGE1YTU4MzIyNWY0MDFhMDdkZjZlZjFlMzFiMzk3MzUxIiwidGFnIjoiIn0=";

            // Setup Rest Client
            var client = new RestClient(BaseRestUri);

            // Setup Request
            var request = new RestRequest(endpoint)
                .AddUrlSegment("user_id", 1); 

            request.AddHeader("Authorization", $"Bearer {token}");

            // Execute Request
            var response = client.ExecuteGet(request);

            Logger.Info(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

    }
}
   