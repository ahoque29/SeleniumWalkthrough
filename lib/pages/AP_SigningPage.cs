using OpenQA.Selenium;

namespace SeleniumWalkthrough.lib.pages
{
	public class AP_SigningPage
	{
		private IWebDriver _driver;
		private string _signInUrl = AppConfigReader.SignInPageUrl;
		private IWebElement _emailElement => _driver.FindElement(By.Id("email"));
		private IWebElement _passwordElement => _driver.FindElement(By.Id("passwd"));
		private IWebElement _submitButton => _driver.FindElement(By.Id("SubmitLogin"));
		private IWebElement _alert => _driver.FindElement(By.ClassName("alert"));




		public AP_SigningPage(IWebDriver driver)
		{
			_driver = driver;
		}

		public void NavitageToSignIn()
		{
			_driver.Navigate().GoToUrl(_signInUrl);
		}

		public void SendEmailKeys(string email)
		{
			_emailElement.SendKeys(email);
		}

		public void SendPasswordKeys(string password)
		{
			_passwordElement.SendKeys(password);
		}

		public void ClickSubmitButton()
		{
			_submitButton.Click();
		}

		public IWebElement GetAlertElement()
		{
			return _alert;
		}
	}
}