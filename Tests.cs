using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Printing;

namespace Cas30
{
    class Tests
    {
        IWebDriver driver;
        WebDriverWait wait;
        public static string PEmail;
        public static bool HelpVariable=false;

        [Test]
        public void TestRegistration()
        {
            IWebElement Create_New = wait.Until(EC.ElementIsVisible(By.XPath("//a[text()='Kreiraj novog korisnika']")));
            if (Create_New.Displayed && Create_New.Enabled)
            {
                Create_New.Click();
                IWebElement Button_Registration = driver.FindElement(By.XPath("//input[@name='register']"));
                if (Button_Registration.Enabled && Button_Registration.Displayed)
                {
                    IWebElement Name = driver.FindElement(By.XPath("//input[@name='ime']"));
                    if (Name.Enabled && Name.Displayed)
                    {
                        Name.SendKeys("Milijana");
                        IWebElement LName = driver.FindElement(By.XPath("//input[@name='prezime']"));
                        if (LName.Enabled && LName.Displayed)
                        {
                            LName.SendKeys("Antonic");
                            IWebElement Password = driver.FindElement(By.XPath("//input[@name='korisnicko']"));
                            if (Password.Enabled && Password.Displayed)
                            {
                                Password.SendKeys("123Mili");

                                IWebElement Email = driver.FindElement(By.XPath("//input[@name='email']"));
                                if (Email.Enabled && Email.Displayed)
                                {
                                    //System.Threading.Thread.Sleep(5000);
                                    PEmail = "miliantonic@yahoo.com";
                                    Email.SendKeys(PEmail);
                                    IWebElement Tel = driver.FindElement(By.XPath("//input[@name='telefon']"));
                                    if (Tel.Enabled && Tel.Displayed)
                                    {
                                        Tel.SendKeys("777777");
                                        IWebElement Land = driver.FindElement(By.XPath("//select[@name='zemlja']"));
                                        if (Land.Enabled && Land.Displayed)
                                        {
                                            SelectElement L = new SelectElement(Land);
                                            L.SelectByValue("ita");
                                            IWebElement City = wait.Until(EC.ElementIsVisible(By.XPath("//select[@name='grad']")));
                                            if (City.Enabled && City.Displayed)
                                            {
                                                SelectElement C = new SelectElement(City);
                                                C.SelectByValue("Reggio di Calabria");
                                                IWebElement Adress = driver.FindElement(By.XPath("//div[@id='address']//child::div[2]//input"));
                                                if (Adress.Enabled)
                                                {
                                                    Adress.SendKeys("Garibaldi");

                                                    //System.Threading.Thread.Sleep(2000);

                                                    ReadOnlyCollection<IWebElement> Gender = driver.FindElements(By.XPath("//div[@id='address']//following-sibling::div[1]//child::div[2]//input"));
                                                    if (Gender[1].Enabled && Gender[1].Displayed)
                                                    {
                                                        Gender[1].Click();


                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    IWebElement Notice = driver.FindElement(By.Name("obavestenja"));
                    if (Notice.Displayed && Notice.Enabled)
                    {
                        Notice.Click();
                    }
                    IWebElement Promotions = driver.FindElement(By.Name("promocije"));
                    if (Promotions.Displayed && Promotions.Enabled)
                    {
                        Promotions.Click();

                    }
                    Button_Registration.Click();

                    driver.Navigate().GoToUrl("http://test.qa.rs");
                    IWebElement List_Users = wait.Until(EC.ElementIsVisible(By.XPath("//a[text()='Izlistaj sve korisnike']")));
                    if (List_Users.Enabled)
                    {
                        List_Users.Click();

                        IWebElement Table = wait.Until(EC.ElementIsVisible(By.XPath("//table//td")));
                        if (Table.Enabled)
                        {

                            ReadOnlyCollection<IWebElement> List = Table.FindElements(By.XPath("//table//td[contains(text(),'@')]"));
                            foreach (IWebElement L in List)
                            {

                                if (L.Text == PEmail)
                                {

                                    HelpVariable = true;
                                    

                                }
                            }
                        }
                    }
                }
            }
            if (HelpVariable != true) { Assert.Fail("User is not registered"); }
            else { Assert.Pass("User is registered"); }
        }
        
        
            
        
        
       
    
    
    
        [SetUp]
        public void Setup()
        {
        driver = new FirefoxDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("http://test.qa.rs");
        wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

        }
        [TearDown]
        public void TearDown()
        {
         driver.Close();
        
        }








    }
}
