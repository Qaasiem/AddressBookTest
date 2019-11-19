namespace AddressBook.Config
{
    public class AddressBookConfig : IAddressBookConfig
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string BooksCollectionName { get; set; }

    }
}
