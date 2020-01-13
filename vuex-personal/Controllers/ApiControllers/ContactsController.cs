using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vuex_personal.Models;

namespace vuex_personal.Controllers.ApiControllers
{
  public class ContactsController : Controller
  {
    public IActionResult GetContacts()
    {
      var data = GenerateContactData();
      return Ok(data);
    }

    private List<ContactsViewModel> GenerateContactData()
    {
      List<ContactsViewModel> contacts = new List<ContactsViewModel>();

      contacts.Add(new ContactsViewModel("Luke", "Gibbins", 25, "Male"));
      contacts.Add(new ContactsViewModel("John", "Smith", 45, "Male"));
      contacts.Add(new ContactsViewModel("Harry", "Potter", 17, "Male"));
      contacts.Add(new ContactsViewModel("Dot", "Cotton", 18, "Female"));
      contacts.Add(new ContactsViewModel("Joanne", "Bloggs", 29, "Female"));

      return contacts;
    }
  }
}


