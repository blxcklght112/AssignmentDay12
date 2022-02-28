using Day7.Data;
using Day7.Models;

namespace Day7.Services
{
    public class RookiesService : IRookiesService
    {
        public void AddPerson(PersonModel person)
        {
            var maxId = RookiesData.People.Max(x => x.ID);
            person.ID = maxId + 1;
            RookiesData.People.Add(person);
        }

        public void DeletePerson(int id)
        {
            var deletePerson = RookiesData.People.FirstOrDefault(x => x.ID == id);
            if (deletePerson != null)
            {
                RookiesData.People.Remove(deletePerson);
            }
        }

        public void EditPerson(PersonModel person)
        {
            var editPerson = RookiesData.People.FirstOrDefault(x => x.ID == person.ID);
            if (editPerson != null)
            {
                editPerson.FirstName = person.FirstName;
                editPerson.LastName = person.LastName;
                editPerson.Gender = person.Gender;
                editPerson.DateOfBirth = person.DateOfBirth;
                editPerson.PhoneNumber = person.PhoneNumber;
                editPerson.BirthPlace = person.BirthPlace;
                editPerson.IsGraduated = person.IsGraduated;
            }
        }

        public PersonModel GetPersonById(int id)
        {
            return RookiesData.People.FirstOrDefault(x => x.ID == id);
        }

        public List<PersonModel> GetAllPeople()
        {
            return RookiesData.People;
        }
    }
}