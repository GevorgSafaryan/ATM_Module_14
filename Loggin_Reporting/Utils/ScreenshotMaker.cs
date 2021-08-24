using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Loggin_Reporting.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Loggin_Reporting.Utils
{
    public class ScreenshotMaker
    {
        private static string NewScreenshotName
        {
            get { return "_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-fff") + "." + ScreenshotImageFormat; }
        }

        private static string NewScreenshotNameWindows
        {
            get { return "_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-fff") + "." + ImageFormat; }
        }

        private static ScreenshotImageFormat ScreenshotImageFormat
        {
            get { return ScreenshotImageFormat.Jpeg; }
        }

        private static ImageFormat ImageFormat
        {
            get { return ImageFormat.Jpeg; }
        }

        public static string TakeBrowserScreenshot()
        {
            var screenshotPath = Path.Combine(Environment.CurrentDirectory, "Display" + NewScreenshotName);
            var image = Browser.Instance.GetDriver().TakeScreenshot();
            image.SaveAsFile(screenshotPath, ScreenshotImageFormat);
            return screenshotPath;
        }

        public static string TakeFullDisplayScreenshot()
        {
            var screenshotPath = Path.Combine(Environment.CurrentDirectory, "FullScreen" + NewScreenshotNameWindows);
            using (Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                {
                    g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                     Screen.PrimaryScreen.Bounds.Y,
                                     0, 0,
                                     bmpScreenCapture.Size,
                                     CopyPixelOperation.SourceCopy);
                }
                bmpScreenCapture.Save(screenshotPath, ImageFormat);
            }
            return screenshotPath;
        }
    }
}
