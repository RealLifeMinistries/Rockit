using Rock.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.reallifeministries.RockExtensions.Migrations.TextInAttendance
{
    [MigrationNumber(15, "1.2.0")]
    class _013_GeneratedAttendanceCodePage : Migration
    {
        public override void Down()
        {
            RockMigrationHelper.DeleteAttribute("48FF43A9-8E12-4768-80A9-88FBB81F11D8");
            RockMigrationHelper.DeleteAttribute("6783D47D-92F9-4F48-93C0-16111D675A0F");
            RockMigrationHelper.DeleteAttribute("3BDB8AED-32C5-4879-B1CB-8FC7C8336534");
            RockMigrationHelper.DeleteAttribute("9D3E4ED9-1BEF-4547-B6B0-CE29FE3835EE");
            RockMigrationHelper.DeleteAttribute("26F3AFC6-C05B-44A4-8593-AFE1D9969B0E");
            RockMigrationHelper.DeleteAttribute("0673E015-F8DD-4A52-B380-C758011331B2");
            RockMigrationHelper.DeleteAttribute("466993F7-D838-447A-97E7-8BBDA6A57289");
            RockMigrationHelper.DeleteAttribute("3FFC512D-A576-4289-B648-905FD7A64ABB");
            RockMigrationHelper.DeleteAttribute("7C1CE199-86CF-4EAE-8AB3-848416A72C58");
            RockMigrationHelper.DeleteAttribute("EC2B701B-4C1D-4F3F-9C77-A73C75D7FF7A");
            RockMigrationHelper.DeleteAttribute("4DFDB295-6D0F-40A1-BEF9-7B70C56F66C4");
            RockMigrationHelper.DeleteBlock("1ADA0AB6-2704-43DE-8AE7-C1A1570BF22D");
            RockMigrationHelper.DeleteBlockType("19B61D65-37E3-459F-A44F-DEF0089118A3");
            RockMigrationHelper.DeletePage("D57B8803-C873-417A-836E-CB1DE5D02792"); //  Page: Generated Attendance Codes
        }

        public override void Up()
        {
            // Page: Generated Attendance Codes
            RockMigrationHelper.AddPage("F1CEBF21-B09F-4740-ACA8-19F029D495F0", "D65F783D-87A9-4CC9-8110-E83466A0EADB", "Generated Attendance Codes", "", "D57B8803-C873-417A-836E-CB1DE5D02792", ""); // Site:Rock RMS
            RockMigrationHelper.AddPageRoute("D57B8803-C873-417A-836E-CB1DE5D02792", "Tools/GeneratedAttendanceCodes");
            RockMigrationHelper.UpdateBlockType("HTML Content", "Adds an editable HTML fragment to the page.", "~/Blocks/Cms/HtmlContentDetail.ascx", "CMS", "19B61D65-37E3-459F-A44F-DEF0089118A3");
            RockMigrationHelper.AddBlock("D57B8803-C873-417A-836E-CB1DE5D02792", "", "19B61D65-37E3-459F-A44F-DEF0089118A3", "Attendance Codes", "Feature", "", "", 0, "1ADA0AB6-2704-43DE-8AE7-C1A1570BF22D");
            RockMigrationHelper.AddBlockTypeAttribute("19B61D65-37E3-459F-A44F-DEF0089118A3", "3549BAB6-FE1B-4333-AFC4-C5ACA01BB8EB", "Entity Type", "ContextEntityType", "", "The type of entity that will provide context for this block", 0, @"", "6783D47D-92F9-4F48-93C0-16111D675A0F");
            RockMigrationHelper.AddBlockTypeAttribute("19B61D65-37E3-459F-A44F-DEF0089118A3", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Use Code Editor", "UseCodeEditor", "", "Use the code editor instead of the WYSIWYG editor", 0, @"True", "0673E015-F8DD-4A52-B380-C758011331B2");
            RockMigrationHelper.AddBlockTypeAttribute("19B61D65-37E3-459F-A44F-DEF0089118A3", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Document Root Folder", "DocumentRootFolder", "", "The folder to use as the root when browsing or uploading documents.", 1, @"~/Content", "3BDB8AED-32C5-4879-B1CB-8FC7C8336534");
            RockMigrationHelper.AddBlockTypeAttribute("19B61D65-37E3-459F-A44F-DEF0089118A3", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Image Root Folder", "ImageRootFolder", "", "The folder to use as the root when browsing or uploading images.", 2, @"~/Content", "26F3AFC6-C05B-44A4-8593-AFE1D9969B0E");
            RockMigrationHelper.AddBlockTypeAttribute("19B61D65-37E3-459F-A44F-DEF0089118A3", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "User Specific Folders", "UserSpecificFolders", "", "Should the root folders be specific to current user?", 3, @"False", "9D3E4ED9-1BEF-4547-B6B0-CE29FE3835EE");
            RockMigrationHelper.AddBlockTypeAttribute("19B61D65-37E3-459F-A44F-DEF0089118A3", "A75DFC58-7A1B-4799-BF31-451B2BBE38FF", "Cache Duration", "CacheDuration", "", "Number of seconds to cache the content.", 4, @"3600", "4DFDB295-6D0F-40A1-BEF9-7B70C56F66C4");
            RockMigrationHelper.AddBlockTypeAttribute("19B61D65-37E3-459F-A44F-DEF0089118A3", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Context Parameter", "ContextParameter", "", "Query string parameter to use for 'personalizing' content based on unique values.", 5, @"", "3FFC512D-A576-4289-B648-905FD7A64ABB");
            RockMigrationHelper.AddBlockTypeAttribute("19B61D65-37E3-459F-A44F-DEF0089118A3", "9C204CD0-1233-41C5-818A-C5DA439445AA", "Context Name", "ContextName", "", "Name to use to further 'personalize' content.  Blocks with the same name, and referenced with the same context parameter will share html values.", 6, @"", "466993F7-D838-447A-97E7-8BBDA6A57289");
            RockMigrationHelper.AddBlockTypeAttribute("19B61D65-37E3-459F-A44F-DEF0089118A3", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Enable Versioning", "SupportVersions", "", "If checked, previous versions of the content will be preserved. Versioning is required if you want to require approval.", 7, @"False", "7C1CE199-86CF-4EAE-8AB3-848416A72C58");
            RockMigrationHelper.AddBlockTypeAttribute("19B61D65-37E3-459F-A44F-DEF0089118A3", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Require Approval", "RequireApproval", "", "Require that content be approved?", 8, @"False", "EC2B701B-4C1D-4F3F-9C77-A73C75D7FF7A");
            RockMigrationHelper.AddBlockTypeAttribute("19B61D65-37E3-459F-A44F-DEF0089118A3", "1EDAFDED-DFE6-4334-B019-6EECBA89E05A", "Enable Debug", "EnableDebug", "", "Show lava merge fields.", 9, @"False", "48FF43A9-8E12-4768-80A9-88FBB81F11D8");

            Sql(string.Format(@"IF EXISTS ( SELECT [Id] FROM [ServiceJob] WHERE [Name] = '{1}' )
                BEGIN
                    UPDATE [ServiceJob] SET
                        [IsActive] = {0},
                        [Name] = {1},
                        [Description] = '{2}',
                        [Class] = '{3},
                        [CronExpression] = {4}
                    WHERE [Name] = '{1}'
                END
                ELSE
                BEGIN
                    INSERT INTO [EntityType] ([IsActive], [Name], [Description]',[Class], [CronExpression], [Guid])
                    VALUES ('{0}', {1}, {2}, {3}, '{4}, {5}')
                END",
                "1",
                "Generate PF Attendance Code",
                "Generates the weekly attendance codes for the text in system",
                "Rock.Jobs.LaunchWorkflow",
                "0 0 1 ? * MON *",
                "3D4FA784-AAF8-4380-8027-532B6FD3DD6F"
                ));
            Sql(string.Format(@"IF EXISTS ( SELECT [Id] FROM [ServiceJob] WHERE [Name] = '{1}' )
                BEGIN
                    UPDATE [ServiceJob] SET
                        [IsActive] = {0},
                        [Name] = {1},
                        [Description] = '{2}',
                        [Class] = '{3},
                        [CronExpression] = {4}
                    WHERE [Name] = '{1}'
                END
                ELSE
                BEGIN
                    INSERT INTO [EntityType] ([IsActive], [Name], [Description]',[Class], [CronExpression], [Guid])
                    VALUES ('{0}', {1}, {2}, {3}, '{4}, {5}')
                END",
                "1",
                "Generate CDAAttendance Code",
                "Generates the weekly attendance codes for the text in system",
                "Rock.Jobs.LaunchWorkflow",
                "0 0 1 ? * MON *",
                "65EAB610-022D-40C6-9D92-A9EF9A2B3092"
                ));
            Sql(string.Format(@"IF EXISTS ( SELECT [Id] FROM [ServiceJob] WHERE [Name] = '{1}' )
                BEGIN
                    UPDATE [ServiceJob] SET
                        [IsActive] = {0},
                        [Name] = {1},
                        [Description] = '{2}',
                        [Class] = '{3},
                        [CronExpression] = {4}
                    WHERE [Name] = '{1}'
                END
                ELSE
                BEGIN
                    INSERT INTO [EntityType] ([IsActive], [Name], [Description]',[Class], [CronExpression], [Guid])
                    VALUES ('{0}', {1}, {2}, {3}, '{4}, {5}')
                END",
                "1",
                "Generate THIRST Attendance Code",
                "Generates the weekly attendance codes for the text in system",
                "Rock.Jobs.LaunchWorkflow",
                "0 0 1 ? * MON *",
                "C5DFFF0C-ECAC-4D77-8462-9D72EE320CA8"
                ));
            Sql(string.Format(@"IF EXISTS ( SELECT [Id] FROM [ServiceJob] WHERE [Name] = '{1}' )
                BEGIN
                    UPDATE [ServiceJob] SET
                        [IsActive] = {0},
                        [Name] = {1},
                        [Description] = '{2}',
                        [Class] = '{3},
                        [CronExpression] = {4}
                    WHERE [Name] = '{1}'
                END
                ELSE
                BEGIN
                    INSERT INTO [EntityType] ([IsActive], [Name], [Description]',[Class], [CronExpression], [Guid])
                    VALUES ('{0}', {1}, {2}, {3}, '{4}, {5}')
                END",
                "1",
                "Generate RECOVERY Attendance Code",
                "Generates the weekly attendance codes for the text in system",
                "Rock.Jobs.LaunchWorkflow",
                "0 0 1 ? * MON *",
                "47F260D0-0CDD-458B-BD63-31CE56B63DA6"
                ));
            //Name	Description	Guid
            //Generate THIRST Attendance Code Generates the weekly attendance codes for the text in system    C5DFFF0C - ECAC - 4D77 - 8462 - 9D72EE320CA8
            // Generate RECOVERY Attendance Code   Generates the weekly attendance codes for the text in system    47F260D0 - 0CDD - 458B - BD63 - 31CE56B63DA6
        }
    }
}
