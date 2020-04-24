using System;
using System.Collections;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.DataStore.Plugins
{
    public class InMemoryUser : IUserPlugin
    {
        private ArrayList buffer;
        public InMemoryUser()
        {
            this.buffer = new ArrayList();
        }

        public void Create(IEntity obj)
        {
            this.buffer.Add(obj);
        }

        public IEntity ReadById(Guid _Id)
        {
            foreach(User user in this.buffer)
            {
                if (_Id.Equals(user.Id))
                {
                    return user;
                }
            }
            return null;
        }

        public IEntity ReadByUserEmail(string _Email)
        {
            foreach(User _user in buffer)
            {
                if (_user.Email.Equals(_Email))
                {
                    return _user;
                }
            }
            return null;
        }

          public IEnumerable ReadAll()
        {
            return this.buffer;
        }

        public void UpdateEmailById(Guid _Id, String _NewEmail)
        {
            foreach(User _user in this.buffer)
            {
                if(_user.Id.Equals(_Id))
                {
                    try{
                        _user.ChangeEmail(_NewEmail);
                    } catch(FormatException){}
                    break;
                }
            }
        }

        public void Delete(Guid _Id)
        {
            foreach(User _user in this.buffer)
            {
                if(_user.Id.Equals(_Id))
                {
                    this.buffer.Remove(_user);
                    break;
                }
            }
        }
    }
}
