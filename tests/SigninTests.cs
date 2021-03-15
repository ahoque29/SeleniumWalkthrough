using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWalkthrough.lib.pages;

namespace SeleniumWalkthrough
{
    public class SigninTests
    {
        private AP_Website AP_Website { get; } = new AP_Website("chrome");
        
        [Test]
        public void GivenIamOnTheHomePage_WhenIClickTheSigninLink_ThenIGoToTheSignInPage()
        {
            // Arrange ---
            // maximise the browser
            AP_Website.MaximizeWindow();

            // navigate to the Site
            AP_Website.AP_Homepage.Navigate();

            // get reference to SignIn link
            AP_Website.AP_Homepage.ClickSignInLink();
            
            // Assert ---
            // on sign-in page
            Assert.That(AP_Website.GetPageTitle(), Is.EqualTo("Login - My Store"));
        }


		[Test]
		public void GivenIamOnTheSignInPage_AndIEnterAFourDigitPassword_ThenIClickTheSigninButton_ThenIGetAnErrorMessage()
		{
			// Arrange ---
			// maximise the browser
			AP_Website.MaximizeWindow();

			// navigate to the Site
			AP_Website.AP_SigningPage.NavitageToSignIn();

			// get reference to elements
			AP_Website.AP_SigningPage.SendEmailKeys();
			AP_Website.AP_SigningPage.SendPasswordKeys();
			AP_Website.AP_SigningPage.ClickSubmitButton();

			// Assert ---
			// on sign-in page
			var textError = AP_Website.AP_SigningPage.GetAlertElement();
			Assert.That(textError.Text.Contains("Invalid password"));
		}

		[OneTimeTearDown]
		public void TearDown()
		{
			AP_Website.Driver.Quit();
			AP_Website.Driver.Dispose();
		}
	}
}
