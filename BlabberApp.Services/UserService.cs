using System;
using System.Collections;
using BlabberApp.DataStore.Adapters;
using BlabberApp.Domain.Entities;

namespace BlabberApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserAdapter _adapter;
        public UserService(UserAdapter adapter)
        {
            _adapter = adapter;
        }

        public IEnumerable GetAll()
        {
            return _adapter.GetAll();
        }

        public void AddNewUser(string email)
        {
            try
            {
                _adapter.Add(CreateUser(email));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public User CreateUser(string email)
        {
            return new User(email);
        }

        public void RemoveUser(string email)
        {
            User userToRemove = _adapter.GetByEmail(email);
            _adapter.Remove(userToRemove);
        }

        public User FindUser(string email)
        {
            return _adapter.GetByEmail(email);
        }

        public bool CheckDuplicateEmail(string email)
        {
            if(_adapter.GetByEmail(email) == null)
                return false;
            else
                return true;
        }
    }
}
