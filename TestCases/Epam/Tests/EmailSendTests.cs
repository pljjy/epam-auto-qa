using Epam.TestCases.Epam.Site.Methods;
using Epam.Utilities;
using NUnit.Framework;

namespace Epam.TestCases.Epam.Tests;

[TestFixture]
internal class EmailSendTests : BaseTest
{
    [SetUp]
    public void GoToSite()
    {
        tests = new SimpleInteractionsMethods(driver, report, "https://www.epam.com/about/who-we-are/contact");
    }
}