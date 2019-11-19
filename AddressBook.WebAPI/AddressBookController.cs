using AddressBook.Logic;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AddressBook.WebAPI.Controller.V1
{
    [Route("api/[controller]")]
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
        [Route("/createAdress")]
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
        [HttpGet]
        [Route("/getContactAddress")]
        public AddressDetails GetContactAddress(string firstName)
        {

            try
            {
                var addressContact = _addressBookEngine.RequestToRetrieveContact(firstName);

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
        [HttpGet]
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
        [HttpGet]
        [Route("/deleteContactAddress")]
        public bool DeleteContactAddress(string firstName)
        {

            try
            {
                _addressBookEngine.RequestToDeleteContact(firstName);

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("Failed to delete contact", ex);
            }
        }

    }
}
