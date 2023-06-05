using decorator.Common.Models;

namespace decorator.Common.Storage
{
    public class PeopleDataStore
    {
        public static IList<Person> People { get; set; } = new List<Person>()
        {
            new Person()
            {
                Id = 1,
                Name = "Cheryl Hahn",
                Date = DateTime.Now
            },
            new Person()
            {
                Id = 2,
                Name = "Emilio Holmes",
                Date = DateTime.Now
            },
            new Person()
            {
                Id = 3,
                Name = "Jannat Rojas",
                Date = DateTime.Now
            },
            new Person()
            {
                Id = 4,
                Name = "Allen Wells",
                Date = DateTime.Now
            }
        };
    }
}
