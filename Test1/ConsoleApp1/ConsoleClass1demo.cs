/*using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ConsoleClass1demo
    {
    }
}*/

using OpenQA.Selenium.Support.UI;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
            driver = new ChromeDriver("C:\\Users\\Nirav\\source\\chromedriver_win32", options);
        }

        [Test]
        public void test()
        {
            driver.Url = "https://www.salesgenie.com/sign-in/";
            var csv = new StringBuilder();
            int pageCount = Int32.Parse(driver.FindElement(By.CssSelector("div.page-input")).Text.Split("of")[1].Trim());
            int recordCounter = 1;
            for(int j = 0; j<pageCount; j++)
            {
                Thread.Sleep(3 * 1000);
                //var idTableRows = driver.FindElements(By.CssSelector("table.grid__table.grid__locked-columns-table"));
                var mainTableRows = driver.FindElements(By.CssSelector("table.grid__table.grid-scrolling-table tr"));
                
                for (int i = 0; i < mainTableRows.Count - 1; i++)
                {
                   // var idRow = idTableRows[i];
                    var mainRow = mainTableRows[i];
                    //var recordId = idRow.FindElement(By.CssSelector("span.select-column__column-id")).Text;
                    var name = mainRow.FindElement(By.CssSelector("div.consumer-name-column")).Text;
                    var address = "\""+mainRow.FindElement(By.CssSelector("div.address-column")).Text.Replace("\n", ", ").Replace("\r", "")+"\"";
                    csv.AppendLine($"{recordCounter},{name},{address}");
                    recordCounter++;
                }
                if (!IsNextElementDisabled())
                {
                    driver.FindElement(By.CssSelector("div.next")).Click();
                }
                else
                {
                    break;
                }

            } while (!IsNextElementDisabled());

            File.WriteAllText("C:\\Nirav\\SalesGenie\\1.csv", csv.ToString());


            var abc = "";
        }

        private bool IsNextElementDisabled()
        {
            try
            {
                driver.FindElement(By.CssSelector("div.next.disabled"));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}

//IWebElement emailTextBox = driver.FindElement(By.CssSelector("input.quantumWizTextinputPaperinputInput"));
//emailTextBox.SendKeys("test123@gmail.com");

//            IWebElement fileNoDropDown = driver.FindElement(By.CssSelector("div.quantumWizMenuPaperselectOptionList"));
//fileNoDropDown.Click();

//            var optionsofDropDown = driver.FindElements(By.CssSelector("div.quantumWizMenuPaperselectRipple")); // span.quantumWizMenuPaperselectContent

//Thread.Sleep(5000);
//            var displayedList = new List<bool>();
//            for (var k = 0; k<optionsofDropDown.Count; k++)
//            {
//                //if (k == 3)
//                //{
//                    Thread.Sleep(1000);
//                    displayedList.Add(optionsofDropDown[k]. .Displayed);
//               //     break;
//               // }
//            }


//Actions action = new Actions(driver);
//IWebElement fileOptionValue = optionsofDropDown[3];

////String abc = fileOptionValue.ToString();

//action.MoveToElement(fileOptionValue).Build().Perform();

//Thread.Sleep(1000);
//            fileOptionValue.Click();

//            //SelectElement t = new SelectElement(fileOption);
//            //t.SelectedOption.Text;
//            // var k = t.SelectByIndex();
//            //t.SelectByValue(t.SelectByText);
//            //fileOption.SendKeys(t.SelectedOption.Text);
//            String abc = "";

////SelectElement SelectFileNo = new SelectElement(fileNoDropDown);

////select

////SelectFileNo.SelectByValue("1");
//// fileNoDropDown.SendKeys("1"+Keys.Enter);

//String title = driver.Title;

//String pageSource = driver.PageSource;




///*driver.Url = "http://demo.guru99.com/test/guru99home/";
//// Store locator values of email text box and sign up button				
//IWebElement emailTextBox = driver.FindElement(By.CssSelector("input[id=philadelphia-field-email]"));
//emailTextBox.SendKeys("test123@gmail.com");
//IWebElement signUpButton = driver.FindElement(By.CssSelector("button[id=philadelphia-field-submit]"));

//// emailTextBox.SendKeys("test123@gmail.com");
//signUpButton.Click();
//*/

///*  String title = driver.Title;

//    String pageSource = driver.PageSource;

//    //driver.Manage().Window().maximize();


//    var p = driver.FindElement(By.Name("q"));




//    //driver.FindElement(By.ClassName("searchbox")) .SendKeys("Hey!");
//    // driver.FindElement(By.Name("btnK")).Click();


//    //driver.FindElement(By.Name("btnK")).Click();
//    //var pp = driver.FindElement(By.Name("q"));
//    //var p2 = driver.FindElement(By.Name("btnK"));
//    //  p2.Click();
//    //String k = p.GetAttribute("value");
//    //String kk = pp.GetAttribute("value");
//    p.SendKeys("Cheese!");
//    p.Submit();

//    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

//    driver.FindElements(By.CssSelector("div.r a"))[0].Click();
//   // IWebElement p =  
//        //driver.FindElement(By.Name("btnK")).Click();

//    //String s2 = p.GetAttribute("value"); 

//    //var p1 = driver.FindElement(By.ClassName ("q"));
//    //var p2 = driver.FindElement(By.) 



//*/
