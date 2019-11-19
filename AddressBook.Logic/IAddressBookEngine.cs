using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AddressBook.Logic
{
    public interface IAddressBookEngine
    {
        bool RequestToCreateContact(AddressDetails addressDetails);
        bool RequestToUpdateContact(UpdateAddressDetails addressDetails);
        AddressDetails RequestToRetrieveContact(string firstName);
        bool RequestToDeleteContact(string firstName);
        
    }
}
