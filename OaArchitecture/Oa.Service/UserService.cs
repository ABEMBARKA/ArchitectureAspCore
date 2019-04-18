namespace Oa.Service
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Oa.Data;
    using Oa.Repo;

    public class UserService:IUserService
    {
        private IRepository<User> _userRepository;
        private IRepository<UserProfile> _userProfileRepository;
        public UserService(IRepository<User> userRepository, IRepository<UserProfile> userProfileRepository)
        {
            this._userRepository = userRepository;
            this._userProfileRepository = userProfileRepository;
        }
        public  IEnumerable<User> GetUsers()
        {
            return  _userRepository.GetAll();
        }

        public  User GetUser(Guid id)
        {
            return  _userRepository.Get(id);
        }

        public void InsertUser(User user)
        {
           _userRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(Guid id)
        {
            UserProfile userProfile = _userProfileRepository.Get(id);
            _userProfileRepository.Remove(userProfile);
            User user = GetUser(id);
            _userRepository.Remove(user);
            _userRepository.SaveChanges();
        }
    }
}