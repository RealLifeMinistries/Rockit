using Rock.Data;
using Rock.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.reallifeministries.RockExtensions.Migrations
{
    [MigrationNumber(18, "1.2.0")]
    class _016_PersonAttributeLastAttendanceCode: Migration
    {
        public override void Down()
        {            
            
        }                                                                                                   

        public override void Up()
        {
            string attrGuid = Guid.NewGuid().ToString();
            RockMigrationHelper.AddEntityAttribute("Rock.Model.Person", "9C204CD0-1233-41C5-818A-C5DA439445AA", null, null, "LastAttendanceCode", null, "Displays the last text-in attendance code and the date they checked in.", 0, string.Empty, attrGuid);
        }
    }
}
