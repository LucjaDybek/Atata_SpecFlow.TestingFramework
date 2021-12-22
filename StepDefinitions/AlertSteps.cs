using Atata;
using FluentAssertions;
using IFlow.Testing.Pages;
using IFlow.Testing.Utils.SelectorsConsts;
using TechTalk.SpecFlow;

namespace IFlow.Testing.StepDefinitions
{
    [Binding]
    public sealed class AlertSteps : BaseSteps
    {
        private AlertPage alertPage;
        private string alertMessage;

        [When(@"User click submit button and alert appears")]
        public void UserClickSubmitButtonAndAlertAppears()
        {
            alertPage = Go.To<AlertPage>()
                 .AlertButton.Click();
            alertMessage = alertPage.GetAlertMessage();
            alertPage.AcceptAlert();
        }

        [Then(@"Alert message is displayed")]
        public void AlertMessageIsDisplayed()
        {
            alertMessage.Equals(MessagesConsts.ClickedButtonMessage).Should().BeTrue();
        }

        [When(@"User click submit button and confirms alert that appears")]
        public void UserClickSubmitButtonAndConfirmsAlertThatAppears()
        {
            alertPage = Go.To<AlertPage>()
                .Cancel.Click();
            alertPage.AcceptAlert();
        }

        [Then(@"Correct message appears on page")]
        public void CorrectMessageAppearsOnPage()
        {
            alertPage.ResultText.Value.Equals(MessagesConsts.ApprovedAlertMessage).Should().BeTrue();
        }
    }
}
