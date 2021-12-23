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
    public class LoginSteps:BaseSteps
    {
        [When(@"User enter data to login")] 
        public void logintopage() 
        {
            Go.To<LoginPage>().username.Set(UserConsts.login).password.Set(UserConsts.password).buttonlogin.Click();
        }

        [Then(@"User is log in")]

        public void assertlogin()
        {
            On<FavoritePage>().AreaFavorite.Should.BeVisible();
        }

    }
}
