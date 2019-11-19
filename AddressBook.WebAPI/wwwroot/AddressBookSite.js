const uri = 'https://localhost:44330/api/AddressBookController/';
let todos = [];

function addItem() {
    const addFirstNameTextbox = document.getElementById('firstName');
    const addLastNameTextbox = document.getElementById('lastName');
    const addConactNumbersTextbox = document.getElementById('contactNumber');
    const addEmailAddressesTextbox = document.getElementById('EmailAddress');

    const item = {
        isComplete: false,
        FirstName: addFirstNameTextbox.value.trim()
        LastName: addLastNameTextbox.value.trim()
        ContactNumber[]: addConactNumbersTextbox.value.trim()
        EmailAddress[]: addEmailAddressesTextbox.value.trim()
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            getItems();
            addFirstNameTextbox.value = '';
            addLastNameTextbox.value = '';
            addConactNumbersTextbox.value = '';
            addEmailAddressesTextbox.value = '';
        })
        .catch(error => console.error('Unable to add item.', error));
}



