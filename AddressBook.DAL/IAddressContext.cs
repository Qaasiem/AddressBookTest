using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.DAL
{
    public interface IAddressContext
    {
        bool AddContact(AddressDetails addressDetails);
        bool UpdateContact(UpdateAddressDetails addressDetails);
        AddressDetails GetContact(SearchTermModel searchTerm);
        bool DeleteContact(DeleteContact deleteContact);
        Task<List<AddressDetails>> GetContactAll();


    }
}
