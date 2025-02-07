using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using INTIME.Authorization.Users;
using INTIME.MultiTenancy;

namespace INTIME.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}