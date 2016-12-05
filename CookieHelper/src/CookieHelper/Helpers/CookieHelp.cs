//using Microsoft.AspNetCore.Http;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CookieHelper.Enums;
using Microsoft.AspNetCore.DataProtection;

namespace CookieHelper.Helpers
{
    public class CookieHelp : ICookieHelp
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IDataProtector protecotr;
        public CookieHelp(IHttpContextAccessor httpContextAccessor, IDataProtectionProvider provider)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.protecotr = provider.CreateProtector(GetType().FullName);
        }
       
        public void SetCookie(string value, string key)
        {
            this.httpContextAccessor.HttpContext.Response.Cookies.Append(key, this.ProtectCookieValue(value));
        }

        public void SetCookie(string value, CookieKeys key)
        {
            this.SetCookie(value, key.ToString());
        }
        public string GetCookie(string key)
        {
            var cookie = this.UnprotectCookieValue(this.httpContextAccessor.HttpContext.Request.Cookies[key]);

            return cookie;
        }
        public string GetCookie(CookieKeys key)
        {
            return this.GetCookie(key.ToString());
        }
        public void DeleteCookie(string key)
        {
            this.httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }
        public void DeleteCookie(CookieKeys key)
        {
            this.DeleteCookie(key.ToString());
        }

        private string ProtectCookieValue(string value)
        {
            return protecotr.Protect(value);
        }

        private string UnprotectCookieValue(string protectedValue)
        {
            return protecotr.Unprotect(protectedValue);
        }
    }
}
