using Diplom_Pokrovskaya.Core;
using NLog;



namespace Diplom_Pokrovskaya.Tests.UI_tests
{
    [SetUpFixture]
    public class BaseSuite
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [OneTimeSetUp]
        public static void SuiteSetup()
        {
            new NLogConfig().Config();
            Logger.Info("NLog setted up.");
        }
    }
}