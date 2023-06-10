using Epam.TestCases.Epam.Site.Methods;
using Epam.Utilities;
using NUnit.Framework;
using static Epam.TestCases.Epam.Site.Locators.SimpleInteractionsLocators;

namespace Epam.TestCases.Epam.Tests;

[TestFixture]
// can't make ParallelScope.All because all tests use the same driver
internal class SimpleInteractionsTests : BaseTest
{
    [Test]
    public void HorizontalScrollableSectionTest()
    {
        tests = new SimpleInteractionsMethods(driver, report, "https://www.epam.com/");
        tests.ScrollableSection(horizontalScrollableSection);
    }

    [Test]
    public void VerticalScrollableSectionTest()
    {
        tests = new SimpleInteractionsMethods(driver, report, "https://www.epam.com/services/strategy/talent-enablement");
        tests.ScrollableSection(verticalScrollableSection);
    }

    [Test]
    public void CategoriesSwitcherTest()
    {
        tests = new SimpleInteractionsMethods(driver, report, "https://www.epam.com/services/strategy/optimizing-for-growth");
        tests.CategoriesSwitcher(categoriesSwitcher);
    }

    [Test]
    public void SliderSectionTest()
    {
        tests = new SimpleInteractionsMethods(driver, report, "https://www.epam.com/services/engineering/mach");
        tests.ButtonSlides(btnSlides);
    }

    [Test]
    public void SectionWrapperTest()
    {
        tests = new SimpleInteractionsMethods(driver, report, "https://www.epam.com/services/engineering/iot");
        tests.SectionWrapper(sectionWrapper, "https://www.epam.com/services/engineering/iot");
    }

    [Test]
    public void SideMenuTest()
    {
        tests = new SimpleInteractionsMethods(driver, report, "https://www.epam.com/");
        tests.SideMenu(sideMenuList);
    }
}