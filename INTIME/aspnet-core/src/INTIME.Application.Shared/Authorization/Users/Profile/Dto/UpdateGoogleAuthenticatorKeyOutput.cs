using System.Collections.Generic;

namespace INTIME.Authorization.Users.Profile.Dto
{
    public class UpdateGoogleAuthenticatorKeyOutput
    {
        public IEnumerable<string> RecoveryCodes { get; set; }
    }
}
