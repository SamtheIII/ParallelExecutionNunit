using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ParalleExecutionNunit.Selenium_Driver
{
    public class SeleniumDriver
    {
        IWebDriver driver;


        //public SeleniumDriver(IWebDriver driver)
        //{
        //    this.driver = driver;
        //}


        public void InitializeDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://www.saucedemo.com/";
            Login();
        }

        public void CloseDriver()
        {
            Logout();
            driver.Quit();

        }

        private void Login()
        {
            InputValue(By.XPath("//input[@data-test=\"username\"]"), "standard_user", "User Name");
            InputValue(By.XPath("//input[@data-test=\"password\"]"), "secret_sauce", "Password");
            Click(By.XPath("//input[@data-test=\"login-button\"]"), "Log in");
        }

        private void Logout()
        {
            Click(By.XPath("//button[text() = 'Open Menu']"), "Open Menu");
            Click(By.XPath("//a[text() = 'Logout']"), "Log out");

        }

        public void Click(By by, string elementName)
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

        public string GetValue(By by, string elementName)
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

        public void InputValue(By by, string value, string elementName)
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
    }
}
