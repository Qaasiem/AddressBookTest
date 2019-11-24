var addressBookBodel = {
    FirstName: "Qaasiem",
    LastName: "Samaai",
    ContactNumber[]: "",
    EmailAddress[]: ""
};

var request = $.ajax({
    type: "POST",
    data: addressBookBodel,
    url: "../product/save"
}).done(function (res) {
    console.log('res', res);
});
