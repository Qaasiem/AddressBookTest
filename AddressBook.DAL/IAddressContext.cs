using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AddressBook.DAL
{
    public interface IAddressContext
    {
        bool AddContact(AddressDetails addressDetails);
        bool UpdateContact(UpdateAddressDetails addressDetails);
        AddressDetails GetContact(string firstName);
        bool DeleteContact(string firstName);
        
    }
}
