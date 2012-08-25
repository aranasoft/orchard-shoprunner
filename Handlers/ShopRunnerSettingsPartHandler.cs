using JetBrains.Annotations;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using ShopRunner.Models;

namespace ShopRunner.Handlers
{
    [UsedImplicitly]
    public class ShopRunnerSettingsPartHandler : ContentHandler
    {
        public ShopRunnerSettingsPartHandler(IRepository<ShopRunnerSettingsPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
            Filters.Add(new ActivatingFilter<ShopRunnerSettingsPart>("Site"));
        }
    }
}