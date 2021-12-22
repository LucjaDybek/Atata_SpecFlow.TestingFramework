using System;
using System.IO;
using Atata;
using TechTalk.SpecFlow;

namespace IFlow.Testing.Utils.Reports
{
    public static class Providers
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public static string GetUrl (ScenarioContext scenarioContext)
        {
            Logger.Info("Trying to get page url");
            if (AtataContext.Current.Driver.Url != null)
            {
                try
                {
                    var url = AtataContext.Current.Driver.Url;
                    return url;
                }
                catch (Exception e)
                {
                    Logger.Warn(e, "Unable to get URL");
                }
            }
            return null;
        }


        public static string GetPageSource(ScenarioContext scenarioContext)
        {
            Logger.Info("Trying to get page source");

            var pageSourceFileName = $"{RemoveCharactersUnsupportedByWindowsInFileNames(scenarioContext.StepContext.StepInfo.Text)}";
            var path = $"{Path.Combine(Reporter.ReportDir, pageSourceFileName)}";
            if (AtataContext.Current.Driver.PageSource != null)
            {
                try
                {
                    var pageSource = AtataContext.Current.Driver.PageSource;
                    File.WriteAllText(path, pageSource);
                    return pageSourceFileName;
                }
                catch (Exception e)
                {
                    Logger.Warn(e, "Unable to get page source");
                }
            }
            return null;
        }

        public static string GetScreenshot(ScenarioContext scenarioContext)
        {
            Logger.Info("Trying to get screenshot");
            var title = RemoveCharactersUnsupportedByWindowsInFileNames(scenarioContext.StepContext.StepInfo.Text);
            var runName = $"_{DateTime.Now:yyyy-MM-dd-HH_mm_ss}";
            var filename = runName +$"{title.SanitizeForFileName()}.png";
            var path = $"{Path.Combine(Reporter.ReportDir, filename)}";
            {
                var absoluteFilePath = path;
                try
                {
                    var targetDirectory = Path.GetDirectoryName(absoluteFilePath);

                    if (!Directory.Exists(targetDirectory))
                        Directory.CreateDirectory(targetDirectory);
                    ;
                    var screenShot = AtataContext.Current.Driver.GetScreenshot();

                    screenShot.SaveAsFile(path);


                    return filename;
                }
                catch (Exception e)
                {
                    Logger.Warn(e, "Unable to get screenshot");
                }
            }
            return null;
        }

        private static string RemoveCharactersUnsupportedByWindowsInFileNames(string input)
        {
            return input.Replace(" ", "").Replace("\"", "").Replace("\\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace("'", "");
        }
    }
}
