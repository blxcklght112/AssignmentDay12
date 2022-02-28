using Day7.Models;

namespace Day7.Services
{
    public interface IRookiesService
    {
        List<PersonModel> GetAllPeople();

        PersonModel GetPersonById(int id);

        void AddPerson(PersonModel person);

        void EditPerson(PersonModel person);
        
        void DeletePerson(int id);
    }
}