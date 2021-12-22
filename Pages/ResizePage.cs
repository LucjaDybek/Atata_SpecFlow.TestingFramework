using Atata;

namespace IFlow.Testing.Pages
{
    using _ = ResizePage;
    [Url(ResizeUrl)]
    [VerifyTitle("ToolsQA")]
    public class ResizePage : BasePage<_>
    {
        private const string ResizeUrl = "/resizable";

        [FindByXPath("//*[@id='resizableBoxWithRestriction']/span")]
        public Clickable<_> ResizeHandle { get; set; }

        [FindById("resizableBoxWithRestriction")]
        public Text<_> CommentBox { get; set; }
    }
}
