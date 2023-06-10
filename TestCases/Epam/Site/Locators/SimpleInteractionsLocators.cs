using OpenQA.Selenium;

namespace Epam.TestCases.Epam.Site.Locators;

/// <summary>
/// Locators for TestFixture SimpleInteractions
/// </summary>
public static class SimpleInteractionsLocators
{
    public static readonly By btnSlides =
        By.XPath(
            "//div[@class = 'content-container parsys']/div[@class = 'slider section'][1]/descendant::div[contains(@class, 'slider__navigation')]");

    public static readonly By horizontalScrollableSection = By.XPath(
        "//section[@class = 'scroll-infographic-ui-23 horizontal-scroll']/div[@data-sticky-scroll = 'true'][contains(@class, 'scroll-infographic-ui-23__scrollable-section')]");

    public static readonly By verticalScrollableSection =
        By.XPath(
            "//section[@class='scroll-infographic-ui-23 vertical-scroll']/div[@data-sticky-scroll='true'][@data-sticky-scroll-vertical='true']");

    public static readonly By categoriesSwitcher = By.XPath(
        "//section[contains(@class ,'section-ui')]/div[contains(@class, 'section__wrapper')]/div[@class = 'categories-switcher']/div[contains(@class, 'categories-switcher-ui-23')]/div[@class = 'categories-switcher-container']");

    public static readonly By sectionWrapper =
        By.XPath(
            "//div[@class='content-container parsys']/div[@class='section'][3]/section/div[@class='section-ui__parallax-wrapper ']/following-sibling::div");
    // WTF: pray they don't move the div or don't delete other sections in main/.'content-container parsys'

    public static readonly By sideMenuList =
        By.XPath(
            "//div[@class='os-padding']/div[contains(@class, 'os-viewport')]/div/child::li[@class='hamburger-menu__item item--collapsed']");
}