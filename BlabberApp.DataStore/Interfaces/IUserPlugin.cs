using BlabberApp.Domain.Interfaces;
using System;

namespace BlabberApp.DataStore.Interfaces
{
    public interface IUserPlugin : IPlugin
    {
        IEntity ReadByUserEmail(string email);
        void UpdateEmailById(Guid Id, string Email);
    }
}