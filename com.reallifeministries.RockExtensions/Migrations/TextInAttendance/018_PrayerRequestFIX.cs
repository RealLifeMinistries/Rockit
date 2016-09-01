using Rock.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.reallifeministries.RockExtensions.Migrations
{
    [MigrationNumber(20, "1.2.0")]
    class _018_PrayerRequestFIX : Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {            
            RockMigrationHelper.UpdateWorkflowTypeAttribute("88978527-0CA4-4C52-8FDA-CF915FAFA472", "309460EF-0CC5-41C6-9161-B3837BA3D374", "PF Prayer Category", "PFPrayerCategory", "", 7, @"17c3406f-788b-4932-810c-ab2ecc484506", "65FCFB06-FF75-45B5-A9D7-D62B68E78C79"); // Text Prayer Request:PF Prayer Category
            RockMigrationHelper.UpdateWorkflowTypeAttribute("88978527-0CA4-4C52-8FDA-CF915FAFA472", "309460EF-0CC5-41C6-9161-B3837BA3D374", "CDA Prayer Category", "CDAPrayerCategory", "", 8, @"41d4ef74-af83-49ec-a98a-5fc14b9fa908", "3109787B-B7FE-4BAC-86FB-DC8523348253"); // Text Prayer Request:CDA Prayer Category
            RockMigrationHelper.UpdateWorkflowTypeAttribute("88978527-0CA4-4C52-8FDA-CF915FAFA472", "309460EF-0CC5-41C6-9161-B3837BA3D374", "Prayer Category", "PrayerCategory", "", 9, @"", "07976A20-5EBF-4211-9C9F-E6AE732A3098"); // Text Prayer Request:Prayer Category            
            RockMigrationHelper.AddAttributeQualifier("65FCFB06-FF75-45B5-A9D7-D62B68E78C79", "qualifierColumn", @"", "3A523554-2FED-4219-A9F7-457029E9DAD0"); // Text Prayer Request:PF Prayer Category:qualifierColumn
            RockMigrationHelper.AddAttributeQualifier("65FCFB06-FF75-45B5-A9D7-D62B68E78C79", "qualifierValue", @"", "6AA1E31F-E643-4819-918E-D7509160B0BB"); // Text Prayer Request:PF Prayer Category:qualifierValue
            RockMigrationHelper.AddAttributeQualifier("3109787B-B7FE-4BAC-86FB-DC8523348253", "entityTypeName", @"Rock.Model.PrayerRequest", "F3CED749-5825-40D5-A6B9-876192B2628E"); // Text Prayer Request:CDA Prayer Category:entityTypeName
            RockMigrationHelper.AddAttributeQualifier("3109787B-B7FE-4BAC-86FB-DC8523348253", "qualifierColumn", @"", "D209D7C2-A941-4A16-8702-0DCBAD93C447"); // Text Prayer Request:CDA Prayer Category:qualifierColumn
            RockMigrationHelper.AddAttributeQualifier("3109787B-B7FE-4BAC-86FB-DC8523348253", "qualifierValue", @"", "4F0ECD00-6D66-4126-A7C0-C938BC642AE9"); // Text Prayer Request:CDA Prayer Category:qualifierValue
            RockMigrationHelper.AddAttributeQualifier("07976A20-5EBF-4211-9C9F-E6AE732A3098", "entityTypeName", @"Rock.Model.PrayerRequest", "7596AF7B-7E85-48AC-8B22-9AFCA58667DA"); // Text Prayer Request:Prayer Category:entityTypeName
            RockMigrationHelper.AddAttributeQualifier("07976A20-5EBF-4211-9C9F-E6AE732A3098", "qualifierColumn", @"", "C2C7BD60-F140-4BDD-9ECA-29E4959805B3"); // Text Prayer Request:Prayer Category:qualifierColumn
            RockMigrationHelper.AddAttributeQualifier("07976A20-5EBF-4211-9C9F-E6AE732A3098", "qualifierValue", @"", "74BAE1EC-ABC7-4372-8DC0-0D3749AE13EB"); // Text Prayer Request:Prayer Category:qualifierValue            
            RockMigrationHelper.AddActionTypeAttributeValue("8520DE5F-F4F2-41B7-9DAF-8B13FDF03032", "D7EAA859-F500-4521-9523-488B12EAA7D2", @"False"); // Text Prayer Request:Submit Prayer Request:Set Prayer Category if PF:Active
            RockMigrationHelper.AddActionTypeAttributeValue("8520DE5F-F4F2-41B7-9DAF-8B13FDF03032", "44A0B977-4730-4519-8FF6-B0A01A95B212", @"07976a20-5ebf-4211-9c9f-e6ae732a3098"); // Text Prayer Request:Submit Prayer Request:Set Prayer Category if PF:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("8520DE5F-F4F2-41B7-9DAF-8B13FDF03032", "57093B41-50ED-48E5-B72B-8829E62704C8", @""); // Text Prayer Request:Submit Prayer Request:Set Prayer Category if PF:Order
            RockMigrationHelper.AddActionTypeAttributeValue("8520DE5F-F4F2-41B7-9DAF-8B13FDF03032", "E5272B11-A2B8-49DC-860D-8D574E2BC15C", @"65fcfb06-ff75-45b5-a9d7-d62b68e78c79"); // Text Prayer Request:Submit Prayer Request:Set Prayer Category if PF:Text Value|Attribute Value
            RockMigrationHelper.AddActionTypeAttributeValue("E43F12B1-DB12-476C-8337-B20EA7267874", "D7EAA859-F500-4521-9523-488B12EAA7D2", @"False"); // Text Prayer Request:Submit Prayer Request:Set Prayer Category If CDA:Active
            RockMigrationHelper.AddActionTypeAttributeValue("E43F12B1-DB12-476C-8337-B20EA7267874", "44A0B977-4730-4519-8FF6-B0A01A95B212", @"07976a20-5ebf-4211-9c9f-e6ae732a3098"); // Text Prayer Request:Submit Prayer Request:Set Prayer Category If CDA:Attribute
            RockMigrationHelper.AddActionTypeAttributeValue("E43F12B1-DB12-476C-8337-B20EA7267874", "57093B41-50ED-48E5-B72B-8829E62704C8", @""); // Text Prayer Request:Submit Prayer Request:Set Prayer Category If CDA:Order
            RockMigrationHelper.AddActionTypeAttributeValue("E43F12B1-DB12-476C-8337-B20EA7267874", "E5272B11-A2B8-49DC-860D-8D574E2BC15C", @"3109787b-b7fe-4bac-86fb-dc8523348253"); // Text Prayer Request:Submit Prayer Request:Set Prayer Category If CDA:Text Value|Attribute Value            
        }
    }
}
