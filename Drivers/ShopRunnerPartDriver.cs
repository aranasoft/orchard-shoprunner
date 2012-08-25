using JetBrains.Annotations;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using ShopRunner.Models;
using ShopRunner.Services;
using ShopRunner.ViewModels;

namespace ShopRunner.Drivers
{
    [UsedImplicitly]
    public class ShopRunnerPartDriver : ContentPartDriver<ShopRunnerPart>
    {
        private readonly IOrchardServices _services;
        private readonly IShopRunnerService _shopRunnerService;
        private const string TemplateName = "Parts/ShopRunner";

        public ShopRunnerPartDriver(IOrchardServices services, IShopRunnerService shopRunnerService)
        {
            _services = services;
            _shopRunnerService = shopRunnerService;
        }

        protected override string Prefix
        {
            get { return "ShopRunner"; }
        }

        protected override DriverResult Display(ShopRunnerPart part, string displayType, dynamic shapeHelper)
        {
            var shopRunnerSettings = _services.WorkContext.CurrentSite.As<ShopRunnerSettingsPart>();

            if (shopRunnerSettings == null || string.IsNullOrWhiteSpace(shopRunnerSettings.RetailerId))
            {
                return null;
            }

//            var typeSettings = part.Settings.GetModel<ShopRunnerTypeSettingsPart>();
//            var divName = !string.IsNullOrWhiteSpace(part.DivName) ? part.DivName : typeSettings.DivName;
            string divName = part.DivName != null ? part.DivName.Name : string.Empty;

            return ContentShape("Parts_ShopRunner", () =>
                                                    shapeHelper.Parts_ShopRunner(
                                                        DivName: divName
                                                        )
                );
        }

        protected override DriverResult Editor(ShopRunnerPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_ShopRunner_Edit",
                                () => shapeHelper.EditorTemplate(
                                    TemplateName: TemplateName,
                                    Model: BuildEditorViewModel(part),
                                    Prefix: Prefix));
        }

        protected override DriverResult Editor(ShopRunnerPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            var model = new EditShopRunnerViewModel();
            updater.TryUpdateModel(model, Prefix, null, null);

            if (part.ContentItem.Id != 0)
            {
                _shopRunnerService.UpdateDivNameForContentItem(part.ContentItem, model);
            }

            return Editor(part, shapeHelper);
        }

        private EditShopRunnerViewModel BuildEditorViewModel(ShopRunnerPart part)
        {
            return new EditShopRunnerViewModel
                   {
                       DivNames = _shopRunnerService.GetDivNames(),
                       DivName = part.DivName != null ? part.DivName.Name : string.Empty
                   };
        }
    }
}