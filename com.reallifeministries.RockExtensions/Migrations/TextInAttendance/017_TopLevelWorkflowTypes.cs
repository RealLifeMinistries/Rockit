using Rock.Data;
using Rock.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.reallifeministries.RockExtensions.Migrations
{
    [MigrationNumber(19, "1.2.0")]
    class _017_TopLevelWorkflowTypes: Migration
    {
        public override void Down()
        {            
            
        }                                                                                                   

        public override void Up()
        {
            string catSMSGuid = Guid.NewGuid().ToString();
            RockMigrationHelper.UpdateCategory("C9F3C4A5-1526-474D-803F-D6C7A45CBBAE", "SMS Workflows", "fa fa-gear", string.Empty, catSMSGuid);

            string catAttGuid = Guid.NewGuid().ToString();
            RockMigrationHelper.UpdateCategory("C9F3C4A5-1526-474D-803F-D6C7A45CBBAE", "Attendance Generation", "fa fa-group", string.Empty, catAttGuid);
        }
    }
}
