using decorator.Common.Interfaces;
using decorator.Common.Models;
using decorator.Common.Storage;

namespace decorator.Common.Services
{
    internal class PersonRepository : IRepository
    {
        public string RepositoryInterfaceProperty { get; set; }

        public IList<Person> GetAll()
        {
            ExceptionGenerator.Run();
            return PeopleDataStore.People;
        }

        public Person Delete(long id)
        {
            ExceptionGenerator.Run();
            var person = PeopleDataStore.People.First(i => i.Id == id);
            PeopleDataStore.People.Remove(person);
            return person;
        }
    }
}
