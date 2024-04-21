using Allure.NUnit.Attributes;
using Allure.Net.Commons;
using RestSharp;
using System.Net;
using NLog;
using Allure.NUnit;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.All)]
    [AllureNUnit]
    [AllureEpic("API")]
        
    public class GetTest
    {
        protected readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private const string BaseRestUri = "https://mspokrovsk.testmo.net/api/v1/";

        [Test(Description = "Проверка успешного ответа от сервера при запросе страницы с проектами")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("API NFE")]

        public void CheckSuccessfulResponse_WhenGetProjects()
        {
            const string endpoint = "projects";
            const string token = "testmo_api_eyJpdiI6IkZGcDJ4M2JFTkFacCtBVG51dTZST2c9PSIsInZhbHVlIjoiQUZJbnlQVElTOVBockNDeVk5WVlqcHlPeTBpQis1bnpZb1hSbzUrVVR1Zz0iLCJtYWMiOiJiNzE5ZDEzZTc3OTgxYzliZmQzN2Q3OTFmNGY0ZGZkZGE1YTU4MzIyNWY0MDFhMDdkZjZlZjFlMzFiMzk3MzUxIiwidGFnIjoiIn0=";

            // Загрузка JSON-схемы из файла
            string schemaJson = File.ReadAllText(@"Resource/ProjectSchema.json");

            // Создем экземпляр JSON-схемы
            JSchema schema = JSchema.Parse(schemaJson);

            // Setup Rest Client
            var client = new RestClient(BaseRestUri);

            // Setup Request
            var request = new RestRequest(endpoint)
                .AddParameter("page", 1);

            request.AddHeader("Authorization", $"Bearer {token}");

            // Execute Request
            var response = client.ExecuteGet(request);

            Logger.Info(response.Content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Получаем тело ответа в виде JObject
                JObject responseData = JObject.Parse(response.Content);

                // Проверка соответствия ответа JSON-схеме
                Assert.That(responseData.IsValid(schema));
            }
        }

        [Test(Description = "Проверка успешного ответа от сервера при запросе пользователя")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("API NFE")]

        public void CheckSuccessfulResponse_WhenGetUser()
        {
            const string endpoint = "users/{user_id}";
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

        [Test(Description = "Проверка успешного ответа от сервера при запросе всех запусков автоматизации в целевом проекте")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("API NFE")]

        public void CheckSuccessfulResponse_WhenGetProjectRuns()
        {
            const string endpoint = "projects/{project_id}/automation/runs";
            const string token = "testmo_api_eyJpdiI6IkZGcDJ4M2JFTkFacCtBVG51dTZST2c9PSIsInZhbHVlIjoiQUZJbnlQVElTOVBockNDeVk5WVlqcHlPeTBpQis1bnpZb1hSbzUrVVR1Zz0iLCJtYWMiOiJiNzE5ZDEzZTc3OTgxYzliZmQzN2Q3OTFmNGY0ZGZkZGE1YTU4MzIyNWY0MDFhMDdkZjZlZjFlMzFiMzk3MzUxIiwidGFnIjoiIn0=";

            // Setup Rest Client
            var client = new RestClient(BaseRestUri);

            // Setup Request
            var request = new RestRequest(endpoint)
                .AddUrlSegment("project_id", 48);

            request.AddHeader("Authorization", $"Bearer {token}");

            // Execute Request
            var response = client.ExecuteGet(request);

            Logger.Info(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test(Description = "Invalid or missing Testmo API token")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("API AFE")]

        public void CheckSuccessfulResponse_WhenGetInvalidToken()
        {
            const string endpoint = "projects/{project_id}";
            const string token = "testmo_api";

            // Setup Rest Client
            var client = new RestClient(BaseRestUri);

            // Setup Request
            var request = new RestRequest(endpoint)
                .AddUrlSegment("project_id", 48);

            request.AddHeader("Authorization", $"Bearer {token}");

            // Execute Request
            var response = client.ExecuteGet(request);

            Logger.Info(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [Test(Description = "Unknown or deleted objects in API requests")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("API AFE")]
        
        public void CheckSuccessfulResponse_WhenGetUnknownProjectId()
        {
            int projectId = new Random().Next(1, 10);

            const string endpoint = "projects/{project_id}";
            const string token = "testmo_api_eyJpdiI6IkZGcDJ4M2JFTkFacCtBVG51dTZST2c9PSIsInZhbHVlIjoiQUZJbnlQVElTOVBockNDeVk5WVlqcHlPeTBpQis1bnpZb1hSbzUrVVR1Zz0iLCJtYWMiOiJiNzE5ZDEzZTc3OTgxYzliZmQzN2Q3OTFmNGY0ZGZkZGE1YTU4MzIyNWY0MDFhMDdkZjZlZjFlMzFiMzk3MzUxIiwidGFnIjoiIn0";

            // Setup Rest Client
            var client = new RestClient(BaseRestUri);

            // Setup Request
            var request = new RestRequest(endpoint)
                .AddUrlSegment("project_id", projectId);

            request.AddHeader("Authorization", $"Bearer {token}");

            // Execute Request
            var response = client.ExecuteGet(request);

            Logger.Info(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}
   
