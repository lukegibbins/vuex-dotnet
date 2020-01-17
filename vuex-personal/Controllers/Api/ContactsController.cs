using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vuex_personal.Interfaces;
using vuex_personal.Models;

namespace vuex_personal.Controllers.ApiControllers
{
  public class ContactsController : Controller
  {
    private IFirebaseService _firebaseService;

    public ContactsController(IFirebaseService firebaseService)
    {
      _firebaseService = firebaseService;
    }

    [HttpGet]
    public IActionResult GetContacts()
    {
      var data = _firebaseService.GetContacts();
      return Ok(data);
    }

    [HttpPost]
    public IActionResult InsertOrUpdateContacts([FromBody] List<ContactViewModel> contactData)
    {
      _firebaseService.InsertOrUpdateContacts(contactData);
      return Ok();
    }
  }
}


