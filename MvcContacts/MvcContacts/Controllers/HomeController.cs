using System;
using System.Web.Mvc;
using MvcContacts.Models;

namespace MvcContacts.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        //IContactRepository _repository;
        EF_ContactRepository _EF_ContactRepository;

        public HomeController() : this(new EF_ContactRepository()) { }
        //public HomeController(IContactRepository repository)
        //{
            //_repository = repository;
        //}
        public HomeController(MvcContacts.Models.IContactRepository repository)
        {
            _EF_ContactRepository = repository;
        }
        /*public ViewResult Index()
        {
            throw new NotImplementedException();
        }*/
        public ViewResult Index()
        {
            //return View("Index", _repository.ListContacts());
            //código substituido para corrigir erro de teste
            return View("Index", _EF_ContactRepository.GetAllContacts());


        }

    }
}