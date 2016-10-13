using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novell.Directory.Ldap;

namespace DirectoryPlusOne.Helpers
{
    public static class ActiveDirectory
    {
        /// <summary>
        /// Returns the list of ADS groups a person is in
        /// </summary>
        /// <param name="ADDomain">the FQDN Active Directory you wish to query, e.g ads.case.edu </param>
        /// <param name="userName">the persons username</param>
        /// <returns>A list of strings that contains all of thier ads groups.</returns>

        /*
        public static List<string> GetUserGroupsFromADS(string ADDomain, string userName)
        {
            List<string> results = new List<string>();

            using (var context = new PrincipalContext(ContextType.Domain, ADDomain))
            {
                using (PrincipalSearchResult<Principal> source = UserPrincipal.FindByIdentity(context, userName).GetGroups(context))
                {
                    foreach (var group in source)
                    {
                        results.Add(group.SamAccountName);
                    }
                }
            }
            return results;
        }*/
        /// <summary>
        /// If a user is in an specified active directory group grant them authorization
        /// </summary>
        /// <param name="ADDomain">the FQDN Active Directory you wish to query, e.g ads.case.edu </param>
        /// <param name="userName">the username you want to check</param>
        /// <param name="groupName">the name of the ads group</param>
        /// <param name="recursiveSearch">If you want to search groups inside groups. Default is true.</param>
        /// <returns>Return true if userName is in groupName</returns>
        /// 
        /*
        public static bool isUserAuthorized(string ADDomain, string userName, string groupName, bool recursiveSearch = true)
        {
            bool isAuth = false;

            using (var context = new PrincipalContext(ContextType.Domain, ADDomain))
            {
                using (var group = GroupPrincipal.FindByIdentity(context, IdentityType.Name, groupName))
                {
                    isAuth = (group != null) && group.GetMembers(recursiveSearch).Any(user => user.SamAccountName == userName);
                }
            }
            return isAuth;
        }
        */

        /// <summary>
        /// If a user is in an specified active directory group grant them authorization
        /// </summary>
        /// <param name="ADDomain">the FQDN Active Directory you wish to query, e.g ads.case.edu </param>
        /// <param name="userName">the username you want to check</param>
        /// <param name="groupName">a list of group names you wish to check</param>
        /// <param name="recursiveSearch">If you want to search groups inside groups. Default is true.</param>
        /// <returns>Return true if userName is in groupName</returns>
        /// 
        /*
        public static bool isUserAuthorized(string ADDomain, string userName, List<string> groupNames, bool recursiveSearch = true)
        {
            bool isAuth = false;
            foreach (var g in groupNames)
            {
                isAuth = isUserAuthorized(ADDomain, userName, g, recursiveSearch);
                if (isAuth) break;
            }
            return isAuth;
        }*/

        /// <summary>
        /// Finds all the users in a ADGroup
        /// </summary>
        /// <param name="ADDomain">Active Directory Domain you want to search</param>
        /// <param name="ADGroupName">The group name you want to search</param>
        /// <param name="recursiveSearch">Do you want to search the groups inside of groups?</param>
        /// <returns></returns>
        /// 
        /*
        public static List<string> UsersInGroup(string ADDomain, string ADGroupName, bool recursiveSearch = true)
        {
            List<string> users = new List<string>();
            using (var context = new PrincipalContext(ContextType.Domain, ADDomain))
            {
                using (var group = GroupPrincipal.FindByIdentity(context, IdentityType.Name, ADGroupName))
                {
                    users = group.GetMembers(recursiveSearch).Select(a => a.SamAccountName).ToList();
                }
            }
            return users;
        }
        */
    }
}
