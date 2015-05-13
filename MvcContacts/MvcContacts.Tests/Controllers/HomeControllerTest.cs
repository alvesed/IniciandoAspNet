using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContacts.Controllers;

using MvcContacts.Models;
using MvcContacts.Tests.Models;
using System.Web;
using System.Web.Routing;
using System.Security.Principal;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MvcContacts.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        Contact GetContact()
        {
            return GetContact(1, "Janet", "Gates");
        }

        Contact GetContact(int id, string fName, string lName)
        {
            return new Contact
            {
                Id = id,
                FirstName = fName,
                LastName = lName,
                Phone = "710-555-0173",
                Email = "janet1@adventure-works.com"
            };
        }

        private static HomeController GetHomeController(IContactRepository repository)
        {
            HomeController controller = new HomeController(repository);

            controller.ControllerContext = new ControllerContext()
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };
            return controller;
        }


        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(
                     new GenericIdentity("someUser"), null /* roles */);

            public override IPrincipal User
            {
                get
                {
                    return _user;
                }
                set
                {
                    base.User = value;
                }
            }
        }

        [TestMethod]
        public void Index_Get_AsksForIndexView()
        {
            // Arrange
            var controller = GetHomeController(new InMemoryContactRepository());
            // Act
            ViewResult result = controller.Index();
            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }


        [TestMethod]
        public void Index_Get_RetrievesAllContactsFromRepository()
        {
            // Arrange
            Contact contact1 = GetContact(1, "Orlando", "Gee");
            Contact contact2 = GetContact(2, "Keith", "Harris");
            InMemoryContactRepository repository = new InMemoryContactRepository();
            repository.Add(contact1);
            repository.Add(contact2);
            var controller = GetHomeController(repository);

            // Act
            var result = controller.Index();

            // Assert
            var model = (IEnumerable<Contact>)result.ViewData.Model;
            CollectionAssert.Contains(model.ToList(), contact1);
            CollectionAssert.Contains(model.ToList(), contact1);
        }
        
    }
}