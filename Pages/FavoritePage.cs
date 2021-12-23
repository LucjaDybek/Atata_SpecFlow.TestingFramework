using Atata;
using IFlow.Testing.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atata_SpecFlow.TestingFramework.Pages
{
    public class FavoritePage:BasePage<FavoritePage>
    {
        [FindById("favorites-page")]
        public Clickable<FavoritePage> AreaFavorite { get; set; }
    }
}
