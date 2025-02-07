using Abp.Authorization;
using INTIME.Authorization.Roles;
using INTIME.Authorization.Users;

namespace INTIME.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
