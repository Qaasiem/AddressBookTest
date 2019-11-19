using AddressBook.DAL;
using AddressBook.Models;
using System;

namespace AddressBook.Logic
{
    public class AddressBookEngine : IAddressBookEngine
    {
        private readonly IAddressContext _addressContext;

        public AddressBookEngine(
            IAddressContext addressContext)
        {
            _addressContext = addressContext;
        }

        public bool RequestToCreateContact(AddressDetails addressDetails)
        {
            try
            {
                _addressContext.AddContact(addressDetails);

                return true;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public bool RequestToUpdateContact(UpdateAddressDetails addressDetails)
        {
            try
            {
                var AddressContact = _addressContext.UpdateContact(addressDetails);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public AddressDetails RequestToRetrieveContact(string firstName)
        {
            try
            {
                var AddressContact = _addressContext.GetContact(firstName);

                return AddressContact;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool RequestToDeleteContact(string firstName)
        {
            try
            {
                var AddressContact = _addressContext.DeleteContact(firstName);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        


    }
}
