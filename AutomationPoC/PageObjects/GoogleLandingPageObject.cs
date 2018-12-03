using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace AutomationPoC.PageObjects
{
    // todo move methods from BasePageObject into a static class and extend LoadableComponent instead for page verification
    class GoogleLandingPageObject : BasePageObject
    {
        private const string Url = "http://www.google.com";
        private By SearchElement = By.Name("q");

        public GoogleLandingPageObject()
        {
            GoToUrl(Url);
            VerifyPageLoaded();
            ScenarioContext.Current.Set<BasePageObject>(this);
        }

        public override void VerifyPageLoaded()
        {
            WaitUntil(ExpectedConditions.ElementIsVisible(SearchElement));
        }

        public void EnterSearch(string searchString)
        {
            GetElement(SearchElement).SendKeys(searchString + "\n");

            ScenarioContext.Current.Set<BasePageObject>(new GoogleSearchResultsPageObject());
        }
    }
}
