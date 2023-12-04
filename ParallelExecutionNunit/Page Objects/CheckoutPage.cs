using ParallelExecutionNunit.Selenium_Driver;

namespace ParallelExecutionNunit.Page_Objects
{
    public  class CheckoutPage
    {
        public void GoToCheckoutPage(IWebDriver driver)
        {
            driver.Click(By.XPath("//a[@class=\"shopping_cart_link\"]"), "Shopping Cart");
        }

        public bool CheckOutButtonVisibility(IWebDriver driver)
        {
            return driver.GetElement(By.Id("checkout")).Displayed;
        }

    }
}
