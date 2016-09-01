// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;

using Rock;
using Rock.Attribute;
using Rock.Data;
using Rock.Model;
using Rock.Web.Cache;
using Rock.Workflow;

namespace com.reallifeministries.RockExtensions.Workflow.Action
{
    /// <summary>
    /// Sets an attribute's value to the selected person 
    /// </summary>    
    [Description("Sets an attribute to a person with matching name and email. If single match is not found a new person will be created.")]
    [Export(typeof(ActionComponent))]
    [ExportMetadata("ComponentName", "Person Attribute From Fields")]

    [WorkflowTextOrAttribute("First Name", "Attribute Value", "The first name or an attribute that contains the first name of the person. <span class='tip tip-lava'></span>",
        false, "", "", 0, "FirstName", new string[] { "Rock.Field.Types.TextFieldType" })]
    [WorkflowTextOrAttribute("Last Name", "Attribute Value", "The last name or an attribute that contains the last name of the person. <span class='tip tip-lava'></span>",
        false, "", "", 1, "LastName", new string[] { "Rock.Field.Types.TextFieldType" })]
    [WorkflowTextOrAttribute("Birthdate", "Attribute Value", "The birthdate or an attribute that contains the birthdate of the person. <span class='tip tip-lava'></span>",
        false, "", "", 2, "Birthdate", new string[] { "Rock.Field.Types.DateFieldType" })]
    [WorkflowTextOrAttribute("Email Address", "Attribute Value", "The email address or an attribute that contains the email address of the person. <span class='tip tip-lava'></span>",
        false, "", "", 3, "Email", new string[] { "Rock.Field.Types.TextFieldType", "Rock.Field.Types.EmailFieldType" })]
    [WorkflowAttribute("Person Attribute", "The person attribute to set the value to the person found or created.",
        true, "", "", 4, "PersonAttribute", new string[] { "Rock.Field.Types.PersonFieldType" })]
    [WorkflowTextOrAttribute("Primary Phone Number", "Attribute Value", "The primary phone number or an attribute that contains the primary phone number of the person. <span class='tip tip-lava'></span>",
        false, "", "", 5, "PhoneNumber", new string[] { "Rock.Field.Types.TextFieldType" })]
    [WorkflowTextOrAttribute("Address", "Attribute Value", "The address or an attribute that contains the address of the person. <span class='tip tip-lava'></span>",
        false, "", "", 6, "Address", new string[] { "Rock.Field.Types.LocationFieldType" })]
    [WorkflowTextOrAttribute("Spouse First Name", "Attribute Value", "The spouses first name or an attribute that contains the first name of the person. <span class='tip tip-lava'></span>",
        false, "", "", 7, "SpouseFirstName", new string[] { "Rock.Field.Types.TextFieldType" })]
    [WorkflowTextOrAttribute("Spouse Last Name", "Attribute Value", "The spouses last name or an attribute that contains the last name of the person. <span class='tip tip-lava'></span>",
        false, "", "", 8, "SpouseLastName", new string[] { "Rock.Field.Types.TextFieldType" })]
    [WorkflowTextOrAttribute("Spouse Primary Phone Number", "Attribute Value", "The primary phone number or an attribute that contains the primary phone number of the person. <span class='tip tip-lava'></span>",
        false, "", "", 9, "SpousePhoneNumber", new string[] { "Rock.Field.Types.TextFieldType" })]
    [WorkflowTextOrAttribute("Spouse Birthdate", "Attribute Value", "The birthdate or an attribute that contains the birthdate of the person. <span class='tip tip-lava'></span>",
        false, "", "", 10, "SpouseBirthdate", new string[] { "Rock.Field.Types.DateFieldType" })]
    [DefinedValueField(Rock.SystemGuid.DefinedType.PERSON_RECORD_STATUS, "Default Record Status", "The record status to use when creating a new person", false, false,
        Rock.SystemGuid.DefinedValue.PERSON_RECORD_STATUS_PENDING, "", 11)]
    [DefinedValueField(Rock.SystemGuid.DefinedType.PERSON_CONNECTION_STATUS, "Default Connection Status", "The connection status to use when creating a new person", false, false,
        Rock.SystemGuid.DefinedValue.PERSON_CONNECTION_STATUS_WEB_PROSPECT, "", 12)]
    [WorkflowAttribute("Default Campus", "The attribute value to use as the default campus when creating a new person.",
        true, "", "", 13, "DefaultCampus", new string[] { "Rock.Field.Types.CampusFieldType" })]
    public class AddPersonAndSpouseFromFields : ActionComponent
    {
        /// <summary>
        /// Executes the specified workflow.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="action">The action.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="errorMessages">The error messages.</param>
        /// <returns></returns>
        public override bool Execute(RockContext rockContext, WorkflowAction action, Object entity, out List<string> errorMessages)
        {
            errorMessages = new List<string>();


            string attributeValue = GetAttributeValue(action, "PersonAttribute");
            Guid? guid = attributeValue.AsGuidOrNull();
            if (guid.HasValue)
            {
                var attribute = AttributeCache.Read(guid.Value, rockContext);
                if (attribute != null)
                {
                    string firstName = GetValue(action, "FirstName", rockContext);
                    string lastName = GetValue(action, "LastName", rockContext);
                    string email = GetValue(action, "Email", rockContext);
                    string phoneNumber = GetValue(action, "PhoneNumber", rockContext);
                    string address = GetValue(action, "Address", rockContext);
                    string birthdate = GetValue(action, "Birthdate", rockContext);
                    string spouseFirstName = GetValue(action, "SpouseFirstName", rockContext);
                    string spouseLastName = GetValue(action, "SpouseLastName", rockContext);
                    string spouseEmail = GetValue(action, "SpouseEmail", rockContext);
                    string spousePhoneNumber = GetValue(action, "SpousePhoneNumber", rockContext);
                    string spouseBirthdate = GetValue(action, "SpouseBirthdate", rockContext);

                    if (string.IsNullOrWhiteSpace(firstName) ||
                        string.IsNullOrWhiteSpace(lastName) ||
                        string.IsNullOrWhiteSpace(email))
                    {
                        errorMessages.Add("First Name, Last Name, and Email are required. One or more of these values was not provided!");
                    }
                    else
                    {
                        PersonAlias personAlias = null;
                        PersonAlias spousePersonAlias = null;
                        var person = CreateOrGetPerson(action, firstName, lastName, email, phoneNumber, birthdate, address, personAlias, false);
                        var spousePerson = CreateOrGetPerson(action, spouseFirstName, spouseLastName, spouseEmail, spousePhoneNumber, spouseBirthdate, null, spousePersonAlias, true);

                        if (person != null && personAlias != null)
                        {
                            action.Activity.Workflow.SetAttributeValue(attribute.Key, personAlias.Guid.ToString());
                            action.AddLogEntry(string.Format("Set '{0}' attribute to '{1}'.", attribute.Name, person.FullName));
                            return true;
                        }
                        else
                        {
                            errorMessages.Add("Person or Primary Alias could not be determined!");
                        }
                    }
                }
                else
                {
                    errorMessages.Add(string.Format("Person Attribute could not be found for selected attribute value ('{0}')!", guid.Value.ToString()));
                }
            }
            else
            {
                errorMessages.Add(string.Format("Selected Person Attribute value ('{0}') was not a valid Guid!", attributeValue));
            }

            if (errorMessages.Any())
            {
                errorMessages.ForEach(m => action.AddLogEntry(m, true));
                return false;
            }

            return true;
        }

