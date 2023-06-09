﻿using AventStack.ExtentReports;
using Epam.Source.Extensions;
using Epam.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Epam.TestCases.Epam.Site.Methods;

public class SimpleInteractionsMethods : BaseMethod
{
    public SimpleInteractionsMethods(IWebDriver driver, ReportClass report, string url)
        : base(driver, report, url) { }

    /// <summary>
    /// Test for section wrapper
    /// Example of section wrapper: https://www.epam.com/services/engineering/iot
    /// </summary>
    /// <param name="_mainDiv">
    /// should end with /div[contains(@class, 'section__wrapper')]/child::accordion
    /// </param>
    /// <param name="url">to show url where accordion with an index doesn't work</param>
    public void SectionWrapper(By _mainDiv, string url)
    {
        try
        {
            var elements = driver.FindElement(_mainDiv)
                        .FindElements(By.XPath(".//child::div[@class='accordion']"));
            driver.ScrollElementIntoView(elements[(elements.Count / 2)]);

            // report.Debug("scrolled", driver.CaptureScreenshot());
            // report.Debug("elements found " + elements.Count);

            for (var index = 0; index < elements.Count; index++)
            {
                var ele = elements[index];
                driver.ScrollElementIntoView(ele);
                ele.Click();
                //report.Debug($"element {index} clicked", driver.CaptureScreenshot());
                Thread.Sleep(100);

                if (!ele.Displayed)
                {
                    ThrowErrorAndFailTest($"Accordion {index} doesn't work on page {url}");
                }
                // if it fails, it throws an error so code below won't execute
                report.Debug($"Accordion {index} works");
            }
        }
        catch (Exception e)
        {
            report.Error($"{e.Message}</br><b>Stack trace:</b><br/>" +
                         $"{e.StackTrace?.Replace("\n", "<br/>")}");
            Assert.Fail(e.Message);
        }

    }


    /// <summary>
    /// Test of categories switcher
    /// Example of categories switcher: https://www.epam.com/services/strategy/optimizing-for-growth
    /// </summary>
    /// <param name="_mainDiv">
    /// should be a div with 'categories-switcher-container' in class
    /// </param>
    public void CategoriesSwitcher(By _mainDiv)
    {
        try
        {
            var mainDiv = driver.FindElement(_mainDiv);
            driver.ScrollElementIntoView(mainDiv);

            var _clickableTabs = mainDiv.FindElements(By.XPath(
                ".//div[@class = 'categories-switcher-left-part']/div[@role = 'tablist']/child::div[@role = 'tab']"));
            var _textDivs = mainDiv.FindElements(By.XPath(
                ".//div[@class = 'categories-switcher-right-part']/div[contains(@class, 'categories-switcher__content-item')]"));

            foreach (var _tab in _clickableTabs)
            {
                _tab.FindElement(By.XPath(".//div[@class = 'categories-switcher__button']")).Click(); // clicks the tab

                int index = _clickableTabs.IndexOf(_tab);
                report.Debug($"Tab {index + 1} clicked", driver.CaptureScreenshot());
                bool shownMainText = _textDivs[index].Displayed;

                if (!shownMainText)
                {
                    ThrowErrorAndFailTest(
                        $"Text is not shown. <br/> Categories switcher doesnt work, tabindex of the left button = {index}.",
                        "Categories switcher doesnt work",
                        Status.Fatal);
                }
            }
        }
        catch (Exception e)
        {
            report.Error($"{e.Message}</br><b>Stack trace:</b><br/>" +
                         $"{e.StackTrace?.Replace("\n", "<br/>")}");
            Assert.Fail(e.Message);
        }
    }


