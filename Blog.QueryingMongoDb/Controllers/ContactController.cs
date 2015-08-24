using System;
using System.Web.Mvc;
using Blog.QueryingMongoDb.Models;
using Blog.QueryingMongoDb.Models.Repository;

namespace Blog.QueryingMongoDb.Controllers
{
    public class ContactController : Controller
    {
        //Private instance of contact collection
        private ContactCollection _contacts = new ContactCollection();
        //
        // GET: /ContactUs/

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContactModel contact)
        {
            this._contacts.InsertContact(contact);
            return RedirectToAction("List", _contacts.SelectAll());
        }

        public ActionResult List()
        {

            return View(
                _contacts.SelectAll());
        }

        public ActionResult Edit(string contactId)
        {
            return View(_contacts.Get(contactId));
        }

        [HttpPost]
        public ActionResult Edit(string Id, ContactModel contact)
        {
            this._contacts.UpdateContact(Id, contact);

            return RedirectToAction("List",
                 _contacts.SelectAll());
        }


    }
}
