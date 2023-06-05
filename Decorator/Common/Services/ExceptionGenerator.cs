namespace decorator.Common.Services
{
    public class ExceptionGenerator
    {
        public static void Run()
        {
            var rand = new Random();
            int number;

            do
            {
                number = rand.Next(0, 2);
                if (number == 1) { throw new Exception(); }
            } while (number == 1);
        }
    }
}
