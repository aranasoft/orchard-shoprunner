using System.Collections.Generic;
using System.Linq;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Data;
using ShopRunner.Models;
using ShopRunner.ViewModels;

namespace ShopRunner.Services
{
    public interface IShopRunnerService : IDependency
    {
        void UpdateDivNameForContentItem(ContentItem item, EditShopRunnerViewModel model);
        IEnumerable<ShopRunnerDivNameRecord> GetDivNames();
    }
    public class ShopRunnerService : IShopRunnerService
    {
        private readonly IRepository<ShopRunnerDivNameRecord> _divNameRepository;

        public ShopRunnerService(IRepository<ShopRunnerDivNameRecord> divNameRepository)
        {
            _divNameRepository = divNameRepository;
        }

        public void UpdateDivNameForContentItem(ContentItem item, EditShopRunnerViewModel model)
        {
            var shopRunnerPart = item.As<ShopRunnerPart>();
            shopRunnerPart.DivName = _divNameRepository.Get(dn => dn.Name == model.DivName);
        }

        public IEnumerable<ShopRunnerDivNameRecord> GetDivNames()
        {
            return _divNameRepository.Table.ToList();
        } 
    }
}
