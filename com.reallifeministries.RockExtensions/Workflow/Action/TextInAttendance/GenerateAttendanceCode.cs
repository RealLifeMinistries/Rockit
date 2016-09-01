using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.Composition;

using Rock;
using Rock.Attribute;
using Rock.Data;
using Rock.Model;
using Rock.Web.Cache;
using Rock.Workflow;

namespace com.reallifeministries.RockExtensions.Workflow.Action
{
    /// <summary>
    /// Generates a new attendance code for a given type
    /// </summary>
    [Description( "Generates a new attendance code for a given type" )]
    [Export( typeof( ActionComponent ) )]
    [ExportMetadata( "ComponentName", "Activate Workflow" )]
        
    [TextField("ServiceName", "Service to generate the code for",true)]
    [TextField("GeneratedCode", "Code that is generated from this action", true)]
    public class GenerateAttendanceCode : ActionComponent
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
                        
            var serviceName = GetAttributeValue(action, "ServiceName").ResolveMergeFields(GetMergeFields(action));                                

            if (String.IsNullOrEmpty(serviceName))
            {
                action.AddLogEntry("Invalid ServiceName Property", true);
                return false;
            }
            RLMServiceTypes attendanceCode;
            if (Enum.TryParse<RLMServiceTypes>(serviceName.ToUpper(), out attendanceCode))
            {
                var generatedCode = GenerateCode(attendanceCode);
                if (generatedCode == null)
                {
                    action.AddLogEntry(String.Format("GenerateCode returned null, please check your serviceName is one of the following: {0}",String.Join(",", Enum.GetValues(typeof(RLMServiceTypes)))), true);
                    return false;
                }
                globalAttributes.SetValue(String.Format("{0}AttendanceCode", serviceName.ToUpper()), generatedCode, true);
                action.Activity.Workflow.SetAttributeValue("GeneratedCode", generatedCode);
            }
            else
            {
                action.AddLogEntry("attendance Code invalid, please check your serviceName", true);
                return false;
            }            
            return true;
        }

        private string GenerateCode(RLMServiceTypes attendanceCode)
        {
            // validate this service matches
            var prefix = "";
            switch (attendanceCode)
            {
                case RLMServiceTypes.PF :
                case RLMServiceTypes.CDA:
                    {
                        prefix = "lifer";
                    }
                    break;
                case RLMServiceTypes.THIRST:
                    {
                        prefix = "thirst";
                    }
                    break;
                case RLMServiceTypes.RECOVERY:
                    {
                        prefix = "recovery";

                    }
                    break;
                default:
                    {
                        prefix = null;
                    }
                    break;
            }
            Random r = new Random();
            int code = r.Next(1000, 9999);
            return prefix + code;
        }        
    }
}
