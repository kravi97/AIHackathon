using INTIME.Maui.Models.NavigationMenu;

namespace INTIME.Maui.Services.Navigation
{
    public interface IMenuProvider
    {
        List<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}