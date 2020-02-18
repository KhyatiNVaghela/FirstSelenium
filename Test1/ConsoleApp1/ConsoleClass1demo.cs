/*using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ConsoleClass1demo
    {
    }
}*/

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ConsoleApp1
{
    public class ConsoleClass1demo
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            driver = new ChromeDriver("C:\\Users\\Nirav\\source\\chromedriver_win32" , options);
        }

        [Test]
        public void test()
        {
            driver.Url = "http://www.google.co.in";
            String title = driver.Title;
            String pageSource = driver.PageSource;

           // driver.Manage().Window().maximize();
            var p = driver.FindElement(By.Name("q"));
           
            
            
            //driver.FindElement(By.ClassName("searchbox")) .SendKeys("Hey!");
            // driver.FindElement(By.Name("btnK")).Click();


            //driver.FindElement(By.Name("btnK")).Click();
            //var pp = driver.FindElement(By.Name("q"));
            //var p2 = driver.FindElement(By.Name("btnK"));
            //  p2.Click();
            //String k = p.GetAttribute("value");
            //String kk = pp.GetAttribute("value");
            p.SendKeys("Cheese!");
            p.Submit();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.FindElements(By.CssSelector("div.r a"))[0].Click();
           // IWebElement p =  
                //driver.FindElement(By.Name("btnK")).Click();
            
            //String s2 = p.GetAttribute("value"); 

            //var p1 = driver.FindElement(By.ClassName ("q"));
            //var p2 = driver.FindElement(By.) 




        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}