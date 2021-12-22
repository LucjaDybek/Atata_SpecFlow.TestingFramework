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
        protected void SetRandomUser(ScenarioContext scenarioContext)  //Method for creating new fake user data and adding it to scenario,
                                                                       //you can use it in test steps (see TextBoxSteps)
        {
            User = UserData.CreateUserData().Generate();               //Fields for generating data are in Utils/DataFactory/UserData.cs
            scenarioContext.Add(ScenarioContextDataKeys.UserName, User.UserName); //Keys for saving data are in Utils/DataFactory/ScenarioContextDataKeys.cs
            scenarioContext.Add(ScenarioContextDataKeys.Password, User.Password);
            scenarioContext.Add(ScenarioContextDataKeys.FirstName, User.FirstName);
            scenarioContext.Add(ScenarioContextDataKeys.Email, User.Email);
            scenarioContext.Add(ScenarioContextDataKeys.LastName, User.LastName);
            scenarioContext.Add(ScenarioContextDataKeys.PhoneNumber, User.PhoneNumber);
            scenarioContext.Add(ScenarioContextDataKeys.Country, User.Country);
        }
        
        [Obsolete("Visual Studio IntelliSense Work Around", true)]
        protected string GetRandomUser(ScenarioContext scenarioContext, string property) //Method to get fake data from context
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
