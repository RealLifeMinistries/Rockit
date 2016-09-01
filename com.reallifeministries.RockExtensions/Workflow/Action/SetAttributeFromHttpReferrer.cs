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
 
    [Description( "Set a text field attribute to the http referrer url" )]
    [Export( typeof( Rock.Workflow.ActionComponent ) )]
    [ExportMetadata( "ComponentName", "SetAttributeFromHttpReferrer" )]

    [WorkflowAttribute( "URL Field", "The attribute which will store the URL", true, "", "", 0,null,
        new string[] { "Rock.Field.Types.TextFieldType" } )]

    class SetAttributeFromHttpReferrer : Rock.Workflow.ActionComponent
    {
        /// <summary>
        /// Executes the action.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="action">The action.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="errorMessages">The error messages.</param>
        /// <returns></returns>
        public override bool Execute( RockContext rockContext, WorkflowAction action, object entity, out List<string> errorMessages )
        {
            errorMessages = new List<string>();

            if (HttpContext.Current != null)
            {
                var referrer = HttpContext.Current.Request.UrlReferrer.ToString();
                if (! String.IsNullOrEmpty(referrer))
                {
                    var urlAttrGuid = GetAttributeValue( action,"URLField" ).AsGuid();
                    var attribute = AttributeCache.Read( urlAttrGuid, rockContext );
                    if (attribute != null)
                    {
                        if (attribute.EntityTypeId == new Rock.Model.Workflow().TypeId)
                        {
                            action.Activity.Workflow.SetAttributeValue( attribute.Key, referrer );
                        }
                        else
                        {
                            action.Activity.SetAttributeValue( attribute.Key, referrer );
                        }
                    }
                }
                else
                {
                    action.AddLogEntry( "No HTTP Referrer detected" );
                }
            }
            else
            {
                action.AddLogEntry( "SetAttributeFromHTTPReferrer triggered outside an http context");
            }
            return true;
        }
    }
}