using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace Selenium_UnitTest_Sample
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private string baseURL,storeURL,formURL;
        private bool acceptNextAlert = true;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new FirefoxDriver();
            //IWebDriver driver = new FirefoxDriver(FirefoxDriverService.CreateDefaultService(), firefoxOptions, TimeSpan.FromSeconds(30));
            baseURL = "http://demoqa.com/";
            storeURL = "http://store.demoqa.com/";
            formURL = "http://toolsqa.com/automation-practice-form/";
        } 


        [TestMethod]
        public void UserRegistration()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Registration"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("name_3_firstname"))).Clear();
            driver.FindElement(By.Id("name_3_firstname")).SendKeys("Victor");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("name_3_lastname"))).Clear();
            driver.FindElement(By.Id("name_3_lastname")).SendKeys("Magana");
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//input[@name='radio_4[]'])[2]"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//input[@name='checkbox_5[]'])[2]"))).Click();
            new SelectElement(driver.FindElement(By.Id("dropdown_7"))).SelectByText("United States");
            new SelectElement(driver.FindElement(By.Id("mm_date_8"))).SelectByText("3");
            new SelectElement(driver.FindElement(By.Id("dd_date_8"))).SelectByText("10");
            new SelectElement(driver.FindElement(By.Id("yy_date_8"))).SelectByText("1997");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("phone_9"))).Clear();
            driver.FindElement(By.Id("phone_9")).SendKeys("7141234567");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username"))).Clear();
            driver.FindElement(By.Id("username")).SendKeys("vmagana3");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("email_1"))).Clear();
            driver.FindElement(By.Id("email_1")).SendKeys("vmagana3@email.com");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("description"))).Clear();
            driver.FindElement(By.Id("description")).SendKeys("Test setup");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password_2"))).Clear();
            driver.FindElement(By.Id("password_2")).SendKeys("thepassword");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("confirm_password_password_2"))).Clear();
            driver.FindElement(By.Id("confirm_password_password_2")).SendKeys("thepassword");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("pie_submit"))).Click();
            Task.Delay(5000).Wait(); // Wait 5 second


            bool is_present = IsElementPresent(By.ClassName("piereg_login_error"));
            if (is_present == true)
            {
                //When registration fails, class=piereg_login_error
                IWebElement err_msg = driver.FindElement(By.ClassName("piereg_login_error"));
                if (err_msg.Displayed == true)
                {
                    Assert.Fail(err_msg.Text);
                }
            }
            else
            {
                //When registration is good, class=piereg_message
                IWebElement good_msg = driver.FindElement(By.ClassName("piereg_message"));
                System.Console.WriteLine(good_msg.Text);

            }

        }

        [TestMethod]
        public void SelectElem()
        {
            int WaitTime = 500;
            driver.Navigate().GoToUrl(baseURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));

            
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Selectable"))).Click();
            IWebElement ListValues=wait.Until(ExpectedConditions.ElementIsVisible(By.Id("selectable")));

            
            List<IWebElement> oElem = new List<IWebElement>(ListValues.FindElements(By.TagName("li")));
            foreach (IWebElement item in oElem)
            {
                Console.WriteLine(item.Text);
                item.Click();
                Thread.Sleep(WaitTime);

            }


            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ui-id-2"))).Click();
            IWebElement GridValues = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("selectable_grid")));
            List<IWebElement> gridElem = new List<IWebElement>(GridValues.FindElements(By.TagName("li")));
            foreach (IWebElement item in gridElem)
            {
                Console.WriteLine(item.Text);
                item.Click();
                Thread.Sleep(WaitTime);

            }


            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ui-id-3"))).Click();
            IWebElement OutputText = driver.FindElement(By.Id("feedback"));
            IWebElement SerialValues = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("selectable-serialize")));
            List<IWebElement> serialElem = new List<IWebElement>(SerialValues.FindElements(By.TagName("li")));
            
            foreach (IWebElement item in serialElem)
            {
                Console.WriteLine(OutputText.Text);
                item.Click();
                Thread.Sleep(WaitTime);
            }



            
            }

        [TestMethod]
        public void StoreLogin()
        {
            driver.Navigate().GoToUrl(storeURL + "/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("AccountMy Account"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("log"))).Clear();
            driver.FindElement(By.Id("log")).SendKeys("vmagana1");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pwd"))).Clear();
            driver.FindElement(By.Id("pwd")).SendKeys("thepassword");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login"))).Click();
            //Wait 5 seconds for verification of credential
            Task.Delay(5000).Wait();
            //Wait for succesful login page
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("entry-title")));

            bool is_present = IsElementPresent(By.ClassName("response"));
            if (is_present == true)
            {
                //When login fails, class=response
                IWebElement err_msg = driver.FindElement(By.ClassName("response"));
                if (err_msg .Displayed == true)
                {
                    Assert.Fail(err_msg.Text);
                }
            }
            else
            {
                //When login is good, class=entry-title
                IWebElement good_msg = driver.FindElement(By.ClassName("entry-title"));
                System.Console.WriteLine(good_msg.Text);

            }

        }

        [TestMethod]
        public void FillForm()
        {
            driver.Navigate().GoToUrl(formURL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("firstname"))).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys("Victor");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("lastname"))).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys("Magana");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("sex-0"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("exp-4"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("datepicker"))).Clear();
            driver.FindElement(By.Id("datepicker")).SendKeys("01/01/17");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("profession-1"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("tool-1"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("tool-2"))).Click();
            new SelectElement(driver.FindElement(By.Id("continents"))).SelectByText("North America");
            //new SelectElement(driver.FindElement(By.Id("selenium_commands"))).SelectByText("Browser Commands");
            SelectElement olistSelect =new SelectElement(driver.FindElement(By.Id("selenium_commands")));
            IList<IWebElement> elemList = olistSelect.Options;
            foreach (IWebElement item in elemList)
            {
                item.Click();
                System.Console.WriteLine(item.Text + " selected: " + item.Selected);

            }


        }

        [TestCleanup]
        public void TestCleanup()
        {
            try
            {
                //driver.Quit();
                driver.Close();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }


        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }



    }
}
