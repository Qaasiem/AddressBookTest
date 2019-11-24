using AddressBook.Config;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
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
                var filter = Builders<AddressDetails>.Filter.Eq(a => a.FirstName, addressDetails.FirstName) &
                    Builders<AddressDetails>.Filter.Eq(a => a.LastName, addressDetails.LastName);

                var result = _addressCollection.Find(filter);

                if (result.CountDocuments() > 0)
                {
                    throw new Exception("Contact already exists");
                }


                _addressCollection
                    .InsertOne(addressDetails);

                return true;

            }
            catch (DbException ex)
            {
                throw;
            }
        }

        [HttpPut]
        public bool UpdateContact(UpdateAddressDetails addressDetails)
        {
            try
            {
                var updateAddressContact = Builders<AddressDetails>
                .Update
                .Set(a => a.FirstName, addressDetails.FirstName)
                .Set(a => a.LastName, addressDetails.LastName)
                .Set(a => a.ContactNumber, addressDetails.ContactNumber)
                .Set(a => a.EmailAddress, addressDetails.EmailAddress);

                var result = _addressCollection.FindOneAndUpdate(
                    Builders<AddressDetails>.Filter.Eq(a => a.FirstName, addressDetails.FirstName) &
                    Builders<AddressDetails>.Filter.Eq(a => a.LastName, addressDetails.LastName),
                    updateAddressContact);

                return true;

            }
            catch (DbException ex)
            {
                throw;
            }
        }

        public AddressDetails GetContact(SearchTermModel searchTerm)
        {
            try
            {
                var filter = Builders<AddressDetails>.Filter.Eq(a => a.FirstName, searchTerm.FirstName);

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

        public async Task<List<AddressDetails>> GetContactAll()
        {
            try
            {
                var result = await _addressCollection.Find(new BsonDocument()).ToListAsync();

                return result;
            }
            catch (DbException ex)
            {
                throw;
            }
        }

        public bool DeleteContact(DeleteContact deleteContact)
        {
            try
            {
                var filter = Builders<AddressDetails>.Filter.Eq(a => a.FirstName, deleteContact.FirstName) &
                 Builders<AddressDetails>.Filter.Eq(a => a.LastName, deleteContact.LastName);

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
