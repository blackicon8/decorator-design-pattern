using decorator.Common.Models;

namespace decorator.Common.Interfaces
{
    public interface IRepository
    {
        public string RepositoryInterfaceProperty { get; set; }
        public IList<Person> GetAll();
        public Person Delete(long id);
    }
}
