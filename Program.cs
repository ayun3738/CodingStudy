class Tmp{
    private static void Kan(int n)
    {
        if (n == 0)
        {
            Console.Write("-");
            return;
        }
        Kan(n - 1);
        Console.Write(Enumerable.Repeat(" ", (int)Math.Pow(3, n - 1)).Aggregate((a, b) => a + b));
        Kan(n - 1);
    }

    public static void Main(string[] args)
    {
        while (true)
        {
            string? N = Console.ReadLine();
            if (N == null)
            {
                return;
            }

            Kan(int.Parse(N));
            Console.Write("\n");
        }
    }
}


