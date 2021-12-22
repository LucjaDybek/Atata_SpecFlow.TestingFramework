using Atata;
using IFlow.Testing.Utils.DataBase;
using IFlow.Testing.Utils.DataFactory;
using System;
using TechTalk.SpecFlow;

namespace IFlow.Testing.StepDefinitions
{
    [Binding]
    public abstract class BaseSteps : Steps
    {
        protected TPageObject On<TPageObject>()
            where TPageObject : PageObject<TPageObject>
        {
            return (AtataContext.Current.PageObject as TPageObject)
                   ?? Go.To<TPageObject>(navigate: false);
        }

        protected User User { get; set; }

        [Obsolete("Visual Studio IntelliSense Work Around", true)]
        protected void SetRandomUser(ScenarioContext scenarioContext)
        {
            User = UserData.CreateUserData().Generate();
            scenarioContext.Add(ScenarioContextDataKeys.UserName, User.UserName); 
            scenarioContext.Add(ScenarioContextDataKeys.Password, User.Password);
            scenarioContext.Add(ScenarioContextDataKeys.FirstName, User.FirstName);
            scenarioContext.Add(ScenarioContextDataKeys.Email, User.Email);
            scenarioContext.Add(ScenarioContextDataKeys.LastName, User.LastName);
            scenarioContext.Add(ScenarioContextDataKeys.PhoneNumber, User.PhoneNumber);
            scenarioContext.Add(ScenarioContextDataKeys.Country, User.Country);
        }
        
        [Obsolete("Visual Studio IntelliSense Work Around", true)]
        protected string GetRandomUser(ScenarioContext scenarioContext, string property)
        {
            return scenarioContext.Get<string>(property); 
        }

        [Obsolete("Visual Studio IntelliSense Work Around", true)]
        protected void SetSize(ScenarioContext scenarioContext, int sizeA, int sizeB)
        {
            scenarioContext.Add(ScenarioContextDataKeys.SizeA, sizeA);
            scenarioContext.Add(ScenarioContextDataKeys.SizeB, sizeB);
        }

        [Obsolete("Visual Studio IntelliSense Work Around", true)]
        protected int GetSize(ScenarioContext scenarioContext, string property)
        {
            return scenarioContext.Get<int>(property);
        }
    }
}
