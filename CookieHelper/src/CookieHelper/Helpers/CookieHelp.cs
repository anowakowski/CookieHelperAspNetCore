//using Microsoft.AspNetCore.Http;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CookieHelper.Enums;
using Microsoft.AspNetCore.DataProtection;
//using Microsoft.AspNet.DataProtection;

namespace CookieHelper.Helpers
{
    public class CookieHelp : ICookieHelp
    {
        private readonly IEncryptHelp encryptHelp;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IDataProtector protecotr;
        public CookieHelp(IEncryptHelp encryptHelp, IHttpContextAccessor httpContextAccessor, IDataProtectionProvider provider)
        {
            this.encryptHelp = encryptHelp;
            this.httpContextAccessor = httpContextAccessor;
            this.protecotr = provider.CreateProtector(GetType().FullName);

        }
       
        public void SetCookie(string value, string key)
        {
            var protectValue = protecotr.Protect(value);

            this.httpContextAccessor.HttpContext.Response.Cookies.Append(key, protectValue);
        }

        public void SetCookie(string value, CookieKeys key)
        {
            this.SetCookie(value, key.ToString());
        }
        public string GetCookie(string key)
        {
            var cookie = this.httpContextAccessor.HttpContext.Request.Cookies[key];

            var unProtectValue = protecotr.Unprotect(cookie);

            return cookie;
        }

        public string GetCookie(CookieKeys key)
        {
            return this.GetCookie(key.ToString());
        }
    }
}
