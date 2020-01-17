
namespace vuex_personal.Models
{
  public class ContactViewModel
  {
    public string firstName { get; set; }
    public string surname { get; set; }
    public string age { get; set; }
    public string gender { get; set; }
    public bool isEditable { get; set; }

    public ContactViewModel(string Firstname, string Surname, string Age, string Gender)
    {
      firstName = Firstname;
      surname = Surname;
      age = Age;
      gender = Gender;
      isEditable = false;
    }
  }
}
