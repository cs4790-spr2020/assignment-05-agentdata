using System;
using System.Net.Mail;
using BlabberApp.Domain.Interfaces;
namespace BlabberApp.Domain.Entities
{
    public class User : IEntity
    {
        public Guid Id {get; set;}
        public System.DateTime RegisterDTTM { get; set; }
        public System.DateTime LastLoginDTTM { get; set; }
        public string Email { get; private set; }

        public User()
        {
            this.Id = Guid.NewGuid();
            RegisterDTTM = System.DateTime.Now;
            LastLoginDTTM = System.DateTime.Now;
        }

        public User(string email)
        {
            this.Id = Guid.NewGuid();
            this.ChangeEmail(email); 
            RegisterDTTM = System.DateTime.Now;
            LastLoginDTTM = System.DateTime.Now;

        }

        public void ChangeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length > 50)
                throw new FormatException(email+" is invalid");
            else
                Email = email;
            try
            {
                MailAddress m = new MailAddress(email); 
            }
            catch (FormatException)
            {
                throw new FormatException(email + " is invalid");
            }
            
        }
        public bool IsValid()
        {
            if (this.Id == null) throw new ArgumentNullException();
            if (this.Email == null) throw new ArgumentNullException();
            if (this.Email == "") throw new FormatException();
            if (this.LastLoginDTTM == null) throw new ArgumentNullException();
            if (this.RegisterDTTM == null) throw new ArgumentNullException();
            return true;
        }
    }
}