using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace INTIME.Web.Authentication.JwtBearer
{
    public class AsyncJwtBearerOptions : JwtBearerOptions
    {
        public readonly List<IAsyncSecurityTokenValidator> AsyncSecurityTokenValidators;
        
        private readonly INTIMEAsyncJwtSecurityTokenHandler _defaultAsyncHandler = new INTIMEAsyncJwtSecurityTokenHandler();

        public AsyncJwtBearerOptions()
        {
            AsyncSecurityTokenValidators = new List<IAsyncSecurityTokenValidator>() {_defaultAsyncHandler};
        }
    }

}
