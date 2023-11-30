using OpenQA.Selenium;
using ParalleExecutionNunit.Selenium_Driver;

namespace ParalleExecutionNunit.AppTest
{
    public class ProductTest
    {
        readonly SeleniumDriver seleniumDriver = new();


        [OneTimeSetUp]
        public void Setup()
        {
            seleniumDriver.InitializeDriver();
        }

        [Test]
        public void ProductTest1()
        {
            Assert.Pass();
        }

        [OneTimeTearDown]
        public void TearDown() 
        {
            seleniumDriver.CloseDriver();
        }
    }
}