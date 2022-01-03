using Atata;
using Atata_SpecFlow.TestingFramework.Pages;
using IFlow.Testing.StepDefinitions;
using IFlow.Testing.Utils.DataFactory;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Atata_SpecFlow.TestingFramework.StepDefinitions
{
    [Binding]
    public class LoginSteps : BaseSteps
    {

        [Then(@"User is log in")]
        public void assertlogin()
        {
            On<FavoritePage>().Wait(5)
                .AreaFavorite.Should.BeVisible();
        }
    }
}
