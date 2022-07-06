// JavaScript source code
function AdminEventMakingPageValidation()
{
    var FestName, EventName, EventDescription, EventCoordinator, NumberOfParticipants, DateOfTheEvent, TimeOfTheEvent;

    FestName = document.getElementById("ddlFestName").value;
    EventName = document.getElementById("txtEventName").value;
    EventDescription = document.getElementById("txtEventDescription").value;
    EventCoordinator = document.getElementById("ddlEventCoordinatorEmail").value;
    NumberOfParticipants = document.getElementById("ddlNumberOfParticipants").value;
    //EligibleGrades = document.getElementById("cblEligibleGrades").value;
    //DateOfTheEvent = document.getElementById("TextBox1").value;
    DateOfTheEvent = document.getElementById("txtDateOfTheEvent").value;
    TimeOfTheEvent = document.getElementById("ddlTimeOfTheEvent").value;

    if (FestName == 0 && EventName == '' && EventDescription == '' && EventCoordinator == 0 && NumberOfParticipants == 0 && DateOfTheEvent == '' && TimeOfTheEvent == 0)
    {
        alert("You haven't filled out the form! Please do so!");
        return false;
    }
    if (FestName == 0)
    {
        alert("Please Enter A Fest Name!");
        return false;
    }
    if (EventName == '') {
        alert("Please Enter An Event Name!");
        return false;
    }
    if (EventDescription == '') {
        alert("Please Fill In A Description Of The Event!");
        return false;
    }
    if (EventCoordinator == 0) {
        alert("Please Assign An Event Coordinator For This Event!");
        return false;
    }
    if (NumberOfParticipants == 0) {
        alert("Please Select The Desired Number Of Participants!");
        return false;
    }
    if (DateOfTheEvent == '')
    {
        alert("Sorry, but you haven't entered the Date Of The Event!");
        return false;
    }
    if (TimeOfTheEvent == 0) {
        alert("Sorry, but you haven't entered the Time Of The Event!");
        return false;
    }

    return true;
}