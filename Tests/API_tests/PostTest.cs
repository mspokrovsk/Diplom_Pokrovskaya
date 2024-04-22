using Allure.NUnit.Attributes;
using Allure.Net.Commons;
using RestSharp;
using System.Net;
using NLog;
using Allure.NUnit;
using Diplom_Pokrovskaya.Models;

namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    [Parallelizable(scope: ParallelScope.All)]
    [AllureNUnit]
    [AllureEpic("API")]
        
    public class PostTest
    {
        protected readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private const string BaseRestUri = "https://mspokrovsk.testmo.net/api/v1/";
        private readonly Runs _runIdManager = new Runs();
        private static readonly object lockObject = new object();
        private static bool isFirstTestExecuted = false;
        private static AutoResetEvent autoResetEvent = new AutoResetEvent(false);

        [OneTimeTearDown]
        public void Dispose()
        {
            autoResetEvent.Dispose();
        }

        [Test(Description = "Проверка успешного запуска автоматизации в целевом проекте"), Order(1)]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("API POST")]

        public void CheckSuccessfulResponse_WhenPostRuns()
        {
            lock (lockObject)
            {
                const string endpoint = "projects/{project_id}/automation/runs";
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
                    .AddUrlSegment("project_id", 48)
                    .AddJsonBody(expectedRun);

                request.AddHeader("Authorization", $"Bearer {token}");

                // Execute Request
                var response = client.ExecutePost<Runs>(request);
                Runs actualRun = response.Data;

                Logger.Info(actualRun);

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

                // Получаем значение поля "id"
                int id = actualRun.Id;

                // Сохраняем значение "id" для использования в следующем тесте
                _runIdManager.SaveRunId(id);

                Logger.Info($"Çíà÷åíèå ïîëÿ 'id': {id}");

                isFirstTestExecuted = true;

                autoResetEvent.Set();
            }
        }

        [Test(Description = "Проверка успешного завершения запуска автоматизации в целевом проекте"), Order(2)]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("mspokrovsk")]
        [AllureStory("API POST")]

        public void CheckSuccessfulResponse_WhenPostRunsComplete()
        {
            const string endpoint = "automation/runs/{automation_run_id}/complete";
            const string token = "testmo_api_eyJpdiI6IkZGcDJ4M2JFTkFacCtBVG51dTZST2c9PSIsInZhbHVlIjoiQUZJbnlQVElTOVBockNDeVk5WVlqcHlPeTBpQis1bnpZb1hSbzUrVVR1Zz0iLCJtYWMiOiJiNzE5ZDEzZTc3OTgxYzliZmQzN2Q3OTFmNGY0ZGZkZGE1YTU4MzIyNWY0MDFhMDdkZjZlZjFlMzFiMzk3MzUxIiwidGFnIjoiIn0=";
            
            while (!isFirstTestExecuted)
            {
                WaitHandle.WaitAll(new WaitHandle[] { autoResetEvent });
            }

            // Получаем значение "id" из предыдущего теста
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
   
