using JetBrains.Annotations;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using ShopRunner.Models;

namespace ShopRunner.Handlers
{
    [UsedImplicitly]
    public class ShopRunnerPartHandler : ContentHandler
    {
        public ShopRunnerPartHandler(IRepository<ShopRunnerPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}