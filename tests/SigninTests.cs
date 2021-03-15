using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWalkthrough
{
    public class SigninTests
    {
        [Test]
        public void GivenIamOnTheHomePage_WhenIClickTheSigninLink_ThenIGoToTheSignInPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                // Arrange ---
                // maximise the browser
                driver.Manage().Window.Maximize();



                // navigate to the Site
                driver.Navigate().GoToUrl("http://automationpractice.com/");



                // get reference to SignIn link
                var loginElement = driver.FindElement(By.ClassName("login"));



                // Act ---
                // click sign in link
                loginElement.Click();



                // wait
                Thread.Sleep(5000);



                // Assert ---
                // on sign-in page
                Assert.That(driver.Title, Is.EqualTo("Login - My Store"));
            }
        }
        [Test]
        public void GivenIamOnTheSignInPage_AndIEnterAFourDigitPassword_ThenIClickTheSigninButton_ThenIGetAnErrorMessage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                // Arrange ---
                // maximise the browser
                driver.Manage().Window.Maximize();



                // navigate to the Site
                driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication");



                // get reference to elements
                var emailElement = driver.FindElement(By.Id("email"));
                var passwordElement = driver.FindElement(By.Id("passwd"));
                var btnSignInElement = driver.FindElement(By.Id("SubmitLogin"));



                // Act ---
                emailElement.SendKeys("testing@snailmail.com");
                passwordElement.SendKeys("four");
                btnSignInElement.Click();



                // wait
                Thread.Sleep(4000);



                // Assert ---
                // on sign-in page
                var textError = driver.FindElement(By.ClassName("alert"));
                Assert.That(textError.Text.Contains("Invalid password"));
            }
        }
    }
}
