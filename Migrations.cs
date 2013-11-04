using System;
using System.Collections.Generic;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data;
using Orchard.Data.Migration;
using ShopRunner.Models;

namespace ShopRunner {
    public class Migrations : DataMigrationImpl {
        private readonly IRepository<ShopRunnerDivNameRecord> _divNameRepository;

        private readonly IEnumerable<ShopRunnerDivNameRecord> _divNames = new List<ShopRunnerDivNameRecord> {
            new ShopRunnerDivNameRecord {Name = "sr_headerDiv"},
            new ShopRunnerDivNameRecord {Name = "sr_bannerDiv"},
            new ShopRunnerDivNameRecord {Name = "sr_smallBannerDiv"},
            new ShopRunnerDivNameRecord {Name = "sr_productDetailDiv"},
            new ShopRunnerDivNameRecord {Name = "sr_catalogProductDiv"},
            new ShopRunnerDivNameRecord {Name = "sr_catalogProductGridDiv"},
            new ShopRunnerDivNameRecord {Name = "sr_cartProductDiv"},
            new ShopRunnerDivNameRecord {Name = "sr_shippingOptionDiv"},
            new ShopRunnerDivNameRecord {Name = "sr_shippingSummaryDiv"},
            new ShopRunnerDivNameRecord {Name = "sr_cartSummaryDiv"},
            new ShopRunnerDivNameRecord {Name = "sr_duelEligibilityDiv"},
            new ShopRunnerDivNameRecord {Name = "sr_checkoutPageDiv"},
            new ShopRunnerDivNameRecord {Name = "sr_checkoutSRItemsPageDiv"}
        };

        public Migrations(IRepository<ShopRunnerDivNameRecord> divNameRepository) {
            _divNameRepository = divNameRepository;
        }

        public int Create() {
            SchemaBuilder.CreateTable("ShopRunnerDivNameRecord",
                table => table
                    .Column<int>("Id", column => column.PrimaryKey().Identity())
                    .Column<string>("Name", column => column.WithLength(50))
                );
            // Creating table ShopRunnerPartRecord
            SchemaBuilder.CreateTable("ShopRunnerPartRecord",
                table => table
                    .ContentPartRecord()
                    .Column<int>("DivName_Id")
                );

            ContentDefinitionManager.AlterPartDefinition(
                typeof (ShopRunnerPart).Name, cfg => cfg.Attachable()
                );

            // Creating table ShopRunnerSettingsPartRecord
            SchemaBuilder.CreateTable("ShopRunnerSettingsPartRecord",
                table => table
                    .ContentPartRecord()
                    .Column<string>("RetailerId")
                    .Column<string>("LoginValidationUrl")
                    .Column<string>("EnvironmentId", col => col.WithDefault(ShopRunnerEnvironmentMode.Development.ToString()))
                );

            return 1;
        }

        public int UpdateFrom1() {
            if (_divNameRepository == null) {
                throw new InvalidOperationException("Couldn't find DIV Name repository.");
            }
            foreach (var divName in _divNames) {
                _divNameRepository.Create(divName);
            }

            return 2;
        }
    }
}