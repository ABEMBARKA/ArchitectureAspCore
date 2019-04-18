namespace Oa.Service
{
    using System;
    using Oa.Data;

    public interface IUserProfileService
    {
        UserProfile GetUserProfile(Guid id);
    }
}