using Epam.TestCases.Epam.Site;
using Epam.Utilities;
using NUnit.Framework;
using static Epam.TestCases.Epam.Site.Locators;

namespace Epam.TestCases.Epam.Tests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
internal class SimpleInteractionsTests : BaseTest
{
    [Test]
    public void HorizontalScrollableSectionTest()
    {
        tests = new Methods(driver, report, "https://www.epam.com/");
        tests.ScrollableSection(horizontalScrollableSection);
    }

    [Test]
    public void VerticalScrollableSectionTest()
    {
        tests = new Methods(driver, report, "https://www.epam.com/services/strategy/talent-enablement");
        tests.ScrollableSection(verticalScrollableSection);
    }

    [Test]
    public void CategoriesSwitcherTest()
    {
        tests = new Methods(driver, report, "https://www.epam.com/services/strategy/optimizing-for-growth");
        tests.CategoriesSwitcher(categoriesSwitcher);
    }

    [Test]
    public void SliderSectionTest()
    {
        tests = new Methods(driver, report, "https://www.epam.com/services/engineering/mach");
        tests.ButtonSlides(btnSlides);
    }

    [Test]
    public void SectionWrapperTest()
    {
        tests = new Methods(driver, report, "https://www.epam.com/services/engineering/iot");
        tests.SectionWrapper(sectionWrapper, "https://www.epam.com/services/engineering/iot");
    }
}