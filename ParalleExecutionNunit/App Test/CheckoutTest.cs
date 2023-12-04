using NuGet.Frameworks;
using ParalleExecutionNunit.Page_Objects;
using ParalleExecutionNunit.Selenium_Driver;

namespace ParalleExecutionNunit.AppTest
{
    public class CheckoutTest
    {

        IWebDriver driver;
        CheckoutPage checkoutPage;
        DateTime startTime, endTime;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            checkoutPage = new CheckoutPage();
            driver = driver.InitializeDriver();
            driver.Login();
        }

        [SetUp]
        public void Setup()
        {
            startTime = DateTime.Now;
        }

        [Test, Order(1)]
        public void Check_checkout_Button_Visibility()
        {
            checkoutPage.GoToCheckoutPage(driver);
            Thread.Sleep(2000);
            if (!checkoutPage.CheckOutButtonVisibility(driver))
            {
                Assert.Fail("CheckOut Button is not visible");
            }
        }

        [Test, Order(2)]
        public void CheckOutPage_Test2()
        {
            Thread.Sleep(5000);
            Assert.Pass();
        }

        [Test, Order(3)]
        public void CheckOutPage_Test3()
        {
            Thread.Sleep(3000);
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
            driver.Logout();
            driver.CloseDriver();
            
        }
    }
}