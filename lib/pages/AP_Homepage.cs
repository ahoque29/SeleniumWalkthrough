using OpenQA.Selenium;

namespace SeleniumWalkthrough.lib.pages
{
	public class AP_Homepage
	{
		private IWebDriver _driver;
		private string _homePageUrl = AppConfigReader.BaseUrl;
		private IWebElement _signInLink => _driver.FindElement(By.LinkText("Sign in"));

		public AP_Homepage(IWebDriver driver)
		{
			_driver = driver;
		}

		public void Navigate()
		{
			_driver.Navigate().GoToUrl(_homePageUrl);
		}

		public void ClickSignInLink()
		{
			_signInLink.Click();
		}

	}
}