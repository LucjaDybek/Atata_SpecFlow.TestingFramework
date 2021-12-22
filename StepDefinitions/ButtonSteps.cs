using Atata;
using FluentAssertions;
using IFlow.Testing.Pages;
using IFlow.Testing.Utils.SelectorsConsts;
using TechTalk.SpecFlow;

namespace IFlow.Testing.StepDefinitions
{
    [Binding]
    public sealed class ButtonSteps : BaseSteps
    {
        [When(@"User double clicks a submit button")]
        public void WhenUserDoubleClicskSubmitButton()
        {
            Go.To<ButtonPage>()
                .DoubleClickButton.DoubleClick();
        }

        [Then(@"Confirm double click message appears")]
        public void ThenConfirmDoubleClickMessageAppears()
        {
            Go.To<ButtonPage>()
                .DoubleClickMessage.Content.Should().Equals(MessagesConsts.DoubleClickMessage);
        }

        [When(@"User right clicks a submit button")]
        public void WhenUserRightClicksSubmitButton()
        {
            Go.To<ButtonPage>()
                .RightClickButton.RightClick();
        }

        [Then(@"Confirm right click message appears")]
        public void ThenConfirmRightClickMessageAppears()
        {
            Go.To<ButtonPage>()
                .RightClickMessage.Content.Should().Equals(MessagesConsts.RightClickMessage);
        }

        [When(@"User clicks a submit button")]
        public void WhenUserClicksSubmitButton()
        {
            Go.To<ButtonPage>()
                .DynamicButton.Click();
        }

        [Then(@"Confirm message appears")]
        public void ThenConfirmMessageAppears()
        {
            Go.To<ButtonPage>()
                .DynamickMessage.Content.Should().Equals(MessagesConsts.DynamicClickMessage);
        }
    }
}
