using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IModelSubCategory
/// </summary>
public interface IModelUserProfile
{
    UserProfile GetUserProfileByID(Guid userGUID);

    void DBOperation(string command, UserProfile userProfile = null, string id = "");	
}