using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests {
	[TestFixture]
	public class FinalLoginFail {
		private IWebDriver driver;
		private StringBuilder verificationErrors;
		private string baseURL;
		private bool acceptNextAlert = true;

		[SetUp]
		public void SetupTest ()
		{
			driver = new ChromeDriver ();
			baseURL = "https://www.google.com/";
			verificationErrors = new StringBuilder ();
		}

		[TearDown]
		public void TeardownTest ()
		{
			try {
				driver.Quit ();
			} catch (Exception) {
				// Ignore errors if unable to close the browser
			}
			Assert.AreEqual ("", verificationErrors.ToString ());
		}

		[Test]
		public void TestLoginFail ()
		{
			driver.Navigate ().GoToUrl ("https://www.letsusedata.com/index.html");
			driver.FindElement (By.Id ("txtUser")).Clear ();
			driver.FindElement (By.Id ("txtUser")).SendKeys ("test1");
			driver.FindElement (By.Id ("txtPassword")).Clear ();
			driver.FindElement (By.Id ("txtPassword")).SendKeys ("test12456");
			driver.FindElement (By.Id ("javascriptLogin")).Click ();
			for (int second = 0; ; second++) {
				if (second >= 60) Assert.Fail ("timeout");
				try {
					if ("Password was incorrect." == driver.FindElement (By.Id ("lblMessage")).Text) break;
				} catch (Exception) { }
				Thread.Sleep (1000);
			}
			Assert.AreEqual ("Password was incorrect.", driver.FindElement (By.Id ("lblMessage")).Text);
		}


		[Test]
		public void TestLoginSuccess ()
		{
			driver.Navigate ().GoToUrl ("https://www.letsusedata.com/index.html");
			driver.FindElement (By.Id ("txtUser")).Clear ();
			driver.FindElement (By.Id ("txtUser")).SendKeys ("test1");
			driver.FindElement (By.Id ("txtPassword")).Clear ();
			driver.FindElement (By.Id ("txtPassword")).SendKeys ("Test12456");
			driver.FindElement (By.Id ("javascriptLogin")).Click ();
			for (int second = 0; ; second++) {
				if (second >= 60) Assert.Fail ("timeout");
				try {
					if (Regex.IsMatch (driver.Url, "^[\\s\\S]*/CourseSelection\\.html$")) break;
				} catch (Exception) { }
				Thread.Sleep (1000);
			}
			for (int second = 0; ; second++) {
				if (second >= 60) Assert.Fail ("timeout");
				try {
					if (IsElementPresent (By.Id ("26CourseTitle"))) break;
				} catch (Exception) { }
				Thread.Sleep (1000);
			}
			Assert.AreEqual ("Feedback Course 1", driver.FindElement (By.Id ("26CourseTitle")).Text);
		}


		private bool IsElementPresent (By by)
		{
			try {
				driver.FindElement (by);
				return true;
			} catch (NoSuchElementException) {
				return false;
			}
		}

		private bool IsAlertPresent ()
		{
			try {
				driver.SwitchTo ().Alert ();
				return true;
			} catch (NoAlertPresentException) {
				return false;
			}
		}

		private string CloseAlertAndGetItsText ()
		{
			try {
				IAlert alert = driver.SwitchTo ().Alert ();
				string alertText = alert.Text;
				if (acceptNextAlert) {
					alert.Accept ();
				} else {
					alert.Dismiss ();
				}
				return alertText;
			} finally {
				acceptNextAlert = true;
			}
		}
	}



	//[TestFixture]
	//public class FinalLoginSuccess {
	//	private IWebDriver driver;
	//	private StringBuilder verificationErrors;
	//	private string baseURL;
	//	private bool acceptNextAlert = true;

	//	[SetUp]
	//	public void SetupTest ()
	//	{
	//		driver = new ChromeDriver ();
	//		baseURL = "https://www.google.com/";
	//		verificationErrors = new StringBuilder ();
	//	}

	//	[TearDown]
	//	public void TeardownTest ()
	//	{
	//		try {
	//			driver.Quit ();
	//		} catch (Exception) {
	//			// Ignore errors if unable to close the browser
	//		}
	//		Assert.AreEqual ("", verificationErrors.ToString ());
	//	}

	//	[Test]
	//	public void TheFinalLoginSuccessTest ()
	//	{
	//		driver.Navigate ().GoToUrl ("https://www.letsusedata.com/index.html");
	//		driver.FindElement (By.Id ("txtUser")).Clear ();
	//		driver.FindElement (By.Id ("txtUser")).SendKeys ("test1");
	//		driver.FindElement (By.Id ("txtPassword")).Clear ();
	//		driver.FindElement (By.Id ("txtPassword")).SendKeys ("Test12456");
	//		driver.FindElement (By.Id ("javascriptLogin")).Click ();
	//		for (int second = 0; ; second++) {
	//			if (second >= 60) Assert.Fail ("timeout");
	//			try {
	//				if (Regex.IsMatch (driver.Url, "^[\\s\\S]*/CourseSelection\\.html$")) break;
	//			} catch (Exception) { }
	//			Thread.Sleep (1000);
	//		}
	//		for (int second = 0; ; second++) {
	//			if (second >= 60) Assert.Fail ("timeout");
	//			try {
	//				if (IsElementPresent (By.Id ("26CourseTitle"))) break;
	//			} catch (Exception) { }
	//			Thread.Sleep (1000);
	//		}
	//		Assert.AreEqual ("Feedback Course 1", driver.FindElement (By.Id ("26CourseTitle")).Text);
	//	}
	//	private bool IsElementPresent (By by)
	//	{
	//		try {
	//			driver.FindElement (by);
	//			return true;
	//		} catch (NoSuchElementException) {
	//			return false;
	//		}
	//	}

	//	private bool IsAlertPresent ()
	//	{
	//		try {
	//			driver.SwitchTo ().Alert ();
	//			return true;
	//		} catch (NoAlertPresentException) {
	//			return false;
	//		}
	//	}

	//	private string CloseAlertAndGetItsText ()
	//	{
	//		try {
	//			IAlert alert = driver.SwitchTo ().Alert ();
	//			string alertText = alert.Text;
	//			if (acceptNextAlert) {
	//				alert.Accept ();
	//			} else {
	//				alert.Dismiss ();
	//			}
	//			return alertText;
	//		} finally {
	//			acceptNextAlert = true;
	//		}
	//	}
	//}
}
