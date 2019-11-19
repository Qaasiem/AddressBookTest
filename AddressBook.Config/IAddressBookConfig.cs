namespace AddressBook.Config
{
    public interface IAddressBookConfig
    {
        string ConnectionString { get; }
        string Database { get; }
        string BooksCollectionName { get; }
    }
}
