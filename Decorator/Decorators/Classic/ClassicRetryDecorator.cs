using decorator.Common.Interfaces;
using decorator.Common.Models;
using decorator.Common.Policies.Retry;

namespace decorator.Decorators.Classic
{
    public class ClassicRetryDecorator : ClassicDecoratorBase
    {
        public ClassicRetryDecorator(IRepository repository) : base(repository) 
        { }

        public string ClassicRetryDecoratorProperty { get; set; }

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
