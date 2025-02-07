using Abp.AspNetCore.Mvc.Authorization;
using INTIME.Authorization.Users.Profile;
using INTIME.Graphics;
using INTIME.Storage;

namespace INTIME.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : ProfileControllerBase
    {
        public ProfileController(
            ITempFileCacheManager tempFileCacheManager,
            IProfileAppService profileAppService,
            IImageValidator imageValidator) :
            base(tempFileCacheManager, profileAppService, imageValidator)
        {
        }
    }
}