using System;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.Domain.Entities
{
    public class Blab : IEntity
    {
        public Guid Id { get; set; }
        public DateTime DTTM { get; set;}
        public string Message { get; set; }
        public User User { get; set; }

        public Blab()
        {
            this.User = new User();
            this.Message = "";
            this.DTTM = DateTime.Now;
            this.Id = Guid.NewGuid();
        }

        public Blab(string Message)
        {
            this.User = new User();
            this.Message = Message;
            this.DTTM = DateTime.Now;
            this.Id = Guid.NewGuid();
        }

        public Blab(User user)
        {
            this.User = user;
            this.Message = "";
            this.DTTM = DateTime.Now;
            this.Id = Guid.NewGuid();
        }

        public Blab(string Message, User user)
        {
            this.User = user;
            this.Message = Message;
            this.DTTM = DateTime.Now;
            this.Id = Guid.NewGuid();
        }

       
        public bool IsValid()
        {
            // Add code to validate class data.
            if ((this.Id) == null ||( this.User) == null) throw new ArgumentNullException();
            
            return true;
        }
    }
}