using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb
{
    public static class SessionExtensions
    {
        public const string SESSION_USER = "username";
        public const string SESSION_ISADMIN = "isAdmin";

        public static void SetUsername(this ISession session, string username)
        {
            session.SetString(SESSION_USER, username);
        }

        public static string GetUsername(this ISession session)
        {
            return session.GetString(SESSION_USER);
        }

        public static bool IsSignedIn(this ISession session)
        {
            return session.Keys.Contains(SESSION_USER);
        }

        public static void SetIsAdmin(this ISession session, bool isAdmin)
        {
            session.SetString(SESSION_ISADMIN, isAdmin ? "1" : "0");
        }

        public static bool GetIsAdmin(this ISession session)
        {
            return session.GetString(SESSION_ISADMIN) == "1";
        }

    }
}
