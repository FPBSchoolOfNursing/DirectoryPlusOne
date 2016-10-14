using System;
using Novell.Directory.Ldap;
using System.Collections.Generic;

namespace DirectoryPlusOne.Helpers.LDAP
{
    public static class LDAP
    {

        public static string[] Query(string ADDomain)
        {
            List<string> results = new List<string>();

            LdapConnection conn = new LdapConnection();

            try
            {
                conn.Connect(ADDomain, LdapConnection.DEFAULT_PORT);
                conn.Bind(null, null);

                string searchBase = "ou=People,o=cwru.edu,o=isp";
                string searchFilter = "(uid=bdm4)";
                //string searchFilter = "(uid=" + data + ")";
                /*LdapSearchQueue queue =
                   conn.Search(searchBase, LdapConnection.SCOPE_ONE, searchFilter, null, false, (LdapSearchQueue)null, (LdapSearchConstraints)null);
               */

                LdapSearchResults searchResults = conn.Search(searchBase, LdapConnection.SCOPE_ONE, searchFilter, new string[] { LdapConnection.NO_ATTRS }, true);

                while (searchResults.hasMore())
                {
                    LdapEntry nextEntry = null;
                    nextEntry = searchResults.next();
                    results.Add(nextEntry.DN);
                }

            }
            catch (LdapException ldapex)
            {
                throw ldapex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //conn.Disconnect();

            return results.ToArray();

        }
    }
}
