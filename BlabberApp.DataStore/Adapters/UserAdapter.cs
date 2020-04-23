using System;
using System.Collections;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStore.Adapters
{
    public class UserAdapter
    {
       private readonly IUserPlugin _plugin;

       public UserAdapter(IUserPlugin plugin)
       {
           _plugin = plugin;
       }

       public void Add(User user)
       {
           _plugin.Create(user);
       }

       public void Remove(User user)
       {
           _plugin.Delete(user.Id);
       }

       public void UpdateEmailById(Guid Id, String email)
       {
           _plugin.UpdateEmailById(Id, email);
       }

       public IEnumerable GetAll()
       {
           return _plugin.ReadAll();
       }

       public User GetById(Guid Id)
       {
           return (User)_plugin.ReadById(Id);
       }

       public User GetByEmail(string email)
       {
           return (User)_plugin.ReadByUserEmail(email);
       }
    }
}