using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcContacts.Models;

//using MvcContacts.Models;

namespace MvcContacts.Tests.Models
{
    //class InMemoryContactRepository : IContactRepository
    class InMemoryContactRepository : MvcContacts.Models.IContactRepository
    {
        private List<Contact> _db = new List<Contact>();

        public Exception ExceptionToThrow { get; set; }
        //public List<Contact> Items { get; set; }

        public void SaveChanges(Contact contactToUpdate)
        {

            foreach (Contact contact in _db)
            {
                if (contact.Id == contactToUpdate.Id)
                {
                    _db.Remove(contact);
                    _db.Add(contactToUpdate);
                    break;
                }
            }
        }

        public void Add(Contact contactToAdd)
        {
            _db.Add(contactToAdd);
        }

        //MvcContacts.Models.Contact IContactRepository.GetContactByID(int id);

        public Contact GetContactByID(int id)
        {
            return _db.FirstOrDefault(d => d.Id == id);
        }

        public void CreateNewContact(Contact contactToCreate)
        {
            if (ExceptionToThrow != null)
                throw ExceptionToThrow;

            _db.Add(contactToCreate);
            // return contactToCreate;
        }

        public int SaveChanges()
        {
            return 1;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _db.ToList();
        }


        public void DeleteContact(int id)
        {
            _db.Remove(GetContactByID(id));
        }

        //métodos gerados para corrigir erro
        IEnumerable<MvcContacts.Models.Contact> IContactRepository.GetAllContacts()
        {
            //return _db.ToList();
            throw new NotImplementedException();
        }

        public string ListContacts()
        {
            //return _db.ToList();
            throw new NotImplementedException();
        }

        MvcContacts.Models.Contact IContactRepository.GetContactByID(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateNewContact(MvcContacts.Models.Contact contactToCreate)
        {
            throw new NotImplementedException();
        }

    }
}