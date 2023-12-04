using ParalleExecutionNunit.Page_Objects;
using ParalleExecutionNunit.Selenium_Driver;

namespace ParalleExecutionNunit.AppTest
{
    public class CheckoutTest
    {

        IWebDriver driver;
        CheckoutPage checkoutPage;


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            checkoutPage = new CheckoutPage();
            driver = driver.InitializeDriver();
            driver.Login();
        }

        [Test]
        public void Check_checkout_Button_Visibility()
        {
            checkoutPage.GoToCheckoutPage(driver);
            if (!checkoutPage.CheckOutButtonVisibility(driver))
            {
                Assert.Fail("CheckOut Button is not visible");
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Logout();
            driver.CloseDriver();

        }
    }
}