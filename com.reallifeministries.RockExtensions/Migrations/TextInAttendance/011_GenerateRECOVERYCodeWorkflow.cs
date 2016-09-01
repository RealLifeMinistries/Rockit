using Rock.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.reallifeministries.RockExtensions.Migrations
{
    [MigrationNumber(13, "1.2.0")]
    class _011_GenerateRECOVERYCodeWorkflow : Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {
            RockMigrationHelper.UpdateFieldType("Range Slider", "", "Rock", "Rock.Field.Types.RangeSliderFieldType", "E239F99B-09EE-4AAE-8AA9-53E03EE45F19");
            RockMigrationHelper.UpdateEntityType("Rock.Model.Workflow", "3540E9A7-FE30-43A9-8B0A-A372B63DFC93", true, true);
            RockMigrationHelper.UpdateEntityType("Rock.Model.WorkflowActivity", "2CB52ED0-CB06-4D62-9E2C-73B60AFA4C9F", true, true);
            RockMigrationHelper.UpdateEntityType("Rock.Model.WorkflowActionType", "23E3273A-B137-48A3-9AFF-C8DC832DDCA6", true, true);
            RockMigrationHelper.UpdateEntityType("com.reallifeministries.RockExtensions.Workflow.Action.GenerateAttendanceCode", "CDA6C7A8-3870-4F4E-8371-6F5EC2F4CD78", false, true);
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("CDA6C7A8-3870-4F4E-8371-6F5EC2F4CD78", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Active", "Active", "Should Service be used?", 0, @"False", "E7EF5DBB-BE01-409A-ABAE-051D9918E3E0"); // com.reallifeministries.RockExtensions.Workflow.Action.GenerateAttendanceCode:Active
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("CDA6C7A8-3870-4F4E-8371-6F5EC2F4CD78", "9C204CD0-1233-41C5-818A-C5DA439445AA", "GeneratedCode", "GeneratedCode", "Code that is generated from this action", 0, @"", "BE4F9C67-0FE9-4B85-B318-DC9E3FEDC5FF"); // com.reallifeministries.RockExtensions.Workflow.Action.GenerateAttendanceCode:GeneratedCode
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("CDA6C7A8-3870-4F4E-8371-6F5EC2F4CD78", "9C204CD0-1233-41C5-818A-C5DA439445AA", "ServiceName", "ServiceName", "Service to generate the code for", 0, @"", "416D2781-3A19-438A-B676-412F631A55A7"); // com.reallifeministries.RockExtensions.Workflow.Action.GenerateAttendanceCode:ServiceName
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("CDA6C7A8-3870-4F4E-8371-6F5EC2F4CD78", "A75DFC58-7A1B-4799-BF31-451B2BBE38FF", "Order", "Order", "The order that this service should be used (priority)", 0, @"", "836DFFD2-D0A9-4BE5-B30A-5827E407FC51"); // com.reallifeministries.RockExtensions.Workflow.Action.GenerateAttendanceCode:Order
            RockMigrationHelper.UpdateWorkflowType(false, true, "Generate RECOVERY Code", "", "4D57D6C1-B4A1-4CC1-BD79-71EF8494ED70", "Work", "fa fa-list-ol", 0, true, 0, "E5F05F80-12EF-4418-A9CA-43563FCEAEE2"); // Generate RECOVERY Code
            RockMigrationHelper.UpdateWorkflowTypeAttribute("E5F05F80-12EF-4418-A9CA-43563FCEAEE2", "9C204CD0-1233-41C5-818A-C5DA439445AA", "GeneratedCode", "GeneratedCode", "", 0, @"", "B195D571-ECED-4621-96AF-0F98DC907C9D"); // Generate RECOVERY Code:GeneratedCode
            RockMigrationHelper.AddAttributeQualifier("B195D571-ECED-4621-96AF-0F98DC907C9D", "ispassword", @"False", "F98F4B12-4885-4084-AAE3-88524ADE64AB"); // Generate RECOVERY Code:GeneratedCode:ispassword
            RockMigrationHelper.UpdateWorkflowActivityType("E5F05F80-12EF-4418-A9CA-43563FCEAEE2", true, "Generate Code", "", true, 0, "FACB1155-4F72-4430-8199-FC93A803AD95"); // Generate RECOVERY Code:Generate Code
            RockMigrationHelper.UpdateWorkflowActionType("FACB1155-4F72-4430-8199-FC93A803AD95", "Generate Code", 0, "CDA6C7A8-3870-4F4E-8371-6F5EC2F4CD78", true, false, "", "", 1, "", "E90B3E59-CB77-405F-A724-8F0DEDCB17D3"); // Generate RECOVERY Code:Generate Code:Generate Code
            RockMigrationHelper.AddActionTypeAttributeValue("E90B3E59-CB77-405F-A724-8F0DEDCB17D3", "416D2781-3A19-438A-B676-412F631A55A7", @"RECOVERY"); // Generate RECOVERY Code:Generate Code:Generate Code:ServiceName
            RockMigrationHelper.AddActionTypeAttributeValue("E90B3E59-CB77-405F-A724-8F0DEDCB17D3", "BE4F9C67-0FE9-4B85-B318-DC9E3FEDC5FF", @"{{Workflow.GeneratedCode}}"); // Generate RECOVERY Code:Generate Code:Generate Code:GeneratedCode
            RockMigrationHelper.AddActionTypeAttributeValue("E90B3E59-CB77-405F-A724-8F0DEDCB17D3", "836DFFD2-D0A9-4BE5-B30A-5827E407FC51", @""); // Generate RECOVERY Code:Generate Code:Generate Code:Order
            RockMigrationHelper.AddActionTypeAttributeValue("E90B3E59-CB77-405F-A724-8F0DEDCB17D3", "E7EF5DBB-BE01-409A-ABAE-051D9918E3E0", @"False"); // Generate RECOVERY Code:Generate Code:Generate Code:Active
        }
    }
}
