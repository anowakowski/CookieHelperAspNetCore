//using Microsoft.AspNetCore.Http;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CookieHelper.Enums;

namespace CookieHelper.Helpers
{
    public class CookieHelp : ICookieHelp
    {
        private readonly IEncryptHelp encryptHelp;
        private readonly IHttpContextAccessor httpContextAccessor;
        public CookieHelp(IEncryptHelp encryptHelp, IHttpContextAccessor httpContextAccessor)
        {
            this.encryptHelp = encryptHelp;
            this.httpContextAccessor = httpContextAccessor;
        }
       
        public void SetCookie(string value, string key)
        {
            this.httpContextAccessor.HttpContext.Response.Cookies.Append(key, value);
        }

        public void SetCookie(string value, CookieKeys key)
        {
            this.SetCookie(value, key.ToString());
        }
        public string GetCookie(string key)
        {
            var cookie = this.httpContextAccessor.HttpContext.Request.Cookies[key];

            return cookie;
        }

        public string GetCookie(CookieKeys key)
        {
            return this.GetCookie(key.ToString());
        }
    }
}
