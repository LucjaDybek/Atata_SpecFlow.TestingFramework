using System.Linq;
using Atata;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.MarkupUtils;
using IFlow.Testing.Utils.Reports;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace IFlow.Testing
{
    [Binding] 
    public sealed class SpecFlowHooks
    {
        private static ReportPOCO reportPOCO;

        [BeforeTestRun]
        public static void StetUpTestRun()
        {

            AtataContext.GlobalConfiguration
                .UseChrome()
                .WithArguments("start-maximized")
                .UseCulture("en-US")
                .UseAllNUnitFeatures()
                .ApplyJsonConfig<AtataConfig>()
                .UseBaseUrl("https://demoqa.com");
          
            AtataContext.GlobalConfiguration.AutoSetUpDriverToUse();

            reportPOCO = new ReportPOCO();
            Reporter.SetupExtentReports();
        }

        [BeforeFeature]
        public static void SetupBeforeFeature(FeatureContext featureContext)
        {
            featureContext.Set<FeaturePOCO>(new FeaturePOCO(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description));

        }

        [BeforeScenario]
        public static void SetUpScenario(ScenarioContext scenarioContext)
        {
            AtataContext.Configure().Build();

            scenarioContext.Set(new ScenarioPOCO(scenarioContext.ScenarioInfo.Title));
        }

        [AfterStep]
        public static void AfterStep(ScenarioContext scenarioContext)
        {
            scenarioContext.Get<ScenarioPOCO>().Steps.Add(new StepPOCO(scenarioContext.StepContext.StepInfo.Text, scenarioContext.StepContext.StepInfo.StepDefinitionType));
            scenarioContext.Get<ScenarioPOCO>().Steps.Last().StepStatus = Status.Pass;
            scenarioContext.Get<ScenarioPOCO>().Steps.Last().Screenshot = Providers.GetScreenshot(scenarioContext);
            if (scenarioContext.TestError != null)
            {
                scenarioContext.Get<ScenarioPOCO>().Steps.Last().PageSource = Providers.GetPageSource(scenarioContext);
                scenarioContext.Get<ScenarioPOCO>().Steps.Last().URL = Providers.GetUrl(scenarioContext);
                scenarioContext.Get<ScenarioPOCO>().Steps.Last().StepStatus = Status.Error;
                scenarioContext.Get<ScenarioPOCO>().Steps.Last().Exception = scenarioContext.TestError;
            }
        }

        [AfterScenario]
        public static void TearDownScenario(ScenarioContext scenarioContext, FeatureContext featureContext)
        {

            scenarioContext.ScenarioInfo.Tags.ToList().ForEach(tag => scenarioContext.Get<ScenarioPOCO>().Categories.Add(tag));
            scenarioContext.Get<ScenarioPOCO>().Categories.Add("All_tests");
            if (scenarioContext.TestError != null && scenarioContext.Get<ScenarioPOCO>().Steps.Count == 0)
            {
                scenarioContext.Get<ScenarioPOCO>().Steps.Add(new StepPOCO($"scenario failed: {scenarioContext.TestError.Message}", StepDefinitionType.Given, Status.Error));
                scenarioContext.Get<ScenarioPOCO>().Steps.Last().Exception = scenarioContext.TestError;
            }
            featureContext.Get<FeaturePOCO>().Scenarios.Add(scenarioContext.Get<ScenarioPOCO>());

            AtataContext.Current?.CleanUp();
        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext featureContext)
        {
            reportPOCO.Features.Add(featureContext.Get<FeaturePOCO>());
            foreach (var feature in reportPOCO.Features)
            {
                Reporter.Feature = Reporter.GetReport().CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(feature.Title, feature.Description);
                foreach (var scenario in feature.Scenarios)
                {
                    Reporter.Scenario = Reporter.Feature.CreateNode<Scenario>(scenario.Title);
                    scenario.Categories.Sort();
                    scenario.Categories.ForEach(category => Reporter.Scenario.AssignCategory(category));
                    foreach (var step in scenario.Steps)
                    {
                        switch (step.StepType)
                        {
                            case StepDefinitionType.Given:
                                Reporter.Step = Reporter.Scenario.CreateNode<Given>(step.Title);
                                break;
                            case StepDefinitionType.When:
                                Reporter.Step = Reporter.Scenario.CreateNode<When>(step.Title);
                                break;
                            case StepDefinitionType.Then:
                                Reporter.Step = Reporter.Scenario.CreateNode<Then>(step.Title);
                                break;
                        }
                        if (step.StepStatus is Status.Error)
                        {
                            var data = new string[4, 2]
                            {
                                { "Exception", $"{step.Exception.Message}"},
                                { "StackTrace", $"{step.Exception.StackTrace}"},
                                { "URL", $"<a href=\"{step.URL}\">{step.URL}</a>"},
                                { "PageSource", $"<a href=\"{step.PageSource}\">{step.PageSource}</a>"}
                            };
                            Reporter.Step.Fail(MarkupHelper.CreateTable(data));
                        }
                        if (step.Screenshot != null) Reporter.Step.Log(Status.Info, MediaEntityBuilder.CreateScreenCaptureFromPath(step.Screenshot).Build());
                    }
                }
            }
            reportPOCO = new ReportPOCO();
            Reporter.GetReport().Flush();
        }


        [AfterTestRun]
        public static void AfterTestRun()
        {
            Reporter.GetReport().Flush();
            NLog.LogManager.Shutdown();
        }
    }
}
