using CookieHelper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieHelper.Helpers
{
    public interface ICookieHelp
    {
        void SetCookie(string value, string key);
        void SetCookie(string value, CookieKeys key);
        string GetCookie(string key);
        string GetCookie(CookieKeys key);
    }
}
