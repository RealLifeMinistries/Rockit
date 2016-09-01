using Rock.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.reallifeministries.RockExtensions.Migrations
{
    [MigrationNumber(11, "1.2.0")]
    class _009_GenerateCDACodeWorkflow : Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {
            RockMigrationHelper.UpdateEntityType("Rock.Model.Workflow", "3540E9A7-FE30-43A9-8B0A-A372B63DFC93", true, true);
            RockMigrationHelper.UpdateEntityType("Rock.Model.WorkflowActivity", "2CB52ED0-CB06-4D62-9E2C-73B60AFA4C9F", true, true);
            RockMigrationHelper.UpdateEntityType("Rock.Model.WorkflowActionType", "23E3273A-B137-48A3-9AFF-C8DC832DDCA6", true, true);
            RockMigrationHelper.UpdateEntityType("com.reallifeministries.RockExtensions.Workflow.Action.GenerateAttendanceCode", "CDA6C7A8-3870-4F4E-8371-6F5EC2F4CD78", false, true);
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("CDA6C7A8-3870-4F4E-8371-6F5EC2F4CD78", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Active", "Active", "Should Service be used?", 0, @"False", "E7EF5DBB-BE01-409A-ABAE-051D9918E3E0"); // com.reallifeministries.RockExtensions.Workflow.Action.GenerateAttendanceCode:Active
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("CDA6C7A8-3870-4F4E-8371-6F5EC2F4CD78", "9C204CD0-1233-41C5-818A-C5DA439445AA", "GeneratedCode", "GeneratedCode", "Code that is generated from this action", 0, @"", "BE4F9C67-0FE9-4B85-B318-DC9E3FEDC5FF"); // com.reallifeministries.RockExtensions.Workflow.Action.GenerateAttendanceCode:GeneratedCode
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("CDA6C7A8-3870-4F4E-8371-6F5EC2F4CD78", "9C204CD0-1233-41C5-818A-C5DA439445AA", "ServiceName", "ServiceName", "Service to generate the code for", 0, @"", "416D2781-3A19-438A-B676-412F631A55A7"); // com.reallifeministries.RockExtensions.Workflow.Action.GenerateAttendanceCode:ServiceName
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("CDA6C7A8-3870-4F4E-8371-6F5EC2F4CD78", "A75DFC58-7A1B-4799-BF31-451B2BBE38FF", "Order", "Order", "The order that this service should be used (priority)", 0, @"", "836DFFD2-D0A9-4BE5-B30A-5827E407FC51"); // com.reallifeministries.RockExtensions.Workflow.Action.GenerateAttendanceCode:Order
            RockMigrationHelper.UpdateWorkflowType(false, true, "Generate CDA Code", "", "54E7AF83-F2B8-4099-A1EC-B341B1F8739F", "Work", "fa fa-list-ol", 0, true, 0, "7B06A50F-1F78-4D7A-8232-E9044A327E77"); // Generate CDA Code
            RockMigrationHelper.UpdateWorkflowTypeAttribute("7B06A50F-1F78-4D7A-8232-E9044A327E77", "9C204CD0-1233-41C5-818A-C5DA439445AA", "GeneratedCode", "GeneratedCode", "", 0, @"", "93EF2488-7F6F-487A-9D40-FD0906522F5E"); // Generate CDA Code:GeneratedCode
            RockMigrationHelper.AddAttributeQualifier("93EF2488-7F6F-487A-9D40-FD0906522F5E", "ispassword", @"False", "2197044A-487D-46B3-91B6-FC525AF1FB50"); // Generate CDA Code:GeneratedCode:ispassword
            RockMigrationHelper.UpdateWorkflowActivityType("7B06A50F-1F78-4D7A-8232-E9044A327E77", true, "Generate Code", "", true, 0, "3FA3C493-E079-4BC7-9C42-E76BA6CCD898"); // Generate CDA Code:Generate Code
            RockMigrationHelper.UpdateWorkflowActionType("3FA3C493-E079-4BC7-9C42-E76BA6CCD898", "Generate Code", 0, "CDA6C7A8-3870-4F4E-8371-6F5EC2F4CD78", true, false, "", "", 1, "", "52EA0B1C-9F3D-4C27-8475-48508AF311FA"); // Generate CDA Code:Generate Code:Generate Code
            RockMigrationHelper.AddActionTypeAttributeValue("52EA0B1C-9F3D-4C27-8475-48508AF311FA", "416D2781-3A19-438A-B676-412F631A55A7", @"CDA"); // Generate CDA Code:Generate Code:Generate Code:ServiceName
            RockMigrationHelper.AddActionTypeAttributeValue("52EA0B1C-9F3D-4C27-8475-48508AF311FA", "BE4F9C67-0FE9-4B85-B318-DC9E3FEDC5FF", @"{{Workflow.GeneratedCode}}"); // Generate CDA Code:Generate Code:Generate Code:GeneratedCode
            RockMigrationHelper.AddActionTypeAttributeValue("52EA0B1C-9F3D-4C27-8475-48508AF311FA", "836DFFD2-D0A9-4BE5-B30A-5827E407FC51", @""); // Generate CDA Code:Generate Code:Generate Code:Order
            RockMigrationHelper.AddActionTypeAttributeValue("52EA0B1C-9F3D-4C27-8475-48508AF311FA", "E7EF5DBB-BE01-409A-ABAE-051D9918E3E0", @"False"); // Generate CDA Code:Generate Code:Generate Code:Active
        }
    }
}
