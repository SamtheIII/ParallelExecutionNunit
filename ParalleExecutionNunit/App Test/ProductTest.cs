using ParalleExecutionNunit.Selenium_Driver;
using ParalleExecutionNunit.Page_Objects;

namespace ParalleExecutionNunit.AppTest
{
    public class ProductTest
    {
        IWebDriver productDriver;
        ProductPage productPage;
        DateTime startTime, endTime;

        [OneTimeSetUp]
        public void OneTimeSetup() 
        {
            productPage = new ProductPage();
            productDriver = productDriver.InitializeDriver();
            productDriver.Login();
        }

        [SetUp]
        public void Setup()
        {
            startTime = DateTime.Now;
        }


        [Test, Order(1)]
        public void Check_Product_Visibility()
        {
            productPage.GoToProductPage(productDriver);
            Thread.Sleep(2000);
            if (!productPage.IsProductVisible(productDriver, "Sauce Labs Backpack"))
            {
                Assert.Fail("Prodcut is not visible");
            }

        }

        [Test, Order(2)]
        public void ProductPage_Test2()
        {
            Thread.Sleep(3000);
            Assert.Pass();
        }

        [Test, Order(3)]
        public void ProductPage_Test3()
        {
            Thread.Sleep(7000);
            Assert.Pass();
        }

        [TearDown]
        public void Teardown()
        {
            endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;
            Console.WriteLine($"Test duration: {duration}");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() 
        {
            productDriver.Logout();
            productDriver.CloseDriver();
        }
    }
}