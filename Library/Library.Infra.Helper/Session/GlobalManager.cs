using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Library.Infra.Helper.Session
{
    public class GlobalManager
    {
        private static ConcurrentDictionary<string, object> _Sessions = new ConcurrentDictionary<string, object>();

        public static void AddSession(object user)
        {
            if (!_Sessions.ContainsKey(HttpContext.Current.Session.SessionID))
            {
                _Sessions.TryAdd(HttpContext.Current.Session.SessionID, user);
                HttpContext.Current.Session["SessionID"] = HttpContext.Current.Session.SessionID;
            }
        }

        public static object UserCurrent
        {
            get
            {
                object source;
                _Sessions.TryGetValue(HttpContext.Current.Session["SessionID"].ToString(), out source);
                return source;
            }
        }

        public static bool IsAuthenticated
        {
            get
            {
                return _Sessions.ContainsKey(HttpContext.Current.Session.SessionID);
            }
        }
    }
}
