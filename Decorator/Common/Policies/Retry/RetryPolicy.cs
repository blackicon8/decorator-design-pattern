using Polly;

namespace decorator.Common.Policies.Retry
{
    public class RetryPolicy
    {
        public static T Apply<T>(Func<T> func, int retryAttempt = 10)
        {
            var retryPolicy =
                Policy
                .Handle<Exception>()
                .Retry(retryAttempt, (exception, retryCount, context) =>
                {
                    Console.WriteLine(
                        "Operation failed. Retry attempt: {0}", retryCount);
                });

            return retryPolicy.Execute(
                () => func());
        }
    }
}
