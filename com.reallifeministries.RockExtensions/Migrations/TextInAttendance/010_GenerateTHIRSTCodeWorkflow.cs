using Rock.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.reallifeministries.RockExtensions.Migrations
{
    [MigrationNumber(12, "1.2.0")]
    class _010_GenerateTHIRSTCodeWorkflow : Migration
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
            RockMigrationHelper.UpdateWorkflowType(false, true, "Generate THIRST Code", "", "4D57D6C1-B4A1-4CC1-BD79-71EF8494ED70", "Work", "fa fa-list-ol", 0, true, 0, "41A69E9A-A7A2-4DED-B99C-73B1D093801D"); // Generate THIRST Code
            RockMigrationHelper.UpdateWorkflowTypeAttribute("41A69E9A-A7A2-4DED-B99C-73B1D093801D", "9C204CD0-1233-41C5-818A-C5DA439445AA", "GeneratedCode", "GeneratedCode", "", 0, @"", "597B7E81-E000-404F-A340-78C06E485E50"); // Generate THIRST Code:GeneratedCode
            RockMigrationHelper.AddAttributeQualifier("597B7E81-E000-404F-A340-78C06E485E50", "ispassword", @"False", "9EB808A8-FCF9-4D37-AD9B-64F94EE7CB80"); // Generate THIRST Code:GeneratedCode:ispassword
            RockMigrationHelper.UpdateWorkflowActivityType("41A69E9A-A7A2-4DED-B99C-73B1D093801D", true, "Generate Code", "", true, 0, "CA5C23C7-2097-4E69-A613-5A9E1089441B"); // Generate THIRST Code:Generate Code
            RockMigrationHelper.UpdateWorkflowActionType("CA5C23C7-2097-4E69-A613-5A9E1089441B", "Generate Code", 0, "CDA6C7A8-3870-4F4E-8371-6F5EC2F4CD78", true, false, "", "", 1, "", "8958A5EE-3011-4D99-B515-F98CD6C58180"); // Generate THIRST Code:Generate Code:Generate Code
            RockMigrationHelper.AddActionTypeAttributeValue("8958A5EE-3011-4D99-B515-F98CD6C58180", "416D2781-3A19-438A-B676-412F631A55A7", @"THIRST"); // Generate THIRST Code:Generate Code:Generate Code:ServiceName
            RockMigrationHelper.AddActionTypeAttributeValue("8958A5EE-3011-4D99-B515-F98CD6C58180", "BE4F9C67-0FE9-4B85-B318-DC9E3FEDC5FF", @"{{Workflow.GeneratedCode}}"); // Generate THIRST Code:Generate Code:Generate Code:GeneratedCode
            RockMigrationHelper.AddActionTypeAttributeValue("8958A5EE-3011-4D99-B515-F98CD6C58180", "836DFFD2-D0A9-4BE5-B30A-5827E407FC51", @""); // Generate THIRST Code:Generate Code:Generate Code:Order
            RockMigrationHelper.AddActionTypeAttributeValue("8958A5EE-3011-4D99-B515-F98CD6C58180", "E7EF5DBB-BE01-409A-ABAE-051D9918E3E0", @"False"); // Generate THIRST Code:Generate Code:Generate Code:Active
        }
    }
}
