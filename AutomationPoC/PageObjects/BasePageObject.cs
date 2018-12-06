using AutomationPoC.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace AutomationPoC.PageObjects
{
    abstract class BasePageObject
    { 
        private IWebDriver driver;

        private const int DefaultTimeoutSeconds = 10;

        public BasePageObject()
        {
            driver = FeatureContext.Current.Get<IWebDriver>();
        }

        public abstract void VerifyPageLoaded();

        public void GoToUrl(String url)
        {
            if (!driver.Url.Equals(url)) { 
               driver.Navigate().GoToUrl(url);
            }
        }

        public IWebElement GetElement(By identifier)
        {
            return WaitUntil(ExpectedConditions.ElementIsVisible(identifier));
        }

        public string GetTextOfElement(By identifier, string expectedText)
        {
            IWebElement elem = GetElement(identifier);
            return elem.Text;
        }

        public string GetValueOfElement(By identifier)
        {
            IWebElement elem = GetElement(identifier);
            return elem.GetAttribute("value");
        }

        protected IWebElement WaitUntil(Func<IWebDriver, IWebElement> expectedCondition)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(DefaultTimeoutSeconds)).Until(expectedCondition);
        }

        protected bool WaitUntil(Func<IWebDriver, bool> expectedCondition)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(DefaultTimeoutSeconds)).Until(expectedCondition);
        }
    }
}
