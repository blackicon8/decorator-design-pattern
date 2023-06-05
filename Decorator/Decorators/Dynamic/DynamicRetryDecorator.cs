using decorator.Common.Interfaces;
using decorator.Common.Models;
using decorator.Common.Policies.Retry;

namespace decorator.Decorators.Dynamic
{
    public class DynamicRetryDecorator : DynamicDecoratorBase, IRepository
    {
        public DynamicRetryDecorator(IRepository repository) : base(repository)
        { }

        public string DynamicRetryDecoratorProperty { get; set; }

        public override IList<Person> GetAll()
        {
            return RetryPolicy.Apply(
                () => base.GetAll());
        }

        public override Person Delete(long id)
        {
            return RetryPolicy.Apply(
                () => base.Delete(id));
        }
    }
}
