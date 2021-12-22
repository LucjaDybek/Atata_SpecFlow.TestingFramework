using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using ExtentReport = AventStack.ExtentReports.ExtentReports;

namespace IFlow.Testing.Utils.Reports
{
    class Reporter
    {

        private static readonly string ConfigFileName = $"{Path.Combine(Path.GetFullPath(Directory.GetCurrentDirectory()), "..", "..", "..", "Utils/Reports", "extentReportConfig.xml")}";
        private static ExtentHtmlReporter _htmlReporter;
        private static ExtentReport _report;
        public static readonly string ReportDir = $"{Path.Combine(Path.GetFullPath(Directory.GetCurrentDirectory()), "..", "..", "..", "Report")}";
        public static ExtentTest Step { get; set; }
        public static ExtentTest Scenario { get; set; }

        public static ExtentTest Feature { get; set; }

        public static ExtentReport GetReport()
        {
            return _report;
        }

        private static void SetReport(ExtentReport value)
        {
            _report = value;
        }

        public static void SetupExtentReports()
        {
            InitHtmlReporter(new ExtentHtmlReporter($"{Path.Combine(ReportDir, "index.html")}"));
            InitExtentReport(new ExtentReport());
            CleanReportDir(new DirectoryInfo(ReportDir));
        }

        private static void CleanReportDir(DirectoryInfo directoryInfo)
        {
            foreach (var file in directoryInfo.GetFiles()) file.Delete();
        }

        private static void InitHtmlReporter(ExtentHtmlReporter extentHtmlReporter)
        {
            _htmlReporter = extentHtmlReporter;
            _htmlReporter.LoadConfig(ConfigFileName);
        }


        private static void InitExtentReport(ExtentReport extentReports)
        {
            SetReport(extentReports);
            GetReport().AttachReporter(_htmlReporter);
            GetReport().AddSystemInfo("OS", System.Environment.OSVersion.ToString());
        }

    }
}
