using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SeleniumWalkthrough
{
	public static class AppConfigReader
	{
		public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
		public static readonly string SignInPageUrl = ConfigurationManager.AppSettings["signinpage_url"];
	}
}
