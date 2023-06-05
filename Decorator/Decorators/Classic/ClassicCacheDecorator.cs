using decorator.Common.Interfaces;
using decorator.Common.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace decorator.Decorators.Classic
{
    public class ClassicCacheDecorator : ClassicDecoratorBase
    {
        private const string CacheKey = "People";
        private readonly IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());

        public ClassicCacheDecorator(IRepository repository) : base(repository)
        { }

        public string ClassicCacheDecoratorProperty { get; set; }

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
