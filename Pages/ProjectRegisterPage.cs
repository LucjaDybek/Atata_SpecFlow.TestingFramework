using Atata;
using IFlow.Testing.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atata_SpecFlow.TestingFramework.Pages
{
    [Url("#/Project/List")]
    public class ProjectRegisterPage:BasePage<ProjectRegisterPage>
    {
        [FindByXPath("(//*[@class='form-select form-select-sm'])[1]")]
        public Select<ProjectRegisterPage> SelectOperatingUnit { get; set; }
    }
}
