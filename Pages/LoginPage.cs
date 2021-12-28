using Atata;
using IFlow.Testing.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atata_SpecFlow.TestingFramework.Pages
{
    [Url("http://dax-aos2:81/Account/Login")]
    public class LoginPage : BasePage<LoginPage>
    {
        [FindByXPath("//*[@placeholder='Username']")]
        public TextInput<LoginPage> username { get; set; }

        //[FindByXPath("//*[@name='Password']")]
        //public PasswordInput<LoginPage> password { get; set; }

        [FindByXPath("//button[contains(text(),'Login')]")]
        public Button<LoginPage> buttonlogin { get; set; }
    }
}
