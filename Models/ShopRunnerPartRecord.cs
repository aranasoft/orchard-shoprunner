using Orchard.ContentManagement.Records;

namespace ShopRunner.Models
{
    public class ShopRunnerPartRecord : ContentPartRecord
    {
        public virtual ShopRunnerDivNameRecord DivName { get; set; }
    }
}