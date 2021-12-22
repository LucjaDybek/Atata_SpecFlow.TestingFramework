using Atata;
using IFlow.Testing.Pages;
using System;
using TechTalk.SpecFlow;

namespace IFlow.Testing.StepDefinitions
{
    [Binding]
    public sealed class TextBoxSteps : BaseSteps
    {
        private readonly ScenarioContext _scenarioContext;

        [Obsolete("Visual Studio IntelliSense Work Around", true)]
        public TextBoxSteps(ScenarioContext scenarioContext)
        {
           _scenarioContext = scenarioContext;   //Initializing scenario context, you can save test session data in it
           SetRandomUser(_scenarioContext);      //Creating new fake user data and saving it in context so it can be used in multiple tests without generating new set 
        }

        [When(@"User input all personal data on address form page")] //SpecFlow binding to feature files, methods are named the same as scenario steps 
        public void WhenUserInputAllPersonalDataOnAddressFormPage()
        {
            Go.To<TextBoxPage>()                 //Open page   
                .UserNameTextBoxInput.Set(User.FirstName + " " + User.LastName) //Make actions on web elements from page you just opened eg. set -> input text 
                .UserEmailTextBoxInput.Set(User.Email) //User.Email is a reference to our generated fake data
                .CurrentAddressTextBoxTextArea.Click()
                .CurrentAddressTextBoxTextArea.Set(User.Country)
                .PermanentAddressTextBoxTextArea.Set(User.Country);
        }

        [When(@"confirm the data by clicking button")]
        public void WhenConfirmTheDataByClickingButton()
        {
            On<TextBoxPage>()                     //On already opened page
                .SubmitTextBoxButton.Click();
        }

        [Then(@"user should see provided data below")]
        public void ThenUserShouldSeeProvidedDataBelow()
        {
            On<TextBoxPage>()
                .TextBoxOutputBox.Should.BeVisible()  //Should is assertion verification if something is as you wanted
                .TextBoxOutputName.Content.Should.Contain($"Name:{User.FirstName} {User.LastName}")
                .TextBoxOutputEmail.Content.Should.Contain($"Email:{User.Email}")
                .TextBoxOutputCurrentAddress.IsVisible.Should.BeTrue()
                .TextBoxOutputCurrentAddress.GetContent(ContentSource.Value).Should.Contain(User.Country)
                .TextBoxOutputPermanentAddress.GetContent(ContentSource.Value).Should.Contain(User.Country);
        }
    }
}
