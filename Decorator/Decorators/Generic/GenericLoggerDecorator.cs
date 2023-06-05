using decorator.Common.Interfaces;
using decorator.Common.Models;

namespace decorator.Decorators.Generic
{
    public class GenericLoggerDecorator<T> : GenericDecoratorBase<T> where T : IRepository, new()
    {
        public GenericLoggerDecorator()
        { }

        public string GenericLoggerDecoratorProperty { get; set; }

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
