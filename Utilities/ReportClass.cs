using AventStack.ExtentReports;

namespace Epam.Utilities;

/// <summary>
/// This class is all the features i use with ExtentTest but
/// with highlighting 
/// </summary>
public class ReportClass
{
    public readonly ExtentTest log; 
    // TODO: silly name, should change it

    public ReportClass(string name, ExtentReports extent)
    {
        log = extent.CreateTest(name);
    }

    public void Pass(string text, MediaEntityModelProvider? provider = null)
    {
        text = "<font color = 'green'>" + text + "<font/>";
        log.Log(Status.Pass, text, provider);
    }

    public void Debug(string text, MediaEntityModelProvider? provider = null)
    {
        text = "<font color = 'gray'>" + text + "<font/>";
        log.Log(Status.Debug, text, provider);
    }
    public void Info(string text, MediaEntityModelProvider? provider = null)
    {
        text = "<font color = 'blue'>" + text + "<font/>";
        log.Log(Status.Debug, text, provider);
    }
    
    public void Warning(string text, MediaEntityModelProvider? provider = null)
    {
        text = "<font color = 'yellow'>" + text + "<font/>";
        log.Log(Status.Warning, text, provider);
    }

    public void Error(string text, MediaEntityModelProvider? provider = null)
    {
        text = "<font color = 'red'>" + text + "<font/>";
        log.Log(Status.Error, text, provider);
    }

    public void Fatal(string text, MediaEntityModelProvider? provider = null)
    {
        text = "<b><i><font color = 'red'>" + text + "<font/><i/><b/>";
        log.Log(Status.Error, text, provider);
    }
}