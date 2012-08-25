using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement.Records;

namespace ShopRunner.Models
{
    public class ShopRunnerSettingsPartRecord : ContentPartRecord
    {
        [Required]
        public virtual string RetailerId { get; set; }

        public virtual string LoginValidationUrl { get; set; }

        [Required]
        public virtual ShopRunnerEnvironmentMode EnvironmentId { get; set; }
    }
}