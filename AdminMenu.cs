using Orchard.Localization;
using Orchard.Security;
using Orchard.UI.Navigation;

namespace ShopRunner {
    public class AdminMenu : INavigationProvider {
        public Localizer T { get; set; }
        public string MenuName { get { return "admin"; } }

        public void GetNavigation(NavigationBuilder builder) {
            builder
                .Add(T("Settings"), menu => menu
                    .Add(T("ShopRunner"), "10.0", subMenu => subMenu.Action("Index", "Admin", new { area = "Arana.ShopRunner" }).Permission(StandardPermissions.SiteOwner)
                        .Add(T("Configuration"), "10.0", item => item.Action("Index", "Admin", new { area = "Arana.ShopRunner" }).Permission(StandardPermissions.SiteOwner).LocalNav())
                    ));
        }
    }
}
