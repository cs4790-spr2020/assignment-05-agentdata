using System.Collections;
using BlabberApp.Domain.Entities;

namespace BlabberApp.Services
{
    public interface IUserService
    {
       IEnumerable GetAll(); 
       void AddNewUser(string email);
       User CreateUser(string email);
       void RemoveUser(string email);
       User FindUser(string email);
       bool CheckDuplicateEmail(string email);
    }
}