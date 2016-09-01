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
using Rock.Workflow.Action;

namespace com.reallifeministries.RockExtensions.Workflow.Action
{
    /// <summary>
    /// Activates a new activity for a given activity type
    /// </summary>
    [Description( "Activates a new workflow. The attributes from this current activity, and workflow will be passed as attributes to the next workflow." )]
    [Export( typeof( ActionComponent ) )]
    [ExportMetadata( "ComponentName", "Activate Workflow" )]

    [WorkflowTypeField( "Workflow", "The workflow type to activate", false,true,"","",0)]
    [TextField("WorkflowName", "What to name this Workflow Instance  <span class='tip tip-lava'></span>", true)]
    public class ActivateWorkflow : ActionComponent
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
            var guid = GetAttributeValue( action, "Workflow" ).AsGuid();
            if (guid.IsEmpty())
            {
                action.AddLogEntry( "Invalid Workflow Property", true );
                return false;
            }

            var currentActivity = action.Activity;
            var newWorkflowType = new WorkflowTypeService( rockContext ).Get( guid );
            var newWorkflowName = GetAttributeValue(action, "WorkflowName" );

            var mergeFields = GetMergeFields(action);

            newWorkflowName = newWorkflowName.ResolveMergeFields(mergeFields);

            if (newWorkflowType == null)
            {
                action.AddLogEntry( "Invalid Workflow Property", true );
                return false;
            }
            
            var newWorkflow = Rock.Model.Workflow.Activate( newWorkflowType, newWorkflowName );            
            if (newWorkflow == null)
            {
                action.AddLogEntry( "The Workflow could not be activated", true );
                return false;
            }

            CopyAttributes( newWorkflow, currentActivity, rockContext );
            // Set Initiator in workflow as current person
            newWorkflow.InitiatorPersonAlias = action.Activity.Workflow.InitiatorPersonAlias;
            newWorkflow.InitiatorPersonAliasId = action.Activity.Workflow.InitiatorPersonAliasId;
            newWorkflow.CreatedByPersonAlias = action.Activity.Workflow.CreatedByPersonAlias;
            newWorkflow.CreatedByPersonAliasId = action.Activity.Workflow.CreatedByPersonAliasId;
            
            SaveForProcessingLater(newWorkflow, rockContext);
            // Process new workflow
            try
            {
                new WorkflowService(rockContext).Process(newWorkflow, out errorMessages);
            }
            catch(Exception e)
            {
                action.AddLogEntry(string.Format("The Workflow couldn't be processed: {0}", e.Message));
            }

            return true;            
        }
        private void SaveForProcessingLater(Rock.Model.Workflow newWorkflow, RockContext rockContext)
        {
            newWorkflow.IsPersisted = true;
            var service = new WorkflowService( rockContext );
            if (newWorkflow.Id == 0)
            {
                service.Add( newWorkflow );
            }

            rockContext.WrapTransaction( () =>
            {
                rockContext.SaveChanges();
                newWorkflow.SaveAttributeValues( rockContext );
                
                foreach (var activity in newWorkflow.Activities)
                {
                    activity.SaveAttributeValues( rockContext );
                }
            } );
        }

        private void CopyAttributes(Rock.Model.Workflow newWorkflow, Rock.Model.WorkflowActivity currentActivity, RockContext rockContext)
        {
            if (currentActivity.Attributes == null)
            {
                currentActivity.LoadAttributes( rockContext );
            }

            if (currentActivity.Workflow.Attributes == null)
            {
                currentActivity.Workflow.LoadAttributes( rockContext );
            }

            // Pass attributes from current Workflow to new Workflow.
            foreach (string key in currentActivity.Workflow.AttributeValues.Keys)
            {
                newWorkflow.SetAttributeValue( key, currentActivity.Workflow.GetAttributeValue( key ) );
            }

            // Pass attributes from current Activity to new Workflow.
            foreach (string key in currentActivity.AttributeValues.Keys)
            {
                newWorkflow.SetAttributeValue( key, currentActivity.GetAttributeValue(key) );
            }
        }
    }
}
