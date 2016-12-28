using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System.Collections;
using System.Web.Security;



    public class clsuser
    {

       //static ModelUserProfile modelUserProfile;

        public clsuser()
        {
            //modelUserProfile = new ModelUserProfile();
        }

        public static bool DeleteUser(string userName)
        {
            return Membership.DeleteUser(userName);
        }

        public static MembershipUserCollection getAllUser()
        {
            return Membership.GetAllUsers();
        }
        public static MembershipUserCollection getAllUser(int pageIndex,int pageSize,out int totalRecords)
        {
            totalRecords = 0;
            return Membership.GetAllUsers(pageIndex,pageSize,out totalRecords);
        }


        private static MembershipCreateStatus status;
        public static string CreateUser(string userName, string email, string password, string roleName, out string statusMessage,out string errorMessage)
        {
            string userGUID = string.Empty;
            statusMessage = string.Empty; errorMessage = string.Empty;
            try
            {
                MembershipUser mu = Membership.CreateUser(userName.TrimEnd(), password.TrimEnd(), email.TrimEnd(), "ques", "ans", true, out status);
                if (mu == null)
                {
                    statusMessage = GetErrorMessage(status);
                }
                else
                {
                    clsRole.AddUserToRole(userName, roleName);
                    userGUID = mu.ProviderUserKey.ToString();
                }
            }
            catch (MembershipCreateUserException mecue)
            {
                errorMessage = mecue.Message;
            }
            return userGUID;
        }
        //public static string GetErrorMessage(MembershipCreateStatus status)
        //{
        //    switch (status)
        //    {
        //        case MembershipCreateStatus.DuplicateUserName:
        //            return "Username already exists. Please enter a different user name.";

        //        case MembershipCreateStatus.DuplicateEmail:
        //            return "A username for that e-mail address already exists. Please enter a different e-mail address.";

        //        case MembershipCreateStatus.InvalidPassword:
        //            return "The password provided is invalid. Please enter a valid password value.";

        //        case MembershipCreateStatus.InvalidEmail:
        //            return "The e-mail address provided is invalid. Please check the value and try again.";

        //        case MembershipCreateStatus.InvalidAnswer:
        //            return "The password retrieval answer provided is invalid. Please check the value and try again.";

        //        case MembershipCreateStatus.InvalidQuestion:
        //            return "The password retrieval question provided is invalid. Please check the value and try again.";

        //        case MembershipCreateStatus.InvalidUserName:
        //            return "The user name provided is invalid. Please check the value and try again.";

        //        case MembershipCreateStatus.ProviderError:
        //            return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

        //        case MembershipCreateStatus.UserRejected:
        //            return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

        //        default:
        //            return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
        //    }
        //}
        //public static bool CreateUserProfile(UserProfile userProfile)
        //{
        //    bool createStatus = false;
        //    modelUserProfile.DBOperation("Insert", userProfile);
        //    createStatus = true;
        //    return createStatus;
        //}

        //public static bool UpdateUserProfile(UserProfile userProfile)
        //{
        //    bool createStatus = false;
        //    modelUserProfile.DBOperation("Update", userProfile);
        //    createStatus = true;
        //    return createStatus;
        //}
        
        public static string GetErrorMessage(MembershipCreateStatus status)
        {
            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Username already exists. Please enter a different user name.";
                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that e-mail address already exists. Please enter a different e-mail address.";
                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";
                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";
                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";
                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";
                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";
                //****** STAR LINE:i want to show the following message but i don't know if the-->
                //-->the provider error method can let me do this
                case MembershipCreateStatus.ProviderError:
                    return "field outreached the maximum length of characters which is:";
                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }
   
