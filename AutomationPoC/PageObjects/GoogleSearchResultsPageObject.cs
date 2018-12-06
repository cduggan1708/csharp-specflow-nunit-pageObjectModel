using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPoC.PageObjects
{
    class GoogleSearchResultsPageObject : BasePageObject
    {
        private By PageIdentifier = By.Id("rcnt");
        private By SearchElement = By.Name("q");

        public override void VerifyPageLoaded()
        {
            WaitUntil(ExpectedConditions.ElementIsVisible(PageIdentifier));
        }

        public string GetSearchResultFieldValue()
        {
            return GetValueOfElement(SearchElement);
        }
    }
}
