namespace ParalleExecutionNunit.Selenium_Driver
{
    public static class SeleniumDriver
    {

        public static IWebDriver InitializeDriver(this IWebDriver driver)
        {
            ChromeOptions chromeOptions = new();
            chromeOptions.AddArgument("--headless");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://www.saucedemo.com/";
            return driver;
        }

        public static void CloseDriver(this IWebDriver driver)
        {
            driver.Quit();

        }

        public static void Login(this IWebDriver driver)
        {
            driver.InputValue(By.XPath("//input[@data-test=\"username\"]"), "standard_user", "User Name");
            driver.InputValue(By.XPath("//input[@data-test=\"password\"]"), "secret_sauce", "Password");
            driver.Click(By.XPath("//input[@data-test=\"login-button\"]"), "Log in");
        }

        public static  void Logout(this IWebDriver driver)
        {
            driver.Click(By.XPath("//button[text() = 'Open Menu']"), "Open Menu");
            driver.Click(By.XPath("//a[text() = 'Logout']"), "Log out");
        }

        public static void Click(this IWebDriver driver, By by, string elementName)
        {
            try
            {
                var element = driver.FindElement(by);
                element.Click();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message + $"{elementName} is not clickable");
            }
        }

        public static string GetValue(this IWebDriver driver, By by, string elementName)
        {
            string value = String.Empty;
            try
            {
                value = driver.FindElement(by).GetAttribute("innerText");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message + $"{elementName} is not available");
            }
            return value;
        }

        public static void InputValue(this IWebDriver driver, By by, string value, string elementName)
        {
            try
            {
                driver.FindElement(by).SendKeys(value);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message + $"{elementName} is not available");
            }
        }

        public static IWebElement GetElement(this IWebDriver driver, By by)
        {
                return driver.FindElement(by);
        }
    }
}
