using ParallelExecutionNunit.Selenium_Driver;

namespace ParallelExecutionNunit.Page_Objects
{
    public class ProductPage 
    {
        
        public void GoToProductPage(IWebDriver driver)
        {
            var element = driver.GetElement(By.XPath("//span[text() = 'Products']"));

            if (!element.Displayed)
            {
                driver.Click(By.XPath("//button[text() = 'Open Menu']"), "Open Menu");
                driver.Click(By.XPath("//a[text() = 'All Items']"), "All Items");
            }
        }


        public bool IsProductVisible(IWebDriver driver, string productName)
        {
            return driver.GetElement(By.XPath($"//div[text() = '{productName}']")).Displayed;
        }

    }
}
