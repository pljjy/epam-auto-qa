using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Epam.Source.WebDriver;

public class DriverFactory
{
    private static bool headless = true;
    internal static IWebDriver GetBrowser(ETypeDriver eTypeDriver, int implWait = 0, bool _headless = true)
    {
        headless = _headless;
        
        IWebDriver driver;
        switch (eTypeDriver)
        {
            case ETypeDriver.Firefox:
                driver = GetFirefox();
                break;
            case ETypeDriver.Edge:
                driver = GetEdge();
                break;
            default:
                driver = GetChrome();
                break;
        }

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implWait);

        return driver;
    }


    private static IWebDriver GetChrome()
    {
        var opts = new ChromeOptions();
        if(headless) opts.AddArgument("--headless");
        opts.AddArguments("--ignore-ssl-errors=yes",
            "--ignore-certificate-errors", "--window-size=1980,1080");
        ChromeDriver driver = new ChromeDriver(opts);
        driver.Manage().Window.Maximize();

        return driver;
    }

    private static IWebDriver GetFirefox()
    {
        var opts = new FirefoxOptions();
        if(headless) opts.AddArgument("--headless");
        opts.AddArgument("--window-size=1980,1080");
        FirefoxDriver driver = new FirefoxDriver();
        driver.Manage().Window.Maximize();

        return driver;
    }

    private static IWebDriver GetEdge()
    {
        var opts = new EdgeOptions();
        if(headless) opts.AddArgument("--headless");
        opts.AddArguments("--ignore-ssl-errors=yes",
            "--ignore-certificate-errors", "disable-gpu",
            "--disable-extensions");
        EdgeDriver driver = new EdgeDriver(opts);
        driver.Manage().Window.Maximize();

        return driver;
    }
}