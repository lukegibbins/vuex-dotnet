
namespace vuex_personal.Models
{
  public class ContactsViewModel
  {
    public string firstName { get; set; }
    public string surname { get; set; }
    public int age { get; set; }
    public string gender { get; set; }
    public bool isEditable { get; set; } = false;

    public ContactsViewModel(string Firstname, string Surname, int Age, string Gender, bool IsEditable = false)
    {
      firstName = Firstname;
      surname = Surname;
      age = Age;
      gender = Gender;
      isEditable = IsEditable;
    }
  }
}
