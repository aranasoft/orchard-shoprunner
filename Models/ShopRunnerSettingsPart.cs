using System.Collections.Generic;
using Orchard.ContentManagement;

namespace ShopRunner.Models
{
    public class ShopRunnerSettingsPart : ContentPart<ShopRunnerSettingsPartRecord>
    {
        public string RetailerId
        {
            get { return Record.RetailerId; }
            set { Record.RetailerId = value; }
        }

        public string LoginValidationUrl
        {
            get { return Record.LoginValidationUrl; }
            set { Record.LoginValidationUrl = value; }
        }

        public ShopRunnerEnvironmentMode EnvironmentId
        {
            get { return Record.EnvironmentId; }
            set { Record.EnvironmentId = value; }
        }

        public IEnumerable<dynamic> AvailableEnvironmentModes { get; set; }
    }
}