using AutomationPoC.Common;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationPoC.StepDefinitions
{
    [Binding]
    class SetupAndTeardownSteps
    {

        private static IWebDriver driver;

        [BeforeFeature]
        public static void BeforeFeatureStep()
        {
            driver = DriverHelper.GetDriver();

            // driver is accessible from FeatureContext
            FeatureContext.Current.Set<IWebDriver>(driver);
        }

        [AfterFeature]
        public static void AfterFeatureStep()
        {
            driver.Quit();
            FeatureContext.Current.Clear();
        }
    }
}
