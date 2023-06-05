using decorator.Common.Interfaces;
using decorator.Common.Models;
using Microsoft.Extensions.Caching.Memory;

namespace decorator.Decorators.Dynamic
{
    public class DynamicCacheDecorator : DynamicDecoratorBase, IRepository
    {
        private const string CacheKey = "People";
        private readonly IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());

        public DynamicCacheDecorator(IRepository repository) : base(repository)
        { }

        public string DynamicCacheDecoratorProperty { get; set; }

        public override IList<Person> GetAll()
        {
            var options = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));

            var isFromCache =
                _memoryCache.TryGetValue(CacheKey, out IList<Person> result);

            if (isFromCache)
            {
                Console.WriteLine("Getting people from cache.");
                return result;
            }

            result = base.GetAll();

            _memoryCache.Set(CacheKey, result, options);
            return result;
        }

        public override Person Delete(long id)
        {
            var deletedPerson = base.Delete(id);
            _memoryCache.Remove(CacheKey);
            return deletedPerson;
        }
    }
}
