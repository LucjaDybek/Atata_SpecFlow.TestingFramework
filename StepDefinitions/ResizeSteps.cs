using Atata;
using FluentAssertions;
using IFlow.Testing.Pages;
using IFlow.Testing.Utils.DataFactory;
using System;
using TechTalk.SpecFlow;

namespace IFlow.Testing.StepDefinitions
{
    [Binding]
    public sealed class ResizeSteps : BaseSteps
    {
        private int[] orgMesures;
        private int[] newMesures;
        private readonly ScenarioContext _scenarioContext;

        [Obsolete("Visual Studio IntelliSense Work Around", true)]
        public ResizeSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"User increases the box by '(.*)' and '(.*)' pixels dragging handle")]
        [Obsolete("Visual Studio IntelliSense Work Around", true)]
        public void WhenUserMakesBoxBiggerByDraggingHandle(int SizeA, int SizeB)
        {
            SetSize(_scenarioContext, SizeA, SizeB);

            var page = Go.To<ResizePage>();
            orgMesures = page.GetElementSize(page.CommentBox);
            page.ResizeHandle.DragAndDropToOffset(SizeA, SizeB);
        }

        [Then(@"the box has bigger size")]
        [Obsolete("Visual Studio IntelliSense Work Around", true)]
        public void ThenTheBoxHasBiggerSize()
        {
            var page = On<ResizePage>();
            newMesures = page.GetElementSize(page.CommentBox);
            newMesures[0].Equals(orgMesures[0] + GetSize(_scenarioContext,"sizeA")).Should().BeTrue();
            newMesures[1].Equals(orgMesures[1] + GetSize(_scenarioContext, "sizeB")).Should().BeTrue();
        }
    }
}
