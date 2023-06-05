using decorator.Common.Interfaces;
using decorator.Common.Models;
using decorator.Common.Policies.Retry;

namespace decorator.Decorators.Generic
{
    public class GenericRetryDecorator<T> : GenericDecoratorBase<T> where T : IRepository, new()
    {
        public GenericRetryDecorator()
        { }

        public string GenericRetryDecoratorProperty { get; set; }

        public override IList<Person> GetAll()
        {
            return RetryPolicy.Apply(
                () => _innerRepository.GetAll());
        }

        public override Person Delete(long id)
        {
            return RetryPolicy.Apply(
                () => _innerRepository.Delete(id));
        }
    }
}
