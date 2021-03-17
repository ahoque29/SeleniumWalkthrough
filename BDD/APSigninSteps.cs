using NUnit.Framework;
using SeleniumWalkthrough.lib.pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumWalkthrough.BDD
{
    [Binding]
    public class APSigninSteps
    {
        public AP_Website AP_Website { get; } = new AP_Website("chrome");

        //@navigate
        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            AP_Website.AP_Homepage.Navigate();
        }

        [When(@"I click the Signin link")]
        public void WhenIClickTheSigninLink()
        {
            AP_Website.AP_Homepage.ClickSignInLink();
        }

        [Then(@"I go to the Signin page")]
        public void ThenIGoToTheSigninPage()
        {
            Assert.That(AP_Website.GetPageTitle(), Is.EqualTo("Login - My Store"));
        }

        //@signin
        [Given(@"I am on the sign in page")]
        public void GivenIAmOnTheSignInPage()
        {
            AP_Website.AP_SigningPage.NavitageToSignIn();
        }

        [Given(@"I have entered the email '(.*)'")]
        public void GivenIHaveEnteredTheEmail(string email)
        {
            AP_Website.AP_SigningPage.SendEmailKeys(email);
        }

        [Given(@"I have entered the password (.*)")]
        public void GivenIHaveEnteredThePassword(string password)
        {
            AP_Website.AP_SigningPage.SendPasswordKeys(password);
        }

        [When(@"I click the sign in button")]
        public void WhenIClickTheSignInButton()
        {
            AP_Website.AP_SigningPage.ClickSubmitButton();
        }

        [Then(@"I should see an alert containing the error message '(.*)'")]
        public void ThenIShouldSeeAnAlertContainingTheErrorMessage(string p0)
        {
            var textError = AP_Website.AP_SigningPage.GetAlertElement();
            Assert.That(textError.Text.Contains("Invalid password"));
        }


        [AfterScenario]
        public void DisposeWebDriver()
        {
            AP_Website.Driver.Quit();
            AP_Website.Driver.Dispose();
        }
    }
}
