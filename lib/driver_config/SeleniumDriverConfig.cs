using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumWalkthrough.lib.driver_config
{
	public class SeleniumDriverConfig
	{
		public IWebDriver Driver { get; set; }

		public SeleniumDriverConfig(string driver, int pageLoadInSecs, int implicitWaitSecs)
		{
			DriverSetUp(driver, pageLoadInSecs, implicitWaitSecs);
		}

		private void DriverSetUp(string driver, int pageLoadInSecs, int implicitWaitSecs)
		{
			switch (driver)
			{
				case "chrome":
					SetChromeDriver();
					SetDriverConfiguration(pageLoadInSecs, implicitWaitSecs);
					break;
				case "firefox":
					SetFirefoxDriver();
					SetDriverConfiguration(pageLoadInSecs, implicitWaitSecs);
					break;
				default:
					throw new Exception("Please use 'chrome' or 'firefox'");
			}
		}

		private void SetFirefoxDriver()
		{
			Driver = new FirefoxDriver();
		}

		private void SetChromeDriver()
		{
			Driver = new ChromeDriver();
		}

		private void SetDriverConfiguration(int pageLoadInSecs, int implicitWaitSecs)
		{
			Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSecs);
			Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitSecs);
		}
	}
}
