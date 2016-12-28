using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


    public class clsRole
    {


        public static string[] GetAllRoles()
        {
           return Roles.GetAllRoles();
        }

        public static bool CreateRole(string roleName)
        {
            Roles.CreateRole(roleName);
            return true;
        }

        public static bool DeleteRole(string roleName)
        {
            if (Roles.DeleteRole(roleName))
                return true;
            else
                return false;
        }

        public static bool AddUserToRole(string userName,string roleName)
        {
            Roles.AddUserToRole(userName, roleName);
            
            return true;

        }

        public static string[] GetRolesForUser(string userName)
        {
            return Roles.GetRolesForUser(userName);
        }

        public static string[] GetUsersInRole(string roleName)
        {
            return Roles.GetUsersInRole(roleName);
        }

        public static bool GetUsersInRole(string userName, string roleName)
        {
            Roles.RemoveUserFromRole(userName, roleName);
            return true;
        }
    }
