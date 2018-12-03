using AutomationPoC.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AutomationPoC.StepDefinitions
{
    [Binding]
    class GoogleStepDefinitions
    {
        private const string GoogleLandingPage = "Google Landing";
        private const string GoogleSearchResultsPage = "Google Search Results";

        [Given(@"I am a user on Google")]
        public void GivenIAmAUserOnGoogle()
        {
            new GoogleLandingPageObject();
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string searchString)
        {
            ((GoogleLandingPageObject)ScenarioContext.Current.Get<BasePageObject>()).EnterSearch(searchString);
        }

        [Then(@"I should be directed to the ""(.*)"" page")]
        public void ThenIShouldBeDirectedToThePage(string pageName)
        {
            switch (pageName)
            {
                case GoogleLandingPage:
                    ((GoogleLandingPageObject)ScenarioContext.Current.Get<BasePageObject>()).VerifyPageLoaded();
                    break;
                case GoogleSearchResultsPage:
                    ((GoogleSearchResultsPageObject)ScenarioContext.Current.Get<BasePageObject>()).VerifyPageLoaded();
                    break;
            }
            
        }

        [Then(@"I should see ""(.*)"" in the search field")]
        public void ThenIShouldSeeInTheSearchField(string searchString)
        {
            string actualValue = ((GoogleSearchResultsPageObject)ScenarioContext.Current.Get<BasePageObject>()).GetSearchResultFieldValue(searchString);
            Assert.IsTrue(searchString.Equals(actualValue), string.Format("The search field does not contain the expected value [{0}] but actually found [{1}]", searchString, actualValue));
        }


    }
}
