using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ModelSubCategory
/// </summary>
public class ModelUserProfile : IModelUserProfile
{
      clsCommonMethods client;
      public ModelUserProfile()
	{
        client = new clsCommonMethods();
	}



    #region IModelUserProfile Members

    public UserProfile GetUserProfileByID(Guid userGUID)
    {
        
        UserProfile userProfile = client.GetUserByuserID(userGUID);
        return userProfile;
    }

    public void DBOperation(string command, UserProfile userProfile = null, string id = "")
    {       
        switch (command)
        {
            case "Insert":
                client.InsertUserProfile(userProfile);
                break;
            case "Delete":
                client.DeleteUserProfile(new Guid(id));
                break;
            case "Update":
                client.UpdateUserProfile(userProfile);
                break;
            default:
                break;
        }
    }

    #endregion
}