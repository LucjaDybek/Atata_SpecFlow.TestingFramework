using Atata;
using IFlow.Testing.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atata_SpecFlow.TestingFramework.Pages
{
    [Url("http://dax-aos2/ProjectDetails/Index/?projectDetailsId=16187")]
    public class ProjectDetailsPage : BasePage<ProjectDetailsPage>
    {
        public int findGarageParkingPlaces()
        {
            var element = AtataContext.Current.Driver.FindElement(By.XPath("//div[contains(text(),'Garage Parking Places')]/parent::div[1]"));
            return int.Parse(element.FindElement(By.ClassName("value")).Text);
        }
    }
}
