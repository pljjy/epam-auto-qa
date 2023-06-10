using AventStack.ExtentReports;
using Epam.Source.Extensions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

[assembly: Parallelizable(ParallelScope.Fixtures)]
namespace Epam.Utilities;

/// <summary>
/// This class should be inherited by all method classes
/// It provides some tests, report and driver variables and a few methods
/// </summary>
public class BaseMethod
{
    #region Constructor and Variables

    protected IWebDriver driver = null!;
    protected ReportClass report = null!;

    /// <summary>
    /// Initializes variables, goes to the desired site and removes the cookies window
    /// </summary>
    /// <param name="_driver"></param>
    /// <param name="_report"></param>
    /// <param name="url"></param>
    public BaseMethod(IWebDriver _driver, ReportClass _report, string url)
    {
        try
        {
            driver = _driver;
            report = _report;
            driver.Url = url;

            var cookieWindow = driver.FindElement(
                By.XPath("//div[@id = 'onetrust-banner-sdk'][@tabindex = '0'][contains(@class, 'bottom')]"));
            var js = driver.JavaScript();
            js.ExecuteScript("return arguments[0].remove();", cookieWindow);
            // most tests get their clicks intercepted because of the cookies window, the fastest way to solve this is to just remove it from DOM 
        }
        catch (Exception e)
        {
            report.Error($"{e.Message} </br><b>Stack trace:</b><br/>" +
                         $"{e.StackTrace?.Replace("\n", "<br/>")}");
            Assert.Fail(e.Message);
        }
    }

    #endregion

    #region Auxiliary Methods

    public int GetNumFromString(string txt)
    {
        return int.Parse(new string(txt.Where(char.IsDigit).ToArray()));
    }

    public void ThrowErrorAndFailTest(string reportText, string failText = "Something went wrong..",
        Status status = Status.Error)
    {
        report.log.Log(status, reportText, driver.CaptureScreenshot());
        Assert.Fail(failText);
    }

    // this method is defined individually because it's used not only to test scrollable sections, but also to skip them
    public void ScrollForInfographicScroll(By _divScroll, int amountOfPixels = 100)
    {
        var elementScroll = driver.FindElement(_divScroll);
        driver.JavaScript().ExecuteScript("arguments[0].scrollIntoView(true);", elementScroll);
        Actions act = new Actions(driver);

        int scrolledPixels = 0;
        while (elementScroll.GetAttribute("data-sticky-scroll-ended").Equals("false")) //scrolling until it stops
        {
            act.ScrollByAmount(0, amountOfPixels).Perform();
            scrolledPixels += amountOfPixels;
            switch (scrolledPixels)
            {
                case 10000:
                    ThrowErrorAndFailTest("10_000 pixels scrolled, but data-sticky-scroll-ended=\"false\"",
                        "Infographic scroll: 10_000 pixels scrolled but couldn't access data below",
                        Status.Fatal);
                    break;
            }
        }
    }


    /// <summary>
    /// Static methods
    /// </summary>
    public static readonly string pathToJsonFile = GetProjectDirectory() + @"/config.json";

    public static Dictionary<string, dynamic> JsonFileToDictionary(string _path)
    {
        return JObject.Parse(File.ReadAllText(_path)).ToObject<Dictionary<string, dynamic>>()!;
        //WTF: I genuinely have no idea how this works, thanks chatgpt
    }

    public static string GetProjectDirectory()
    {
        return Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent + "";
    }

    #endregion
}