using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Loggin_Reporting.Utils
{
    public static class WaitConditions
    {
        public static Func<IWebDriver, bool> IsElementDisplayed(IWebElement element)
        {
            bool condition(IWebDriver driver)
            {
                try
                {
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (ElementNotVisibleException)
                {
                    return false;
                }
            }
            return condition;
        }

        public static Func<IWebDriver, bool> IsElementDisplayed(By locator)
        {
            bool condition(IWebDriver driver)
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (ElementNotVisibleException)
                {
                    return false;
                }
            }
            return condition;
        }

        public static Func<IWebDriver, IWebElement> ElementDisplayed(IWebElement element)
        {
            IWebElement condition(IWebDriver driver)
            {
                try
                {
                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (ElementNotVisibleException)
                {
                    return null;
                }
            }
            return condition;
        }

        public static Func<IWebDriver, IWebElement> ElementDisplayed(By locator)
        {
            IWebElement condition(IWebDriver driver)
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (ElementNotVisibleException)
                {
                    return null;
                }
            }
            return condition;
        }

        public static Func<IWebDriver, IWebElement> ElementToBoClickable(IWebElement element)
        {
            IWebElement condition(IWebDriver driver)
            {
                try
                {
                    return (element.Displayed && element.Enabled) ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (ElementNotVisibleException)
                {
                    return null;
                }
                catch (ElementClickInterceptedException)
                {
                    return null;
                }
                catch (ElementNotInteractableException)
                {
                    return null;
                }
            }
            return condition;
        }

        public static Func<IWebDriver, IWebElement> ElementToBoClickable(By locator)
        {
            IWebElement condition(IWebDriver driver)
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return (element.Displayed && element.Enabled) ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (ElementNotVisibleException)
                {
                    return null;
                }
                catch (ElementClickInterceptedException)
                {
                    return null;
                }
                catch (ElementNotInteractableException)
                {
                    return null;
                }
            }
            return condition;
        }

        public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> VisibilityOfAllElementsLocatedBy(By locator)
        {
            return (driver) =>
            {
                try
                {
                    var elements = driver.FindElements(locator);
                    if (elements.Any(element => !element.Displayed))
                    {
                        return null;
                    }

                    return elements.Any() ? elements : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }


        public static Func<IWebDriver, bool> ElementExists(By locator)
        {
            bool condition(IWebDriver driver)
            {
                return driver.FindElements(locator).Count > 0;
            }
            return condition;
        }

        public static Func<IWebDriver, bool> TitleIs(string title)
        {
            return (driver) => { return title == driver.Title; };
        }

        public static Func<IWebDriver, bool> TitleContains(string title)
        {
            return (driver) => { return driver.Title.Contains(title); };
        }
    }
}
