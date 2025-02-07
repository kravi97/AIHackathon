﻿namespace INTIME.Maui.Services.User
{
    public interface IUserProfileService
    {
        Task<string> GetProfilePicture(long userId);

        string GetDefaultProfilePicture();
    }
}