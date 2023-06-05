using decorator.Common.Interfaces;
using decorator.Common.Models;

namespace decorator.Decorators.Dynamic
{
    public class DynamicLoggerDecorator : DynamicDecoratorBase, IRepository
    {
        public DynamicLoggerDecorator(IRepository repository) : base(repository)
        { }

        public string DynamicLoggerDecoratorProperty { get; set; }

        public override IList<Person> GetAll()
        {
            Console.WriteLine("Repository service is getting people.");
            return _innerRepository.GetAll();
        }

        public override Person Delete(long id)
        {
            Console.WriteLine("Repository service is deleting a person.");
            return _innerRepository.Delete(id);
        }
    }
}
