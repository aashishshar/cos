using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for IUserProfileEntryView
/// </summary>
public interface IUserProfileUpdateView : IView
{
    string message { get; set; }


    // string LoginUserName { get; set; }
    Guid UserProfileID { get; set; }
    string FullName { get; set; }
    string ProfilePicture { get; set; }
    DateTime? DOB { get; set; }
    string PhoneNo { get; set; }
    bool? IsEmailVerified { get; set; }
    bool? IsOfferReceiveWeekly { get; set; }
    bool? IsOtherInfo { get; set; }
    string BankAcHolderName { get; set; }
    string BankName { get; set; }
    string BankBranchName { get; set; }
    string BankAccountNo { get; set; }
    string IFSCCode { get; set; }
    string FullNameOnAdd { get; set; }
    string FullAddress { get; set; }
    string City { get; set; }
    string State { get; set; }
    string PinCode { get; set; }



    event EventHandler UpdateCommand;
}