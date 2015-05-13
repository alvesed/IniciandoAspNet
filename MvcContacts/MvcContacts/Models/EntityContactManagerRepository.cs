using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcContacts.Models
{
    public class EF_ContactRepository : IContactRepository
    {

        //private ContactEntities _db = new ContactEntities();
        //código substituido para corrigir erro
        private List<Contact> _db = new List<Contact>();


        public Contact GetContactByID(int id)
        {
            //return _db.Contacts.FirstOrDefault(d => d.Id == id);
            //código substituido para corrigir erro
            return _db.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            //return _db.Contacts.ToList();
            //código substituido para corrigir erro
            return _db.ToList();
        }

        public void CreateNewContact(Contact contactToCreate)
        {
            //_db.AddToContacts(contactToCreate);
            //código substituido para corrigir erro
            _db.Add(contactToCreate);
            //_db.SaveChanges();
            //código inibido para corrigir erro
            //   return contactToCreate;
        }

        public int SaveChanges()
        {
            //return _db.SaveChanges();
            //código substituido para corrigir erro
            return 1;
        }

        public void DeleteContact(int id)
        {
            var conToDel = GetContactByID(id);
            //_db.Contacts.DeleteObject(conToDel);
            //código substituido para corrigir erro
            _db.Remove(conToDel);
            //_db.SaveChanges();
            //código inibido para corrigir erro
        }


        //gerado para corrigir erro
        public string ListContacts()
        {
            throw new NotImplementedException();
        }
    }
}