using decorator.Common.Services;
using decorator.Decorators.Classic;
using decorator.Decorators.Dynamic;
using decorator.Decorators.Generic;

// Classic
// ===========================================================

ContextConsole.WriteSeparator("Classic decorator");

var classicRepository = new ClassicRetryDecorator(
                          new ClassicLoggerDecorator(
                            new ClassicCacheDecorator(
                              new PersonRepository())));

var people = classicRepository.GetAll();
ContextConsole.WriteNumberOf(people);

people = classicRepository.GetAll();
ContextConsole.WriteNumberOf(people);

classicRepository.Delete(1);
ContextConsole.WriteNumberOf(people);

classicRepository.RepositoryInterfaceProperty = "Base";
classicRepository.ClassicRetryDecoratorProperty = "Retry";

// Not allowed:
// classicRepository.ClassicLoggerDecoratorProperty = "Logger";
// classicRepository.ClassicCacheDecoratorProperty = "Cache";

// Generic
// ===========================================================

ContextConsole.WriteSeparator("Generic decorator");

var genericRepository = new GenericRetryDecorator<
                          GenericLoggerDecorator<
                            GenericCacheDecorator<
                              PersonRepository>>>();

genericRepository.GetAll();
ContextConsole.WriteNumberOf(people);

genericRepository.GetAll();
ContextConsole.WriteNumberOf(people);

genericRepository.Delete(2);
ContextConsole.WriteNumberOf(people);

genericRepository.RepositoryInterfaceProperty = "Base";
genericRepository.GenericRetryDecoratorProperty = "Retry";

// Not allowed:
// genericRepository.GenericLoggerDecoratorProperty = "Logger";
// genericRepository.GenericCacheDecoratorProperty = "Cache";

// Dynamic
// ===========================================================

ContextConsole.WriteSeparator("Dynamic decorator");

dynamic dynamicRepository = new DynamicRetryDecorator(
                              new DynamicLoggerDecorator(
                                new DynamicCacheDecorator(
                                  new PersonRepository())));

dynamicRepository.GetAll();
ContextConsole.WriteNumberOf(people);

dynamicRepository.GetAll();
ContextConsole.WriteNumberOf(people);

dynamicRepository.Delete(3);
ContextConsole.WriteNumberOf(people);

dynamicRepository.RepositoryInterfaceProperty = "Base";
dynamicRepository.DynamicRetryDecoratorProperty = "Retry";
dynamicRepository.DynamicLoggerDecoratorProperty = "Logger";
dynamicRepository.DynamicCacheDecoratorProperty = "Cache";