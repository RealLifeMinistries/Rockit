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
using System.Globalization;

namespace com.reallifeministries.RockExtensions.Workflow.Action
{
    /// <summary>
    /// Activates a new activity for a given activity type
    /// </summary>
    [Description( "Validates attendance code to determine if it matches the system generated one" )]
    [Export( typeof( ActionComponent ) )]
    [ExportMetadata( "ComponentName", "Validate attendance Code" )]
        
    [TextField("UserInputCode", "The code submitted by the user", true)]
    public class ValidateAttendanceCode : ActionComponent
    {
        /// <summary>
        /// Executes the specified workflow.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="action">The action.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="errorMessages">The error messages.</param>
        /// <returns></returns>
        public override bool Execute( RockContext rockContext, WorkflowAction action, Object entity, out List<string> errorMessages )
        {
            errorMessages = new List<string>();
            var globalAttributes = Rock.Web.Cache.GlobalAttributesCache.Read();            
            var AttendanceCodes = new Dictionary<RLMServiceTypes, String>();
            
            AttendanceCodes.Add(RLMServiceTypes.PF, globalAttributes.GetValue("PFAttendanceCode"));
            AttendanceCodes.Add(RLMServiceTypes.CDA, globalAttributes.GetValue("CDAAttendanceCode"));
            AttendanceCodes.Add(RLMServiceTypes.THIRST, globalAttributes.GetValue("THIRSTAttendanceCode"));
            AttendanceCodes.Add(RLMServiceTypes.RECOVERY, globalAttributes.GetValue("RECOVERYAttendanceCode"));

            var userInputtedCode = GetAttributeValue(action, "UserInputCode").ResolveMergeFields(GetMergeFields(action));            
            var parsedSplit = userInputtedCode.Split('|');
            string attendanceDateString = null;
            string attendancecode = null;
            DateTime attendanceDate = new DateTime();
            bool dateValidated = false;
            if (parsedSplit.Length > 1)
            {
                attendancecode = parsedSplit[0];
                attendanceDateString = parsedSplit[1];    
                // check to see if the date is within 4 hours of right now
                if (!String.IsNullOrEmpty(attendanceDateString))
                {
                    if (DateTime.TryParse(attendanceDateString,  out attendanceDate))
                    {
                        if (RockDateTime.Now <= attendanceDate.AddHours(4))
                        {
                            dateValidated = true;
                        }
                        else
                        {
                            errorMessages.Add(string.Format("Attendance Code has expired, please enter the attendance code again"));
                        }
                    }
                }
            }
            else
            {
                attendancecode = parsedSplit[0];
            }
            attendancecode = RemoveWhitespace(attendancecode.ToLower());
            // check to see if the generatedcode matches
            if (!string.IsNullOrEmpty(attendancecode) || (attendanceDateString != null && !dateValidated)) {
                var match = AttendanceCodes.Where(v => attendancecode.Contains(v.Value)).FirstOrDefault();
                if (match.Value != null)
                {                    
                    action.Activity.Workflow.SetAttributeValue("AttendanceKey", match.Key.ToString());
                    action.Activity.Workflow.SetAttributeValue("AttendanceCode", match.Value);                    
                }
            }
            else
            {
                action.Activity.Workflow.SetAttributeValue("AttendanceKey", String.Empty);
                action.Activity.Workflow.SetAttributeValue("AttendanceCode", String.Empty);
            }
            return true;            
        }
        public string RemoveWhitespace(string input)
        {            
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
