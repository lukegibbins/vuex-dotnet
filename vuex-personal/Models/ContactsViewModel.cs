
namespace vuex_personal.Models
{
  public class ContactsViewModel
  {
    public string firstName { get; set; }
    public string surname { get; set; }
    public int age { get; set; }
    public string gender { get; set; }

    public ContactsViewModel(string Firstname, string Surname, int Age, string Gender)
    {
      firstName = Firstname;
      surname = Surname;
      age = Age;
      gender = Gender;
    }
  }
}
