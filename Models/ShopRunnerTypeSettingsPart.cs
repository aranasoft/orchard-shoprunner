/*using System.Collections.Generic;
using System.ComponentModel;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.ContentManagement.ViewModels;

namespace ShopRunner.Models
{
    public class ShopRunnerTypeSettingsPart
    {
        [DisplayName("ShopRunner DIV Name")]
        public ShopRunnerDivNameRecord DivName { get; set; }
    }

    public class ShopRunnerTypeSettingsHooks : ContentDefinitionEditorEventsBase
    {
        public override IEnumerable<TemplateViewModel> TypePartEditor(ContentTypePartDefinition definition)
        {
            if (definition.PartDefinition.Name != "ShopRunnerPart")
            {
                yield break;
            }

            var model = definition.Settings.GetModel<ShopRunnerTypeSettingsPart>();

            yield return DefinitionTemplate(model);
        }

        public override IEnumerable<TemplateViewModel> TypePartEditorUpdate(ContentTypePartDefinitionBuilder builder, IUpdateModel updateModel)
        {
            if (builder.Name != "ShopRunnerPart")
            {
                yield break;
            }

            var model = new ShopRunnerTypeSettingsPart();
            updateModel.TryUpdateModel(model, "ShopRunnerTypeSettingsPart", null, null);
            builder.WithSetting("ShopRunnerTypeSettingsPart.DivName", model.DivName.Name);
            yield return DefinitionTemplate(model);
        }
    }
}*/