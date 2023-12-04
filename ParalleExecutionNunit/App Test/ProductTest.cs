using ParalleExecutionNunit.Selenium_Driver;
using ParalleExecutionNunit.Page_Objects;

namespace ParalleExecutionNunit.AppTest
{
    public class ProductTest
    {
        IWebDriver productDriver;
        ProductPage productPage;

        [OneTimeSetUp]
        public void OneTimeSetup() 
        {
            productPage = new ProductPage();
            productDriver = productDriver.InitializeDriver();
            productDriver.Login();
        }

        [Test]
        public void Check_Product_Visibility()
        {
            productPage.GoToProductPage(productDriver);
            if (!productPage.IsProductVisible(productDriver, "Sauce Labs Backpack"))
            {
                Assert.Fail("Prodcut is not visible");
            }

        } 

        [OneTimeTearDown]
        public void OneTimeTearDown() 
        {
            productDriver.Logout();
            productDriver.CloseDriver();
        }
    }
}