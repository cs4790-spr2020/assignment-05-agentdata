using System;
using System.Collections;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.DataStore.Plugins
{
    public class InMemoryBlab : IBlabPlugin
    {
        private ArrayList buffer;
        public InMemoryBlab()
        {
            this.buffer = new ArrayList();
        }

        public void Create(IEntity obj)
        {
            this.buffer.Add(obj);
        }

        public IEnumerable ReadAll()
        {
            return this.buffer;
        }

        public IEntity ReadById(Guid _Id)
        {
            foreach(IEntity obj in this.buffer)
            {
                if (_Id.Equals(obj.Id)) return obj;
            }
            return null;
        }
        public IEnumerable ReadByUserId(string Email)
        {
            ArrayList tempList = new ArrayList();
            foreach(Blab blab in this.buffer)
            {
                if (Email.Equals(blab.User.Email))
                    tempList.Add(blab);
            }
            return tempList;
        }

        public void UpdateBlabById(Guid _Id, String _Message)
        {
            foreach(Blab blab in this.buffer)
            {
                if(blab.Id.Equals(_Id))
                {
                    blab.Message = _Message;
                    break;
                }
            }
        }      

        public void Delete(Guid _Id)
        {
            foreach(Blab _blab in this.buffer)
            {
                if(_blab.Id.Equals(_Id))
                {
                    this.buffer.Remove(_blab);
                    break;
                }
            }
        }

        public void DeleteAll()
        {
            this.buffer.Clear();
        }
    }
}