        private Person CreateOrGetPerson(WorkflowAction action, string firstName, string lastName, string email, string phoneNumber, string birthdate, string address, PersonAlias personAlias, bool isSpouse)
        {
            var rockContext = new RockContext();
            Person person = null;        
            var personService = new PersonService(rockContext);
            var people = personService.GetByMatch(firstName, lastName, email).ToList();
            if (people.Count == 1)
            {
                person = people.First();
                personAlias = person.PrimaryAlias;
            }
            else
            {
                // Add New Person
                person = new Person();
                person.FirstName = firstName;
                person.LastName = lastName;
                person.IsEmailActive = true;
                person.Email = email;
                if (!String.IsNullOrWhiteSpace(phoneNumber))
                {
                    person.PhoneNumbers.Add(new PhoneNumber { NumberTypeValueId = 13, Number = phoneNumber });
                }
                if (!String.IsNullOrWhiteSpace(address))
                {

                }
                if (!String.IsNullOrWhiteSpace(birthdate))
                {
                    person.SetBirthDate(DateTime.Parse(birthdate));
                }
                person.EmailPreference = EmailPreference.EmailAllowed;
                person.RecordTypeValueId = DefinedValueCache.Read(Rock.SystemGuid.DefinedValue.PERSON_RECORD_TYPE_PERSON.AsGuid()).Id;

                var defaultConnectionStatus = DefinedValueCache.Read(GetAttributeValue(action, "DefaultConnectionStatus").AsGuid());
                if (defaultConnectionStatus != null)
                {
                    person.ConnectionStatusValueId = defaultConnectionStatus.Id;
                }

                var defaultRecordStatus = DefinedValueCache.Read(GetAttributeValue(action, "DefaultRecordStatus").AsGuid());
                if (defaultRecordStatus != null)
                {
                    person.RecordStatusValueId = defaultRecordStatus.Id;
                }

                var defaultCampus = CampusCache.Read(GetValue(action, "DefaultCampus", rockContext).AsGuid());
                var familyGroup = PersonService.SaveNewPerson(person, rockContext, (defaultCampus != null ? defaultCampus.Id : (int?)null), false);
                familyGroup.GroupLocations.Add(new GroupLocation
                {
                    Location = new Location
                    {
                        Street1 = address
                    }
                });
                if (familyGroup != null && familyGroup.Members.Any())
                {
                    person = familyGroup.Members.Select(m => m.Person).First();
                    personAlias = person.PrimaryAlias;
                }
            }
            return person;        
    }

        private string GetValue(WorkflowAction action, string key, RockContext rockContext)
        {
            string value = GetAttributeValue(action, key);
            Guid? guid = value.AsGuidOrNull();
            if (guid.HasValue)
            {
                var attribute = AttributeCache.Read(guid.Value, rockContext);
                if (attribute != null)
                {
                    return action.GetWorklowAttributeValue(guid.Value);
                }
            }

            return value;
        }
    }
}