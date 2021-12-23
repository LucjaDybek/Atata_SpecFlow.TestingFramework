using Atata;
using Atata_SpecFlow.TestingFramework.Pages;
using IFlow.Testing.StepDefinitions;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Atata_SpecFlow.TestingFramework.StepDefinitions
{
    [Binding]
    public class ProjectRegisterSteps : BaseSteps
    {
        [When(@"Change Scenario")]
        public void ChangeScenario()
        {
            On<ProjectRegisterPage>().SelectOperatingUnit.Set(" PL");
        }
    }
}
