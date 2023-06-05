using decorator.Common.Interfaces;
using decorator.Common.Models;

namespace decorator.Decorators.Classic
{
    public abstract class ClassicDecoratorBase : IRepository
    {
        protected IRepository _innerRepository;

        public ClassicDecoratorBase(IRepository repository)
        {
            _innerRepository = repository;
        }

        public string RepositoryInterfaceProperty { get; set; }

        public virtual IList<Person> GetAll()
        {
            return _innerRepository.GetAll();
        }
        public virtual Person Delete(long id)
        {
            return _innerRepository.Delete(id);
        }
    }
}
