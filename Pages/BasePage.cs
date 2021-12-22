using Atata;
using static Atata.TriggerEvents;
namespace IFlow.Testing.Pages
{
    [Screenshot(AfterAnyAction)]
    public abstract class BasePage<TOwner> : Page<TOwner>
        where TOwner : BasePage<TOwner>
    {
        public int[] GetElementSize(Text<TOwner> element)
        {
            return new int[2] { element.ComponentSize.Width.Value, element.ComponentSize.Height.Value };
        }
        
        public void AcceptAlert()
        {
            AtataContext.Current.Driver.SwitchTo().Alert().Accept();
        }

        public string GetAlertMessage()
        {
            return AtataContext.Current.Driver.SwitchTo().Alert().Text;
        }
    }
}