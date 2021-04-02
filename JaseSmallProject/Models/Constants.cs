using System;
using System.Collections.Generic;
using System.Text;

namespace JaseSmallProject.Models
{
    public static class Constants
    {
        public static readonly string TenantName = "cavb2c";
        public static readonly string TenantId = "cavb2c.onmicrosoft.com";
        public static readonly string ClientId = "6bd71b59-d966-46f0-bd72-b9e63d9ffee2";
        public static readonly string SignInPolicy = "b2c_1_sisu_jase";
        public static readonly string IosKeychainSecurityGroups = "com.microsoft.aadb2cauthentication";
        public static readonly string[] Scopes = new string[] { "openid", "offline_access" };
        public static readonly string[] Scopes2 = new string[] { "https://cavb2c.onmicrosoft.com/6bd71b59-d966-46f0-bd72-b9e63d9ffee2/readonly" };
        public static readonly string AuthorityBase = $"https://{TenantName}.b2clogin.com/tfp/{TenantId}/";
        public static readonly string AuthoritySignIn = $"{AuthorityBase}{SignInPolicy}";
    }
}
