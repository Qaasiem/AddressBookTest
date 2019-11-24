using AddressBook.Logic;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.WebAPI.Controller.V1
{
    [Route("api")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
        private IAddressBookEngine _addressBookEngine;

        public AddressBookController(
            IAddressBookEngine addressBookEngine)
        {
            _addressBookEngine = addressBookEngine;
        }

        /// <summary>
        /// Adds a contact to the address book
        /// </summary>
        /// <param name="addressDetails"></param>
        [HttpPost]
        [Route("/createAdrress")]
        public bool CreateContact([FromBody]AddressDetails addressDetails)
        {

            try
            {
                _addressBookEngine.RequestToCreateContact(addressDetails);

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("Failed to create contact", ex);
            }
        }

        /// <summary>
        /// Retrieves a contact using first name
        /// </summary>
        /// <returns>AddressDetails</returns>
        [HttpPost]
        [Route("/getContactAddress")]
        public AddressDetails GetContactAddress(SearchTermModel searchTerm)
        {

            try
            {
                var addressContact = _addressBookEngine.RequestToRetrieveContact(searchTerm);

                return addressContact;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve contact", ex);
            }
        }

        /// <summary>
        /// Retrieves all contacts
        /// </summary>
        /// <returns>AddressDetails</returns>
        [HttpGet]
        [Route("/getAllContactAddress")]
        public async Task<List<AddressDetails>> GetAllContactAddress()
        {

            try
            {
                var addressContact = await _addressBookEngine.RequestToRetrieveAllContact();

                return addressContact;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve contact", ex);
            }
        }

        /// <summary>
        /// updates a contact
        /// </summary>
        /// <param name="addressDetails"></param>
        /// <returns>bool</returns>
        [HttpPost]
        [Route("/updateContact")]
        public bool UpdateAddress(UpdateAddressDetails addressDetails)
        {

            try
            {
                _addressBookEngine.RequestToUpdateContact(addressDetails);

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("Failed to update contact", ex);
            }
        }

        /// <summary>
        /// Retrieves a contact using first name
        /// </summary>
        /// <returns>AddressDetails</returns>
        [HttpPost]
        [Route("/deleteContactAddress")]
        public bool DeleteContactAddress([FromBody]DeleteContact deleteContact)
        {

            try
            {
                _addressBookEngine.RequestToDeleteContact(deleteContact);

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("Failed to delete contact", ex);
            }
        }

    }
}
