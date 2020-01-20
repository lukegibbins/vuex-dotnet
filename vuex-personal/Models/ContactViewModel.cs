
using System.Collections.Generic;

namespace vuex_personal.Models
{
  public class ContactViewModel
  {
    public string firstName { get; set; }
    public string surname { get; set; }
    public string age { get; set; }
    public string gender { get; set; }
    public bool isEditable { get; set; }
    public List<string> projects {get; set; }

    public ContactViewModel(string Firstname, string Surname, string Age, string Gender, List<string> Projects)
    {
      firstName = Firstname;
      surname = Surname;
      age = Age;
      gender = Gender;
      isEditable = false;
      projects = Projects;
    }
  }
}
