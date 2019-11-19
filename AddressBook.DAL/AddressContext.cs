using AddressBook.Config;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace AddressBook.DAL
{
    public class AddressContext : IAddressContext
    {
        IMongoCollection<AddressDetails> _addressCollection;
        AddressBookConfig _addressBookConfig;

        public AddressContext(
            AddressBookConfig addressBookConfig)
        {
            _addressBookConfig = addressBookConfig;
            var client = new MongoClient(addressBookConfig.ConnectionString);
            var database = client.GetDatabase(addressBookConfig.Database);

            _addressCollection = database.GetCollection<AddressDetails>(addressBookConfig.BooksCollectionName);
        }

        public bool AddContact(AddressDetails addressDetails)
        {
            try
            {
                _addressCollection
                    .InsertOne(addressDetails);

                return true;

            }
            catch(DbException ex)
            {
                throw;
            }
        }

        [HttpPut]
        public bool UpdateContact(UpdateAddressDetails addressDetails)
        {
            try
            {
                var filter = Builders<AddressDetails>.Filter.Eq(a => a.FirstName, addressDetails.FirstName);

                var addressContact = Builders<AddressDetails>
                .Update
                .Set(a => a.FirstName, addressDetails.FirstName)
                .Set(a => a.LastName, addressDetails.LastName);

                return true;

            }
            catch (DbException ex)
            {
                throw;
            }
        }

        public AddressDetails GetContact(string firstName)
        {
            try
            {
                var filter = Builders<AddressDetails>.Filter.Eq(a => a.FirstName, firstName);

                var addressContact = _addressCollection
                .Find(filter)
                .FirstOrDefault();
               
                return addressContact;

            }
            catch (DbException ex)
            {
                throw;
            }
        }

        public bool DeleteContact(string firstName)
        {
            try
            {
                var filter = Builders<AddressDetails>.Filter.Eq(a => a.FirstName, firstName);

                var addressContact = _addressCollection
                .DeleteOne(filter);

                return true;

            }
            catch (DbException ex)
            {
                throw;
            }
        }
    }
}
