using System.Collections.Generic;
using System.Threading.Tasks;
using vuex_personal.Models;

namespace vuex_personal.Interfaces
{
  public interface IFirebaseService
  {
    Task InsertOrUpdateContacts(List<ContactViewModel> contacts);
    List<ContactViewModel> GetContacts();
  }
}