    /// <summary>
    /// Test of buttons on elements with slides
    /// Example of such element: https://www.epam.com/services/engineering/mach
    /// </summary>
    /// <param name="_mainArrowsDiv">
    /// the class of div should contain 'slider__navigation'
    /// </param>
    public void ButtonSlides(By _mainArrowsDiv)
    {
        try
        {
            var _mainDiv = driver.FindElement(_mainArrowsDiv);
            driver.ScrollElementIntoView(_mainArrowsDiv);

            int maxSlides = GetNumFromString(_mainDiv.FindElement(
                By.XPath(".//div[@class = 'slider__pagination']/span[contains(@class, 'sum-page')]")).Text);


            var rightArrow = _mainDiv.FindElement(By.XPath(".//button[contains(@class, 'right-arrow')]"));
            var leftArrow = _mainDiv.FindElement(By.XPath(".//button[contains(@class, 'left-arrow')]"));


            for (int x = 1; x < maxSlides + 1; x++)
            {
                rightArrow.Click();
                var currentSlide = GetNumFromString(_mainDiv.FindElement(
                    By.XPath(".//div[@class = 'slider__pagination']/span[contains(@class, 'current-page')]")).Text);

                switch (x)
                {
                    case var max when max == maxSlides:
                        if (currentSlide != 1)
                        {
                            ThrowErrorAndFailTest(
                                $"Right arrow: last slide doesnt lead to the first slide. Pressed {x} times, current slide {currentSlide}",
                                "Last slide doesnt lead to first slide");
                        }
                        break;

                    default:
                        if (currentSlide != x + 1)
                        {
                            ThrowErrorAndFailTest(
                                $"Right arrow: clicked {x} times, but the slide isn't {x + 1}, current slide = {currentSlide}",
                                "Current slide != expected");
                        }
                        break;
                }
            }

            report.Pass("Right arrow works", driver.CaptureScreenshot());
            for (int x = maxSlides; x > 0; x--)
            {
                leftArrow.Click();
                var currentSlide = GetNumFromString(_mainDiv.FindElement(
                    By.XPath(".//div[@class = 'slider__pagination']/span[contains(@class, 'current-page')]")).Text);

                switch (x)
                {
                    case var max when max == maxSlides:
                        if (currentSlide != max)
                        {
                            ThrowErrorAndFailTest(
                                $"Left arrow: pressed left arrow 1 time. Expected slide: 1, actual slide: {currentSlide}",
                                "First slide doesnt lead to last slide");
                        }
                        break;

                    default:
                        if (currentSlide != x)
                        {
                            ThrowErrorAndFailTest(
                                $"Left arrow: pressed left arrow {maxSlides - x + 1} times. Expected slide:{x}, actual slide:{currentSlide}");
                        }
                        break;
                }
            }

            report.Pass("Left arrow works", driver.CaptureScreenshot());
            report.Pass($"<b>Arrows with div <br/> {_mainArrowsDiv} <br/>work</b>");
        }
        catch (Exception e)
        {
            report.Error($"{e.Message} </br><b>Stack trace:</b><br/>" +
                         $"{e.StackTrace?.Replace("\n", "<br/>")}");
            Assert.Fail(e.Message);
        }
    }


    /// <summary>
    /// Test of scrollable section
    /// Example of scrollable section: https://www.epam.com/
    /// </summary>
    /// <param name="_mainDiv">
    /// section should have this attribute: 'data-sticky-scroll-vertical=true'
    /// </param>
    public void ScrollableSection(By _mainDiv)
    {
        try
        {
            ScrollForInfographicScroll(_mainDiv);
            report.Pass("Scroll infographic works", driver.CaptureScreenshot());
        }
        catch (Exception e)
        {
            report.Error($"{e.Message}</br><b>Stack trace:</b><br/>" +
                         $"{e.StackTrace?.Replace("\n", "<br/>")}");
            Assert.Fail(e.Message);
        }
    }

    /// <summary>
    /// Test for list of links in the side menu of the site
    /// This menu should be at every https://epam.com/whatever
    /// </summary>
    /// <param name="_liSideMenuLocator">should end with /child::li</param>
    public void SideMenu(By _liSideMenuLocator)
    {
        try
        {
            var _button = driver.FindElement(By.XPath("//button[@class='hamburger-menu__button']"));
            if (_button.GetAttribute("aria-expanded").Equals("false"))
            {
                _button.Click();
                if (_button.GetAttribute("aria-expanded").Equals("false"))
                {
                    ThrowErrorAndFailTest("Button for the side menu is not working", "Button for the side menu is not working");
                }
            }

            var _listOfSecondItems = driver.FindElements(_liSideMenuLocator);
            foreach (var liSecond in _listOfSecondItems)
            {
                int indexSecond = _listOfSecondItems.IndexOf(liSecond) + 1;
                liSecond.Click();

                var _listOfThirdItems = liSecond.FindElements(By.XPath(".//ul[@class = 'hamburger-menu__sub-list']" +
                                                                       "/child::li[contains(@class, 'third-level-item--collapsed')]"));
                foreach (var thirdLi in _listOfThirdItems)
                {
                    int indexThird = _listOfThirdItems.IndexOf(thirdLi) + 1;

                    var elementWithText = thirdLi.FindElement(By.XPath(".//a"));
                    if (elementWithText.Text.Length > 15) driver.JavaScriptChangeText(elementWithText, "changed");
                    // Telecom, Media & Entertainment text is too large so selenium clicks on the <a> tag with text
                    // to avoid this if the text is too large, it gets changed to "changed"

                    thirdLi.Click();
                    if (!thirdLi.GetAttribute("class").Contains("third-level-item--expanded"))
                    {
                        ThrowErrorAndFailTest(
                            $"Item not clickable <ul><li>number of second level item - {indexSecond}</li>" +
                            $"<li>number of third level item - {indexThird}</li></ul>",
                            "Third item in side menu not clickable");
                    }
                }
            }
        }
        catch (Exception e)
        {
            report.Error($"{e.Message} </br><b>Stack trace:</b><br/>" +
                         $"{e.StackTrace?.Replace("\n", "<br/>")}");
            Assert.Fail(e.Message);
        }
    }

}
