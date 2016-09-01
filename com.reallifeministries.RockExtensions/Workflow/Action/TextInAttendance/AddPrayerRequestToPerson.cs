﻿using Rock.Attribute;
using Rock.Workflow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rock.Data;
using Rock.Model;
using Rock;
using Rock.Web.Cache;

namespace com.reallifeministries.RockExtensions.Workflow.Action
{
    /// <summary>
    /// Activates a new activity for a given activity type
    /// </summary>
    [Description("Adds a new Prayer Request to the given Person")]
    [Export(typeof(ActionComponent))]
    [ExportMetadata("ComponentName", "Add Prayer Request")]
    [WorkflowAttribute("PersonAttribute", "The workflow attribute containing the person.", true, "", "", 0, null,
        new string[] { "Rock.Field.Types.PersonFieldType" })]
    [WorkflowAttribute("Category", "The prayer request category to set", false, "", "", 0, null,
        new string[] { "Rock.Field.Types.CategoryFieldType" })]
    [WorkflowAttribute("PrayerRequest", "The Prayer Request to be Saved", true, "", "", 0, null,
        new string[] { "Rock.Field.Types.TextFieldType" })]    
    class AddPrayerRequestToPerson : ActionComponent
    {
        public override bool Execute(RockContext rockContext, WorkflowAction action, object entity, out List<string> errorMessages)
        {
            errorMessages = new List<string>();
            var personAttribute = GetAttributeValue(action, "PersonAttribute");
            Guid personAttrGuid = personAttribute.AsGuid();
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
                            var prayerRequestAttr = GetAttributeValue(action, "PrayerRequest").ResolveMergeFields(GetMergeFields(action));
                            var prayerRequestValue = action.GetWorklowAttributeValue(prayerRequestAttr.AsGuid());
                            var prayerRequestCategoryAttr = GetAttributeValue(action, "Category").ResolveMergeFields(GetMergeFields(action));
                            var categoryInst = action.GetWorklowAttributeValue(prayerRequestCategoryAttr.AsGuid());
                            var category = (new CategoryService(rockContext)).Get(categoryInst.AsGuid());
                            if (prayerRequestValue != null)
                            {
                                submitPrayer(personAlias, prayerRequestValue, category, rockContext);
                            }
                            else
                            {
                                errorMessages.Add(string.Format("PrayerRequest not valid entry"));
                            }
                            
                        }
                    }
                    else
                    {
                        errorMessages.Add(string.Format("PersonAlias cannot be found: {0}", personAliasGuid));
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

        private void submitPrayer(PersonAlias personAlias, string prayerRequest, Category category, RockContext rockContext)
        {
            var prayerService = new PrayerRequestService(rockContext);
            // Parse out 
            if (prayerRequest.StartsWith("2")){
                prayerRequest = prayerRequest.Substring(1, prayerRequest.Length - 1);
            }
            prayerService.Add(new PrayerRequest
            {
                EnteredDateTime = RockDateTime.Now,
                CreatedDateTime = RockDateTime.Now,
                ExpirationDate = RockDateTime.Now.AddYears(1),
                Text = prayerRequest,
                RequestedByPersonAlias = personAlias,
                IsActive = true,
                AllowComments = true,
                FirstName = personAlias.Person.FirstName,
                LastName = personAlias.Person.LastName,
                Category = category
            });
            rockContext.SaveChanges();
        }
    }
}
