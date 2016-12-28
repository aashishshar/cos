using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IUserProfileEntryView
/// </summary>
public interface IUserProfileEntryView : IView
{
    string message { get; set; }   
    Guid UserProfileID { get; set; }
    string FullName { get; set; }   
    string UserNameEmailID { get; set; }
    string Password { get; set; }
    string PhoneNo { get; set; }   
    bool IsEmailVerified { get; set; }

    event EventHandler InsertUpdateCommand;    
}