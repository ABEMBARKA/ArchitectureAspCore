namespace Oa.Service
{
    using System;
    using Oa.Data;
    using Oa.Repo;

    public class UserProfileService:IUserProfileService
    {
        private readonly IRepository<UserProfile> _userProfileRepository;
 
        public UserProfileService(IRepository<UserProfile> userProfileRepository)
        {          
            this._userProfileRepository = userProfileRepository;
        }
 
        public UserProfile GetUserProfile(Guid id)
        {
            return _userProfileRepository.Get(id);
        }
    }
}