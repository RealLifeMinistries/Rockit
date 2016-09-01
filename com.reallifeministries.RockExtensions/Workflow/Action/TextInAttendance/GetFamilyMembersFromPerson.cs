using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.Composition;

using Rock;
using Rock.Attribute;
using Rock.Data;
using Rock.Model;
using Rock.Workflow;
using Rock.Web.Cache;

namespace com.reallifeministries.RockExtensions.Workflow.Action
{
    /// <summary>
    /// Activates a new activity for a given activity type
    /// </summary>
    [Description("Get's a list of family members and optionally checks them into an AttendanceService as a string for a given person object")]
    [Export(typeof(ActionComponent))]
    [ExportMetadata("ComponentName", "Get Family From Person")]

    [WorkflowAttribute("PersonAttribute", "The workflow attribute containing the person.", true, "", "", 0, null,
        new string[] { "Rock.Field.Types.PersonFieldType" })]
    [WorkflowAttribute("Group", "The Group to Check each family member into", false, "", "", 0, null,
        new string[] { "Rock.Field.Types.GroupFieldType" })]
    [WorkflowAttribute("Campus", "The Campus location to Check each family member into", false, "", "", 0, null,
        new string[] { "Rock.Field.Types.CampusFieldType" })]
    public class GetFamilyFromPerson : ActionComponent
    {

        public override bool Execute(RockContext rockContext, WorkflowAction action, object entity, out List<string> errorMessages)
        {
            Guid? groupGuid = null;
            Guid? campusGuid = null;
            Group group = null;
            Campus campus = null;
            errorMessages = new List<string>();
            var personAttribute = GetAttributeValue(action, "PersonAttribute");
            Guid personAttrGuid = personAttribute.AsGuid();
            // get the group attribute
            Guid groupAttributeGuid = GetAttributeValue(action, "Group").AsGuid();
            if (!groupAttributeGuid.IsEmpty())
            {
                groupGuid = action.GetWorklowAttributeValue(groupAttributeGuid).AsGuidOrNull();

                if (!groupGuid.HasValue)
                {
                    action.AddLogEntry("The group could not be found!");
                }
                else
                {
                    group = new GroupService(rockContext).Queryable("GroupType.DefaultGroupRole")
                                        .Where(g => g.Guid == groupGuid)
                                        .FirstOrDefault();
                }
            }
            Guid campusAttributeGuid = GetAttributeValue(action, "Campus").AsGuid();
            if (!campusAttributeGuid.IsEmpty())
            {
                campusGuid = action.GetWorklowAttributeValue(campusAttributeGuid).AsGuidOrNull();

                if (!campusGuid.HasValue)
                {
                    action.AddLogEntry("The campus could not be found!");
                }
                else
                {
                    campus = new CampusService(rockContext).Queryable()
                                        .Where(g => g.Guid == campusGuid)
                                        .FirstOrDefault();
                }
            }

            if (!personAttrGuid.IsEmpty())
            {
                var personAttributeInst = AttributeCache.Read(personAttrGuid, rockContext);
                if (personAttributeInst != null)
                {
                    string attributePersonValue = action.GetWorklowAttributeValue(personAttrGuid);
                    Guid personAliasGuid = attributePersonValue.AsGuid();

                    if (personAliasGuid != null)
                    {
                        var personAlias = (new PersonAliasService(rockContext)).Get(personAliasGuid);
                        if (personAlias != null)
                        {
                            var familyMembers = personAlias.Person.GetFamilyMembers();
                            var familyNames = familyMembers.Select(f => f.Person.FirstName);
                            action.Activity.Workflow.SetAttributeValue("FamilyNames", String.Join(", ", familyNames));
                            if (group != null && campus != null)
                            {
                                checkInFamily(familyMembers, group, campus, rockContext);
                            }
                            else
                            {
                                errorMessages.Add(string.Format("Campus or Group could not be found"));
                            }
                        }
                        else
                        {
                            errorMessages.Add(string.Format("PersonAlias cannot be found: {0}", personAliasGuid));
                        }
                    }

                }
                else
                {
                    errorMessages.Add(string.Format("Person attribute could not be found for '{0}'!", personAttrGuid.ToString()));
                }
            }
            else
            {
                errorMessages.Add(string.Format("Selected person attribute ('{0}') was not a valid Guid!", personAttribute));
            }

            return true;
        }
        private void checkInFamily(IQueryable<GroupMember> family, Group attendanceGroup, Campus campus, RockContext rockContext)
        {
            AttendanceService attendanceService = new AttendanceService(rockContext);
            foreach (var member in family)
            {
                Attendance attendance = new Attendance();
                attendance.GroupId = attendanceGroup.Id;
                attendance.PersonAliasId = member.Person.PrimaryAliasId;
                attendance.StartDateTime = RockDateTime.Now;
                attendance.DidAttend = true;
                attendance.Campus = campus;

                attendanceService.Add(attendance);
            }
            rockContext.SaveChanges();
        }
    }
}
