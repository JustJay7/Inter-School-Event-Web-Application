// JavaScript source code
function EventCoordinatorRegistrationPageValidation()
{
    var EventCoordinatorName, EventCoordinatorEmail, ValidateEmail, EventCoordinatorPhoneNumber, ValidatePhoneNumber,
        EventCoordinatorPassword, EventCoordinatorConfirmPassword;

    ValidatePhoneNumber = /^[1-9]{1}[0-9]{9}$/;
    ValidateEmail = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/;
    EventCoordinatorName = document.getElementById("txtEventCoordinatorName").value;
    EventCoordinatorEmail = document.getElementById("txtEventCoordinatorEmail").value;
    EventCoordinatorPhoneNumber = document.getElementById("txtEventCoordinatorPhoneNumber").value;
    EventCoordinatorPassword = document.getElementById("txtEventCoordinatorCreatePassword").value;
    EventCoordinatorConfirmPassword = document.getElementById("txtEventCoordinatorConfirmPassword").value;

    if (EventCoordinatorName == '' && EventCoordinatorEmail == '' && EventCoordinatorPhoneNumber == ''
        && EventCoordinatorPassword == '' && EventCoordinatorConfirmPassword == '')
    {
        alert("You haven't filled out the form! Please do so!");
        return false;
    }
    if (EventCoordinatorName == '')
    {
        alert("Please Enter a Name");
        return false;
    }
    if (EventCoordinatorEmail == '')
    {
        alert("Please Enter your Email ID.");
        return false;
    }
    if (EventCoordinatorEmail != '')
    {
        if (!EventCoordinatorEmail.match(ValidateEmail))
        {
            alert("Invalid Email ID.");
            return false;
        }
    }
    if (EventCoordinatorPhoneNumber == '')
    {
        alert("Please Enter Your Phone Number!");
        return false;
    }
    if (EventCoordinatorPhoneNumber != '')
    {
        if (!EventCoordinatorPhoneNumber.match(ValidatePhoneNumber))
        {
            alert("Please Enter A Valid Mobile Number!");
            return false;
        }
    }
    if (EventCoordinatorPassword == '')
    {
        alert("Please Create a Password.");
        return false;
    }
    if (EventCoordinatorPassword != '' && EventCoordinatorConfirmPassword == '')
    {
        alert("Please Confirm the Password.");
        return false;
    }
    if (EventCoordinatorPassword != EventCoordinatorConfirmPassword)
    {
        alert("The Passwords don't match. Please try again");
        return false;
    }

    return true;
}