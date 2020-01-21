using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using vuex_personal.Interfaces;
using vuex_personal.Models;

namespace vuex_personal.Services
{
  public class FirebaseService: IFirebaseService
  {
    IFirebaseClient client;
    IFirebaseConfig config = new FirebaseConfig()
    {
      AuthSecret = "RGEVKFH5XCflUf5CgIpLs6ljgc1v39Dt7SvZKmq4",
      BasePath = "https://vuex-225ab.firebaseio.com"
    };

    public FirebaseService()
    {
      client = new FirebaseClient(config);
    }

    public List<ContactViewModel> GetContacts()
    {
      var result = client.Get("/contacts");
      var contacts = result.ResultAs<List<ContactViewModel>>();      
      return contacts ?? new List<ContactViewModel>();
    }

    public async Task InsertOrUpdateContacts(List<ContactViewModel> contacts)
    {
      foreach (var contact in contacts)
        contact.isEditable = false;

      await client.SetAsync("/contacts", contacts);
    }
  }
}
