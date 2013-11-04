using System;
using System.Linq;
using System.Web.Mvc;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Localization;
using Orchard.Mvc;
using Orchard.Security;
using Orchard.UI.Notify;
using ShopRunner.Models;

namespace ShopRunner.Controllers
{
    [ValidateInput(false)]
    public class AdminController : Controller, IUpdateModel
    {
        public AdminController(IOrchardServices services)
        {
            Services = services;
            T = NullLocalizer.Instance;
        }

        public IOrchardServices Services { get; set; }
        public Localizer T { get; set; }

        #region IUpdateModel Members

        bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties)
        {
            return TryUpdateModel(model, prefix, includeProperties, excludeProperties);
        }

        void IUpdateModel.AddModelError(string key, LocalizedString errorMessage)
        {
            ModelState.AddModelError(key, errorMessage.ToString());
        }

        #endregion

        public ActionResult Index()
        {
            if (!Services.Authorizer.Authorize(StandardPermissions.SiteOwner, T("Not authorized to manage settings")))
            {
                return new HttpUnauthorizedResult();
            }

            var settingsPart = Services.WorkContext.CurrentSite.As<ShopRunnerSettingsPart>();
            settingsPart.AvailableEnvironmentModes = Enum.GetValues(typeof (ShopRunnerEnvironmentMode))
                .Cast<int>()
                .Select(i =>
                        new
                        {
                            Text = Enum.GetName(typeof (ShopRunnerEnvironmentMode), i),
                            Value = i
                        }
                );

            return View(settingsPart);
        }

        [FormValueRequired("submit")]
        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost()
        {
            if (!Services.Authorizer.Authorize(StandardPermissions.SiteOwner, T("Not authorized to manage settings")))
            {
                return new HttpUnauthorizedResult();
            }

            var settingsPart = Services.WorkContext.CurrentSite.As<ShopRunnerSettingsPart>();

            TryUpdateModel(settingsPart);

            if (ModelState.IsValid)
            {
                Services.Notifier.Information(T("ShopRunner updated successfully."));
            }
            else
            {
                Services.TransactionManager.Cancel();
            }

            return Index();
        }

        public void AddModelError(string key, LocalizedString errorMessage)
        {
            ModelState.AddModelError(key, errorMessage.ToString());
        }
    }
}