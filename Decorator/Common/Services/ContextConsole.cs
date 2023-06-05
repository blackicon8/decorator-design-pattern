namespace decorator.Common.Services
{
    public static class ContextConsole
    {
        public static void WriteSeparator(string title)
        {
            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine(title);
            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void WriteNumberOf<T>(IList<T> list)
        {
            Console.WriteLine($"Number of people: {list.Count}");
        }
    }
}
