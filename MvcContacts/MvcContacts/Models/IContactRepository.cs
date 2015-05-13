using System;
using System.Collections.Generic;

namespace MvcContacts.Models
{
    public interface IContactRepository
    {
        void CreateNewContact(Contact contactToCreate);
        void DeleteContact(int id);
        Contact GetContactByID(int id);
        IEnumerable<MvcContacts.Models.Contact> GetAllContacts();
        int SaveChanges();
        //gerado para corrigir erro
        string ListContacts();
    }
}