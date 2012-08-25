using System.Web.Mvc;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Localization;
using ShopRunner.Models;

namespace ShopRunner.Controllers
{
    [ValidateInput(false)]
    public class ShopRunnerController : Controller
    {
        public ShopRunnerController(IOrchardServices services)
        {
            Services = services;
            T = NullLocalizer.Instance;
        }

        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        [HttpGet]
        public ActionResult Settings()
        {
            var settingsPart = Services.WorkContext.CurrentSite.As<ShopRunnerSettingsPart>();
            return View(settingsPart);
        }
    }
}