﻿using Rock.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.reallifeministries.RockExtensions.Migrations
{
    [MigrationNumber(7, "1.2.0")]
    class _005_ReviewContactWorkflowsForTextAttendance : Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {
            RockMigrationHelper.UpdateEntityType("Rock.Model.Workflow", "3540E9A7-FE30-43A9-8B0A-A372B63DFC93", true, true);
            RockMigrationHelper.UpdateEntityType("Rock.Model.WorkflowActivity", "2CB52ED0-CB06-4D62-9E2C-73B60AFA4C9F", true, true);
            RockMigrationHelper.UpdateEntityType("Rock.Model.WorkflowActionType", "23E3273A-B137-48A3-9AFF-C8DC832DDCA6", true, true);
            RockMigrationHelper.UpdateEntityType("com.reallifeministries.RockExtensions.Workflow.Action.SetAttributeFromPersonLava", "85D1DBFE-9F3F-486A-BF2C-60146A8D97F8", false, true);
            RockMigrationHelper.UpdateEntityType("com.reallifeministries.RockExtensions.Workflow.Action.ValidateAttendanceCode", "550458E4-BBBF-4E47-955E-1DBE79352E7D", false, true);
            RockMigrationHelper.UpdateEntityType("Rock.Workflow.Action.ActivateActivity", "38907A90-1634-4A93-8017-619326A4A582", false, true);
            RockMigrationHelper.UpdateEntityType("Rock.Workflow.Action.SetAttributeToInitiator", "4EEAC6FA-B838-410B-A8DD-21A364029F5D", false, true);
            RockMigrationHelper.UpdateEntityType("Rock.Workflow.Action.SetAttributeValue", "C789E457-0783-44B3-9D8F-2EBAB5F11110", false, true);
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("38907A90-1634-4A93-8017-619326A4A582", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Active", "Active", "Should Service be used?", 0, @"False", "E8ABD802-372C-47BE-82B1-96F50DB5169E"); // Rock.Workflow.Action.ActivateActivity:Active
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("38907A90-1634-4A93-8017-619326A4A582", "739FD425-5B8C-4605-B775-7E4D9D4C11DB", "Activity", "Activity", "The activity type to activate", 0, @"", "02D5A7A5-8781-46B4-B9FC-AF816829D240"); // Rock.Workflow.Action.ActivateActivity:Activity
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("38907A90-1634-4A93-8017-619326A4A582", "A75DFC58-7A1B-4799-BF31-451B2BBE38FF", "Order", "Order", "The order that this service should be used (priority)", 0, @"", "3809A78C-B773-440C-8E3F-A8E81D0DAE08"); // Rock.Workflow.Action.ActivateActivity:Order
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("4EEAC6FA-B838-410B-A8DD-21A364029F5D", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Active", "Active", "Should Service be used?", 0, @"False", "7A7B2369-901E-4838-852F-2AB42ABC9EBA"); // Rock.Workflow.Action.SetAttributeToInitiator:Active
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("4EEAC6FA-B838-410B-A8DD-21A364029F5D", "33E6DF69-BDFA-407A-9744-C175B60643AE", "Person Attribute", "PersonAttribute", "The attribute to set to the initiator.", 0, @"", "047336EA-EA6F-46D7-9F32-FB67D2C9DA32"); // Rock.Workflow.Action.SetAttributeToInitiator:Person Attribute
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("4EEAC6FA-B838-410B-A8DD-21A364029F5D", "A75DFC58-7A1B-4799-BF31-451B2BBE38FF", "Order", "Order", "The order that this service should be used (priority)", 0, @"", "8960D3B2-25B4-41BD-84D8-2C88779271F4"); // Rock.Workflow.Action.SetAttributeToInitiator:Order
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("550458E4-BBBF-4E47-955E-1DBE79352E7D", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Active", "Active", "Should Service be used?", 0, @"False", "C9FC261D-84BF-41F7-9636-734EAAF0FD86"); // com.reallifeministries.RockExtensions.Workflow.Action.ValidateAttendanceCode:Active
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("550458E4-BBBF-4E47-955E-1DBE79352E7D", "9C204CD0-1233-41C5-818A-C5DA439445AA", "UserInputCode", "UserInputCode", "The code submitted by the user", 0, @"", "0FC7338D-F75D-401F-8F03-ADDA92315A3B"); // com.reallifeministries.RockExtensions.Workflow.Action.ValidateAttendanceCode:UserInputCode
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("550458E4-BBBF-4E47-955E-1DBE79352E7D", "A75DFC58-7A1B-4799-BF31-451B2BBE38FF", "Order", "Order", "The order that this service should be used (priority)", 0, @"", "18BA2FE7-7620-42CE-8FD8-727A26683B81"); // com.reallifeministries.RockExtensions.Workflow.Action.ValidateAttendanceCode:Order
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("85D1DBFE-9F3F-486A-BF2C-60146A8D97F8", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Active", "Active", "Should Service be used?", 0, @"False", "8DE0F372-4B1C-4612-B318-E598E4CC17F8"); // com.reallifeministries.RockExtensions.Workflow.Action.SetAttributeFromPersonLava:Active
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("85D1DBFE-9F3F-486A-BF2C-60146A8D97F8", "33E6DF69-BDFA-407A-9744-C175B60643AE", "Attribute", "Attribute", "The workflow attribute you will be setting", 0, @"", "40FF47A2-9682-4545-BDF3-171B5F6B8A5C"); // com.reallifeministries.RockExtensions.Workflow.Action.SetAttributeFromPersonLava:Attribute
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("85D1DBFE-9F3F-486A-BF2C-60146A8D97F8", "33E6DF69-BDFA-407A-9744-C175B60643AE", "PersonAttribute", "PersonAttribute", "The workflow attribute containing the person.", 0, @"", "CF19BB9A-EA5B-43E5-89A1-FA416F430761"); // com.reallifeministries.RockExtensions.Workflow.Action.SetAttributeFromPersonLava:PersonAttribute
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("85D1DBFE-9F3F-486A-BF2C-60146A8D97F8", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Lava", "Lava", "Lava to use when setting the attribute.  Normal Workflow merge fields will be available, as well as: {{Person}} which will be the Person model corresponding to the selected Person Attribute", 0, @"", "52930E88-A86E-47AE-BB1D-9937692BBF74"); // com.reallifeministries.RockExtensions.Workflow.Action.SetAttributeFromPersonLava:Lava
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("85D1DBFE-9F3F-486A-BF2C-60146A8D97F8", "A75DFC58-7A1B-4799-BF31-451B2BBE38FF", "Order", "Order", "The order that this service should be used (priority)", 0, @"", "E7527DBD-32B1-47CE-8D22-142EDE32BD7D"); // com.reallifeministries.RockExtensions.Workflow.Action.SetAttributeFromPersonLava:Order
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("C789E457-0783-44B3-9D8F-2EBAB5F11110", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Active", "Active", "Should Service be used?", 0, @"False", "D7EAA859-F500-4521-9523-488B12EAA7D2"); // Rock.Workflow.Action.SetAttributeValue:Active
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("C789E457-0783-44B3-9D8F-2EBAB5F11110", "33E6DF69-BDFA-407A-9744-C175B60643AE", "Attribute", "Attribute", "The attribute to set the value of.", 0, @"", "44A0B977-4730-4519-8FF6-B0A01A95B212"); // Rock.Workflow.Action.SetAttributeValue:Attribute
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("C789E457-0783-44B3-9D8F-2EBAB5F11110", "3B1D93D7-9414-48F9-80E5-6A3FC8F94C20", "Text Value|Attribute Value", "Value", "The text or attribute to set the value from. <span class='tip tip-lava'></span>", 1, @"", "E5272B11-A2B8-49DC-860D-8D574E2BC15C"); // Rock.Workflow.Action.SetAttributeValue:Text Value|Attribute Value
            RockMigrationHelper.UpdateWorkflowActionEntityAttribute("C789E457-0783-44B3-9D8F-2EBAB5F11110", "A75DFC58-7A1B-4799-BF31-451B2BBE38FF", "Order", "Order", "The order that this service should be used (priority)", 0, @"", "57093B41-50ED-48E5-B72B-8829E62704C8"); // Rock.Workflow.Action.SetAttributeValue:Order
            RockMigrationHelper.UpdateWorkflowType(false, true, "Text Review Contact Info", "Text option '4'", "BF7F6EDD-1AA6-442C-BBE2-226591F78D4C", "Work", "fa fa-list-ol", 0, true, 0, "FEB34437-9600-4330-855F-85404EC10018"); // Text Review Contact Info
            RockMigrationHelper.UpdateWorkflowTypeAttribute("FEB34437-9600-4330-855F-85404EC10018", "E4EAB7B2-0B76-429B-AFE4-AD86D7428C70", "FromPerson", "FromPerson", "", 0, @"", "4A9CBB79-860F-4F3C-A89A-BA9CD9EC219E"); // Text Review Contact Info:FromPerson
            RockMigrationHelper.UpdateWorkflowTypeAttribute("FEB34437-9600-4330-855F-85404EC10018", "9C204CD0-1233-41C5-818A-C5DA439445AA", "FromPersonAttendanceCode", "FromPersonAttendanceCode", "", 1, @"", "B4B42D68-D3B4-495F-B3E0-28D919F2D5E7"); // Text Review Contact Info:FromPersonAttendanceCode
            RockMigrationHelper.UpdateWorkflowTypeAttribute("FEB34437-9600-4330-855F-85404EC10018", "9C204CD0-1233-41C5-818A-C5DA439445AA", "FromPhone", "FromPhone", "", 2, @"", "9E987CFD-75B4-410A-AD17-91D8171DC02D"); // Text Review Contact Info:FromPhone
            RockMigrationHelper.UpdateWorkflowTypeAttribute("FEB34437-9600-4330-855F-85404EC10018", "9C204CD0-1233-41C5-818A-C5DA439445AA", "AttendanceKey", "AttendanceKey", "", 3, @"", "631360D6-4BF3-4C87-8B47-EFA06A2FF04F"); // Text Review Contact Info:AttendanceKey
            RockMigrationHelper.UpdateWorkflowTypeAttribute("FEB34437-9600-4330-855F-85404EC10018", "9C204CD0-1233-41C5-818A-C5DA439445AA", "AttendanceCode", "AttendanceCode", "", 4, @"", "8C2B603A-9944-4A9A-91C6-42305AE3E516"); // Text Review Contact Info:AttendanceCode
            RockMigrationHelper.UpdateWorkflowTypeAttribute("FEB34437-9600-4330-855F-85404EC10018", "9C204CD0-1233-41C5-818A-C5DA439445AA", "FromPersonFirstName", "FromPersonFirstName", "", 5, @"", "B75EFF3A-67D0-482D-8159-B79EF2DA2E72"); // Text Review Contact Info:FromPersonFirstName
            RockMigrationHelper.UpdateWorkflowTypeAttribute("FEB34437-9600-4330-855F-85404EC10018", "9C204CD0-1233-41C5-818A-C5DA439445AA", "FromPersonLastName", "FromPersonLastName", "", 6, @"", "239F006D-C6A0-4F68-B2D3-2B38DBCD0F2C"); // Text Review Contact Info:FromPersonLastName
            RockMigrationHelper.UpdateWorkflowTypeAttribute("FEB34437-9600-4330-855F-85404EC10018", "9C204CD0-1233-41C5-818A-C5DA439445AA", "FromPersonPhone", "FromPersonPhone", "", 7, @"", "714143DE-AC04-49AB-9C11-B86420AE3E43"); // Text Review Contact Info:FromPersonPhone
            RockMigrationHelper.UpdateWorkflowTypeAttribute("FEB34437-9600-4330-855F-85404EC10018", "9C204CD0-1233-41C5-818A-C5DA439445AA", "SMSResponse", "SMSResponse", "", 8, @"", "CA158792-F553-4F0F-81CA-D136068C6829"); // Text Review Contact Info:SMSResponse
            RockMigrationHelper.UpdateWorkflowTypeAttribute("FEB34437-9600-4330-855F-85404EC10018", "9C204CD0-1233-41C5-818A-C5DA439445AA", "FromPersonMobilePhone", "FromPersonMobilePhone", "", 9, @"", "50669FD5-A3B0-49BB-9D92-37650293D815"); // Text Review Contact Info:FromPersonMobilePhone
            RockMigrationHelper.AddAttributeQualifier("B4B42D68-D3B4-495F-B3E0-28D919F2D5E7", "ispassword", @"False", "C1124A92-3D77-4024-A74C-2E8747B3523B"); // Text Review Contact Info:FromPersonAttendanceCode:ispassword
            RockMigrationHelper.AddAttributeQualifier("9E987CFD-75B4-410A-AD17-91D8171DC02D", "ispassword", @"False", "472AF974-37C1-4060-866E-D75FBF253461"); // Text Review Contact Info:FromPhone:ispassword
            RockMigrationHelper.AddAttributeQualifier("631360D6-4BF3-4C87-8B47-EFA06A2FF04F", "ispassword", @"False", "49574949-9941-4AF8-9D0D-9D46649B8C68"); // Text Review Contact Info:AttendanceKey:ispassword
            RockMigrationHelper.AddAttributeQualifier("8C2B603A-9944-4A9A-91C6-42305AE3E516", "ispassword", @"False", "1646A51E-7B22-4A1C-8177-01AD6E5CD606"); // Text Review Contact Info:AttendanceCode:ispassword
            RockMigrationHelper.AddAttributeQualifier("B75EFF3A-67D0-482D-8159-B79EF2DA2E72", "ispassword", @"False", "1A50C82E-7D3F-46E1-ADD7-6A3204B013B9"); // Text Review Contact Info:FromPersonFirstName:ispassword
            RockMigrationHelper.AddAttributeQualifier("239F006D-C6A0-4F68-B2D3-2B38DBCD0F2C", "ispassword", @"False", "AA4812A1-19EA-413D-A7DC-B2494E4C6B4A"); // Text Review Contact Info:FromPersonLastName:ispassword
            RockMigrationHelper.AddAttributeQualifier("714143DE-AC04-49AB-9C11-B86420AE3E43", "ispassword", @"False", "70EB834F-A61F-4650-9C56-34E942312201"); // Text Review Contact Info:FromPersonPhone:ispassword
            RockMigrationHelper.AddAttributeQualifier("CA158792-F553-4F0F-81CA-D136068C6829", "ispassword", @"False", "7406F017-3CA1-44D0-9282-0FE1341845B2"); // Text Review Contact Info:SMSResponse:ispassword
            RockMigrationHelper.AddAttributeQualifier("50669FD5-A3B0-49BB-9D92-37650293D815", "ispassword", @"False", "9B76B9C6-FDB9-4FB4-ABE0-60DDC55D2D48"); // Text Review Contact Info:FromPersonMobilePhone:ispassword
            RockMigrationHelper.UpdateWorkflowActivityType("FEB34437-9600-4330-855F-85404EC10018", true, "Validate Attendance Code", "validates a correct attendance code", true, 0, "EBCEF596-0836-4675-B2C1-5385765F08BB"); // Text Review Contact Info:Validate Attendance Code
            RockMigrationHelper.UpdateWorkflowActivityType("FEB34437-9600-4330-855F-85404EC10018", true, "Send Contact Info", "", false, 1, "5CAA44D8-1AAE-493E-B27A-AED733184A75"); // Text Review Contact Info:Send Contact Info
            RockMigrationHelper.UpdateWorkflowActionType("EBCEF596-0836-4675-B2C1-5385765F08BB", "Activate Send Contact Info", 3, "38907A90-1634-4A93-8017-619326A4A582", true, false, "", "B4B42D68-D3B4-495F-B3E0-28D919F2D5E7", 64, "", "49DD5922-29EB-420E-9026-4B386CC778BC"); // Text Review Contact Info:Validate Attendance Code:Activate Send Contact Info
            RockMigrationHelper.UpdateWorkflowActionType("5CAA44D8-1AAE-493E-B27A-AED733184A75", "Send SMS Contact Info", 4, "C789E457-0783-44B3-9D8F-2EBAB5F11110", true, false, "", "", 1, "", "A125C5FC-583C-4EA1-812A-13C174515971"); // Text Review Contact Info:Send Contact Info:Send SMS Contact Info
            RockMigrationHelper.UpdateWorkflowActionType("EBCEF596-0836-4675-B2C1-5385765F08BB", "initiate person", 0, "4EEAC6FA-B838-410B-A8DD-21A364029F5D", true, false, "", "", 1, "", "6E41B690-EE5A-41D8-957C-A05AD4C84AEF"); // Text Review Contact Info:Validate Attendance Code:initiate person
            RockMigrationHelper.UpdateWorkflowActionType("5CAA44D8-1AAE-493E-B27A-AED733184A75", "Get Mobile Number", 2, "85D1DBFE-9F3F-486A-BF2C-60146A8D97F8", true, false, "", "", 1, "", "C489256B-35A2-400C-B94C-9EA0660D28D5"); // Text Review Contact Info:Send Contact Info:Get Mobile Number
            RockMigrationHelper.UpdateWorkflowActionType("5CAA44D8-1AAE-493E-B27A-AED733184A75", "Get FirstName", 0, "85D1DBFE-9F3F-486A-BF2C-60146A8D97F8", true, false, "", "", 1, "", "69D31EDE-4D41-4843-9F7E-0BF622254A89"); // Text Review Contact Info:Send Contact Info:Get FirstName
            RockMigrationHelper.UpdateWorkflowActionType("5CAA44D8-1AAE-493E-B27A-AED733184A75", "Get Last Name", 1, "85D1DBFE-9F3F-486A-BF2C-60146A8D97F8", true, false, "", "", 1, "", "70716106-16F0-4A61-A77A-0C449DBD0556"); // Text Review Contact Info:Send Contact Info:Get Last Name
            RockMigrationHelper.UpdateWorkflowActionType("5CAA44D8-1AAE-493E-B27A-AED733184A75", "Get Phone Number", 3, "85D1DBFE-9F3F-486A-BF2C-60146A8D97F8", true, false, "", "", 1, "", "2F5614AE-59C5-4802-BCAC-692D1C44DBA8"); // Text Review Contact Info:Send Contact Info:Get Phone Number
            RockMigrationHelper.UpdateWorkflowActionType("EBCEF596-0836-4675-B2C1-5385765F08BB", "get Attendance Code from Person", 1, "85D1DBFE-9F3F-486A-BF2C-60146A8D97F8", true, false, "", "", 1, "", "93A4E4A4-89DD-4079-985A-99ADC8061D53"); // Text Review Contact Info:Validate Attendance Code:get Attendance Code from Person
            RockMigrationHelper.UpdateWorkflowActionType("EBCEF596-0836-4675-B2C1-5385765F08BB", "Validate code", 2, "550458E4-BBBF-4E47-955E-1DBE79352E7D", true, false, "", "", 1, "", "8A6962A8-E5B1-4C9E-9AB1-0AE504D2B566"); // Text Review Contact Info:Validate Attendance Code:Validate code
            RockMigrationHelper.AddActionTypeAttributeValue("6E41B690-EE5A-41D8-957C-A05AD4C84AEF", "7A7B2369-901E-4838-852F-2AB42ABC9EBA", @"False"); // Text Review Contact Info:Validate Attendance Code:initiate person:Active
            RockMigrationHelper.AddActionTypeAttributeValue("6E41B690-EE5A-41D8-957C-A05AD4C84AEF", "047336EA-EA6F-46D7-9F32-FB67D2C9DA32", @"4a9cbb79-860f-4f3c-a89a-ba9cd9ec219e"); // Text Review Contact Info:Validate Attendance Code:initiate person:Person Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("6E41B690-EE5A-41D8-957C-A05AD4C84AEF", "8960D3B2-25B4-41BD-84D8-2C88779271F4", @""); // Text Review Contact Info:Validate Attendance Code:initiate person:Order
            RockMigrationHelper.AddActionTypeAttributeValue("93A4E4A4-89DD-4079-985A-99ADC8061D53", "CF19BB9A-EA5B-43E5-89A1-FA416F430761", @"4a9cbb79-860f-4f3c-a89a-ba9cd9ec219e"); // Text Review Contact Info:Validate Attendance Code:get Attendance Code from Person:PersonAttribute
            RockMigrationHelper.AddActionTypeAttributeValue("93A4E4A4-89DD-4079-985A-99ADC8061D53", "40FF47A2-9682-4545-BDF3-171B5F6B8A5C", @"b4b42d68-d3b4-495f-b3e0-28d919f2d5e7"); // Text Review Contact Info:Validate Attendance Code:get Attendance Code from Person:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("93A4E4A4-89DD-4079-985A-99ADC8061D53", "52930E88-A86E-47AE-BB1D-9937692BBF74", @"{{ Person.LastAttendanceCode }}"); // Text Review Contact Info:Validate Attendance Code:get Attendance Code from Person:Lava
            RockMigrationHelper.AddActionTypeAttributeValue("93A4E4A4-89DD-4079-985A-99ADC8061D53", "E7527DBD-32B1-47CE-8D22-142EDE32BD7D", @""); // Text Review Contact Info:Validate Attendance Code:get Attendance Code from Person:Order
            RockMigrationHelper.AddActionTypeAttributeValue("93A4E4A4-89DD-4079-985A-99ADC8061D53", "8DE0F372-4B1C-4612-B318-E598E4CC17F8", @"False"); // Text Review Contact Info:Validate Attendance Code:get Attendance Code from Person:Active
            RockMigrationHelper.AddActionTypeAttributeValue("8A6962A8-E5B1-4C9E-9AB1-0AE504D2B566", "C9FC261D-84BF-41F7-9636-734EAAF0FD86", @"False"); // Text Review Contact Info:Validate Attendance Code:Validate code:Active
            RockMigrationHelper.AddActionTypeAttributeValue("8A6962A8-E5B1-4C9E-9AB1-0AE504D2B566", "0FC7338D-F75D-401F-8F03-ADDA92315A3B", @"{{Workflow.FromPersonAttendanceCode}}"); // Text Review Contact Info:Validate Attendance Code:Validate code:UserInputCode
            RockMigrationHelper.AddActionTypeAttributeValue("8A6962A8-E5B1-4C9E-9AB1-0AE504D2B566", "18BA2FE7-7620-42CE-8FD8-727A26683B81", @""); // Text Review Contact Info:Validate Attendance Code:Validate code:Order
            RockMigrationHelper.AddActionTypeAttributeValue("49DD5922-29EB-420E-9026-4B386CC778BC", "E8ABD802-372C-47BE-82B1-96F50DB5169E", @"False"); // Text Review Contact Info:Validate Attendance Code:Activate Send Contact Info:Active
            RockMigrationHelper.AddActionTypeAttributeValue("49DD5922-29EB-420E-9026-4B386CC778BC", "3809A78C-B773-440C-8E3F-A8E81D0DAE08", @""); // Text Review Contact Info:Validate Attendance Code:Activate Send Contact Info:Order
            RockMigrationHelper.AddActionTypeAttributeValue("49DD5922-29EB-420E-9026-4B386CC778BC", "02D5A7A5-8781-46B4-B9FC-AF816829D240", @"5CAA44D8-1AAE-493E-B27A-AED733184A75"); // Text Review Contact Info:Validate Attendance Code:Activate Send Contact Info:Activity
            RockMigrationHelper.AddActionTypeAttributeValue("69D31EDE-4D41-4843-9F7E-0BF622254A89", "CF19BB9A-EA5B-43E5-89A1-FA416F430761", @"4a9cbb79-860f-4f3c-a89a-ba9cd9ec219e"); // Text Review Contact Info:Send Contact Info:Get FirstName:PersonAttribute
            RockMigrationHelper.AddActionTypeAttributeValue("69D31EDE-4D41-4843-9F7E-0BF622254A89", "40FF47A2-9682-4545-BDF3-171B5F6B8A5C", @"b75eff3a-67d0-482d-8159-b79ef2da2e72"); // Text Review Contact Info:Send Contact Info:Get FirstName:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("69D31EDE-4D41-4843-9F7E-0BF622254A89", "52930E88-A86E-47AE-BB1D-9937692BBF74", @"{{ Person.FirstName }}"); // Text Review Contact Info:Send Contact Info:Get FirstName:Lava
            RockMigrationHelper.AddActionTypeAttributeValue("69D31EDE-4D41-4843-9F7E-0BF622254A89", "E7527DBD-32B1-47CE-8D22-142EDE32BD7D", @""); // Text Review Contact Info:Send Contact Info:Get FirstName:Order
            RockMigrationHelper.AddActionTypeAttributeValue("69D31EDE-4D41-4843-9F7E-0BF622254A89", "8DE0F372-4B1C-4612-B318-E598E4CC17F8", @"False"); // Text Review Contact Info:Send Contact Info:Get FirstName:Active
            RockMigrationHelper.AddActionTypeAttributeValue("70716106-16F0-4A61-A77A-0C449DBD0556", "CF19BB9A-EA5B-43E5-89A1-FA416F430761", @"4a9cbb79-860f-4f3c-a89a-ba9cd9ec219e"); // Text Review Contact Info:Send Contact Info:Get Last Name:PersonAttribute
            RockMigrationHelper.AddActionTypeAttributeValue("70716106-16F0-4A61-A77A-0C449DBD0556", "40FF47A2-9682-4545-BDF3-171B5F6B8A5C", @"239f006d-c6a0-4f68-b2d3-2b38dbcd0f2c"); // Text Review Contact Info:Send Contact Info:Get Last Name:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("70716106-16F0-4A61-A77A-0C449DBD0556", "52930E88-A86E-47AE-BB1D-9937692BBF74", @"{{ Person.LastName }}"); // Text Review Contact Info:Send Contact Info:Get Last Name:Lava
            RockMigrationHelper.AddActionTypeAttributeValue("70716106-16F0-4A61-A77A-0C449DBD0556", "E7527DBD-32B1-47CE-8D22-142EDE32BD7D", @""); // Text Review Contact Info:Send Contact Info:Get Last Name:Order
            RockMigrationHelper.AddActionTypeAttributeValue("70716106-16F0-4A61-A77A-0C449DBD0556", "8DE0F372-4B1C-4612-B318-E598E4CC17F8", @"False"); // Text Review Contact Info:Send Contact Info:Get Last Name:Active
            RockMigrationHelper.AddActionTypeAttributeValue("C489256B-35A2-400C-B94C-9EA0660D28D5", "CF19BB9A-EA5B-43E5-89A1-FA416F430761", @"4a9cbb79-860f-4f3c-a89a-ba9cd9ec219e"); // Text Review Contact Info:Send Contact Info:Get Mobile Number:PersonAttribute
            RockMigrationHelper.AddActionTypeAttributeValue("C489256B-35A2-400C-B94C-9EA0660D28D5", "40FF47A2-9682-4545-BDF3-171B5F6B8A5C", @"50669fd5-a3b0-49bb-9d92-37650293d815"); // Text Review Contact Info:Send Contact Info:Get Mobile Number:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("C489256B-35A2-400C-B94C-9EA0660D28D5", "52930E88-A86E-47AE-BB1D-9937692BBF74", @"{{ Person | PhoneNumber:'Mobile' }}"); // Text Review Contact Info:Send Contact Info:Get Mobile Number:Lava
            RockMigrationHelper.AddActionTypeAttributeValue("C489256B-35A2-400C-B94C-9EA0660D28D5", "E7527DBD-32B1-47CE-8D22-142EDE32BD7D", @""); // Text Review Contact Info:Send Contact Info:Get Mobile Number:Order
            RockMigrationHelper.AddActionTypeAttributeValue("C489256B-35A2-400C-B94C-9EA0660D28D5", "8DE0F372-4B1C-4612-B318-E598E4CC17F8", @"False"); // Text Review Contact Info:Send Contact Info:Get Mobile Number:Active
            RockMigrationHelper.AddActionTypeAttributeValue("2F5614AE-59C5-4802-BCAC-692D1C44DBA8", "CF19BB9A-EA5B-43E5-89A1-FA416F430761", @"4a9cbb79-860f-4f3c-a89a-ba9cd9ec219e"); // Text Review Contact Info:Send Contact Info:Get Phone Number:PersonAttribute
            RockMigrationHelper.AddActionTypeAttributeValue("2F5614AE-59C5-4802-BCAC-692D1C44DBA8", "40FF47A2-9682-4545-BDF3-171B5F6B8A5C", @"714143de-ac04-49ab-9c11-b86420ae3e43"); // Text Review Contact Info:Send Contact Info:Get Phone Number:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("2F5614AE-59C5-4802-BCAC-692D1C44DBA8", "52930E88-A86E-47AE-BB1D-9937692BBF74", @"{{ Person | PhoneNumber:'Home' }}"); // Text Review Contact Info:Send Contact Info:Get Phone Number:Lava
            RockMigrationHelper.AddActionTypeAttributeValue("2F5614AE-59C5-4802-BCAC-692D1C44DBA8", "E7527DBD-32B1-47CE-8D22-142EDE32BD7D", @""); // Text Review Contact Info:Send Contact Info:Get Phone Number:Order
            RockMigrationHelper.AddActionTypeAttributeValue("2F5614AE-59C5-4802-BCAC-692D1C44DBA8", "8DE0F372-4B1C-4612-B318-E598E4CC17F8", @"False"); // Text Review Contact Info:Send Contact Info:Get Phone Number:Active
            RockMigrationHelper.AddActionTypeAttributeValue("A125C5FC-583C-4EA1-812A-13C174515971", "D7EAA859-F500-4521-9523-488B12EAA7D2", @"False"); // Text Review Contact Info:Send Contact Info:Send SMS Contact Info:Active
            RockMigrationHelper.AddActionTypeAttributeValue("A125C5FC-583C-4EA1-812A-13C174515971", "44A0B977-4730-4519-8FF6-B0A01A95B212", @"ca158792-f553-4f0f-81ca-d136068c6829"); // Text Review Contact Info:Send Contact Info:Send SMS Contact Info:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("A125C5FC-583C-4EA1-812A-13C174515971", "57093B41-50ED-48E5-B72B-8829E62704C8", @""); // Text Review Contact Info:Send Contact Info:Send SMS Contact Info:Order
            RockMigrationHelper.AddActionTypeAttributeValue("A125C5FC-583C-4EA1-812A-13C174515971", "E5272B11-A2B8-49DC-860D-8D574E2BC15C", @"Contact info on file: First name - {{Workflow.FromPersonFirstName }}, Last name - {{Workflow.FromPersonLastName}}, Home Phone - {{Workflow.FromPersonPhone}}, Mobile Phone - {{Workflow.FromPersonMobilePhone}}. If the info is incorrect, please reply with 5 and fill out a connection card."); // Text Review Contact Info:Send Contact Info:Send SMS Contact Info:Text Value|Attribute Value

        }
    }
}