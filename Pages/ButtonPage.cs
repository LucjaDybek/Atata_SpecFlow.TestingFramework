using Atata;

namespace IFlow.Testing.Pages
{
    using _ = ButtonPage;
    [Url(ButtonUrl)]
    [VerifyTitle("ToolsQA")]
    public class ButtonPage : BasePage<_>
    {
        private const string ButtonUrl = "/buttons";

        [FindById("doubleClickBtn")]
        public Button<_> DoubleClickButton { get; set; }

        [FindById("rightClickBtn")]
        public Button<_> RightClickButton { get; set; }
     
        [FindByXPath("//button[./text() = 'Click Me']")]
        public Button<_> DynamicButton { get; set; }

        [FindById("doubleClickMessage")]
        public Text<_> DoubleClickMessage { get; set; }
       
        [FindById("rightClickMessage")]
        public Text<_> RightClickMessage { get; set; }
       
        [FindById("dynamicClickMessage")]
        public Text<_> DynamickMessage { get; set; }
    }
}
