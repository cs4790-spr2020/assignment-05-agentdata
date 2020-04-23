using System;
using System.Collections;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStore.Adapters
{
    public class BlabAdapter
    {
       private IBlabPlugin plugin;

       public BlabAdapter(IBlabPlugin plugin)
       {
           this.plugin = plugin;
       }

       public void Add(Blab blab)
       {
           this.plugin.Create(blab);
       }

       public void Remove(Blab blab)
       {
           this.plugin.Delete(blab.Id);
       }

       public void UpdateBlabById(Guid Id, String Message)
       {
           this.plugin.UpdateBlabById(Id, Message);
       }

       public IEnumerable GetAll()
       {
           return this.plugin.ReadAll();
       }

       public Blab GetByBlabId(Guid Id)
       {
           return (Blab)this.plugin.ReadById(Id);
       }

       public IEnumerable GetByUserId(string Email)
       {
           return (ArrayList)this.plugin.ReadByUserId(Email);
       }
    }
}