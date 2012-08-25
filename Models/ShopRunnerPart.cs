using Orchard.ContentManagement;

namespace ShopRunner.Models
{
    public class ShopRunnerPart : ContentPart<ShopRunnerPartRecord>
    {
        public ShopRunnerDivNameRecord DivName
        {
            get { return Record.DivName; }
            set { Record.DivName = value; }
        }
    }
}