using System.Collections.Generic;
using ShopRunner.Models;

namespace ShopRunner.ViewModels
{
    public class EditShopRunnerViewModel
    {
        public string DivName { get; set; }
        public IEnumerable<ShopRunnerDivNameRecord> DivNames { get; set; } 
    }
}
