using Day7.Enum;
using Day7.Models;

namespace Day7.Data
{
    public static class RookiesData
    {
        public static List<PersonModel> People = new List<PersonModel>
        {
            new PersonModel{
                ID = 1,
                FirstName = "Loc",
                LastName = "Pham Duc",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(1999,01,12),
                PhoneNumber = "0343428821",
                BirthPlace = "Ha Noi",
                IsGraduated = "Yes"
                },
            new PersonModel{
                ID = 2,
                FirstName = "Loc 2",
                LastName = "Pham Duc",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2000,01,12),
                PhoneNumber = "0343428821",
                BirthPlace = "Ha Noi",
                IsGraduated = "No"
            },
            new PersonModel{
                ID = 3,
                FirstName = "An",
                LastName = "Nguyen Hai",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(1989,12,03),
                PhoneNumber = "0343428821",
                BirthPlace = "Thai Nguyen",
                IsGraduated = "No"
            },
            new PersonModel{
                ID = 4,
                FirstName = "An 2",
                LastName = "Nguyen Hai",
                Gender = Gender.Other,
                DateOfBirth = new DateTime(1989,12,03),
                PhoneNumber = "0343428821",
                BirthPlace = "Thai Nguyen",
                IsGraduated = "Yes"
            },
            new PersonModel{
                ID = 5,
                FirstName = "Nhung",
                LastName = "Nguyen Hong",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(2004,08,08),
                PhoneNumber = "0343428821",
                BirthPlace = "Thai Binh",
                IsGraduated = "No"
            },
        };
    }
}