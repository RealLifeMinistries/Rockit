using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Web;

using Rock;
using Rock.Attribute;
using Rock.Data;
using Rock.Model;
using Rock.Web.Cache;
using Rock.Workflow;

namespace com.reallifeministries.RockExtensions.Workflow.Action
{
    /// <summary>
    /// Sends user to a specific page
    /// </summary>
    [Description( "Redirect User to a page" )]
    [Export( typeof( ActionComponent ) )]
    [ExportMetadata( "ComponentName", "RedirectToPage" )]

    [LinkedPage("Page","A page to send the user to to",false)]
    [WorkflowAttribute( "PageAttribute", "An attribute containing a page reference, or a text field with a URL.",false, "", "", 0, null,
        new string[] { "Rock.Field.Types.PageReferenceFieldType", "Rock.Field.Types.TextFieldType" } )]
    public class RedirectToPage : ActionComponent
    {
        private RockContext _rockContext;
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

            if (HttpContext.Current != null)
            {
                _rockContext = rockContext;

                var workflow = action.Activity.Workflow;

                var page = GetAttributeValue( action, "Page" );
                string url = null;

                if (string.IsNullOrEmpty( page ))
                {
                    var guidPageAttributeValue = GetAttributeValue( action, "PageAttribute" ).AsGuidOrNull();

                    if (guidPageAttributeValue.HasValue)
                    {
                        var attributePage = AttributeCache.Read( guidPageAttributeValue.Value, rockContext );
                        if (attributePage != null)
                        {
                            if (attributePage.FieldType.Class == "Rock.Field.Types.PageReferenceFieldType") {
                                page = action.GetWorklowAttributeValue( guidPageAttributeValue.Value );
                            }
                            else
                            {
                                var urlValue = action.GetWorklowAttributeValue( guidPageAttributeValue.Value );
                                Uri uri;
                                if (Uri.TryCreate( urlValue, UriKind.RelativeOrAbsolute, out uri ))
                                {
                                    url = uri.ToString();
                                }
                            }

                        }
                        
                    }
                }

                if (workflow.IsPersisted)
                {
                    PersistWorkflow( workflow ); //ensure any changes are saved before redirecting.
                }

                if (!String.IsNullOrEmpty( page ))
                {
                    var queryParams = new Dictionary<string, string>();
                    queryParams.Add( "WorkflowTypeId", action.Activity.Workflow.WorkflowTypeId.ToString() );

                    if (workflow.Id != 0)
                    {
                        queryParams.Add( "WorkflowId", action.Activity.WorkflowId.ToString() );
                    }

                    var pageReference = new Rock.Web.PageReference( page, queryParams );
                    HttpContext.Current.Response.Redirect( pageReference.BuildUrl(), false );

                }
                else if (!String.IsNullOrEmpty( url ))
                {
                    HttpContext.Current.Response.Redirect( url, false );
                }

            }
            return true;
        }
        
        private void PersistWorkflow(Rock.Model.Workflow workflow )
        {
            if (workflow.Id == 0)
            {
                var workflowService = new WorkflowService( _rockContext );
                workflowService.Add( workflow );
            }

            _rockContext.WrapTransaction( () =>
            {
                _rockContext.SaveChanges();
                workflow.SaveAttributeValues( _rockContext );
                foreach (var activity in workflow.Activities)
                {
                    activity.SaveAttributeValues( _rockContext );
                }
            } );
        }
    }
}
