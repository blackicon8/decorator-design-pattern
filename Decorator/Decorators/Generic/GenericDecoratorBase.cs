using decorator.Common.Interfaces;
using decorator.Common.Models;

namespace decorator.Decorators.Generic
{
    public abstract class GenericDecoratorBase<T> : IRepository where T : IRepository, new()
    {
        protected T _innerRepository = new T();

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
