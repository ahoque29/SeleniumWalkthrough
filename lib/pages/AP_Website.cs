using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumWalkthrough.lib.driver_config;

namespace SeleniumWalkthrough.lib.pages
{
	public class AP_Website
	{
		public IWebDriver Driver { get; set; }

		// accessible page object
		public AP_Homepage AP_Homepage { get; internal set; }
		public AP_SigningPage AP_SigningPage { get; internal set; }

		public AP_Website(string driver, int pageLoadInSecs = 10, int implicitWaitSecs = 10)
		{
			Driver = new SeleniumDriverConfig(driver, pageLoadInSecs, implicitWaitSecs).Driver;
			AP_Homepage = new AP_Homepage(Driver);
			AP_SigningPage = new AP_SigningPage(Driver);
		}

		public void MaximizeWindow()
		{
			Driver.Manage().Window.Maximize();
		}

		public void DeleteCookies()
		{
			Driver.Manage().Cookies.DeleteAllCookies();
		}

		public string GetPageTitle()
		{
			return Driver.Title;
		}

	}
}
