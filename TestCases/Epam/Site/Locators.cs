using OpenQA.Selenium;

namespace Epam.TestCases.Epam.Site;

public static class Locators
{
    public static readonly By btnSlides =
        By.XPath(
            "//div[@class = 'content-container parsys']/div[@class = 'slider section'][1]/descendant::div[contains(@class, 'slider__navigation ')]");

    public static readonly By horizontalScrollableSection = By.XPath(
        "//section[@class = 'scroll-infographic-ui-23 horizontal-scroll']/div[@data-sticky-scroll = 'true'][contains(@class, 'scroll-infographic-ui-23__scrollable-section')]");

    public static readonly By verticalScrollableSection =
        By.XPath(
            "//section[@class='scroll-infographic-ui-23 vertical-scroll']/div[@data-sticky-scroll='true'][@data-sticky-scroll-vertical='true']");

    public static readonly By categoriesSwitcher = By.XPath(
        "//section[contains(@class ,'section-ui')]/div[contains(@class, 'section__wrapper')]/div[@class = 'categories-switcher']/div[contains(@class, 'categories-switcher-ui-23')]/div[@class = 'categories-switcher-container']");

    //public static readonly By 


    //HACK: this is not functioning yet and im not sure if it should
    //public static readonly By topNavigationMenuUL = By.XPath(
    //    "//nav[contains(@class, 'top-navigation')][@aria-label = 'Main navigation']/ul[@class = 'top-navigation__row']/child::li");

}