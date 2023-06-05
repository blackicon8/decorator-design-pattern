using decorator.Common.Interfaces;
using decorator.Common.Models;
using Microsoft.Extensions.Caching.Memory;

namespace decorator.Decorators.Generic
{
    public class GenericCacheDecorator<T> : GenericDecoratorBase<T> where T : IRepository, new()
    {
        private const string CacheKey = "People";
        private readonly IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());

        public GenericCacheDecorator()
        { }
  
        public string GenericCacheDecoratorProperty { get; set; }

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

            result = _innerRepository.GetAll();

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
