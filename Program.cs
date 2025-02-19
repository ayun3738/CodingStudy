class Tmp{
    private static long Factorial(long n)
    {
        if(n <= 1)
        {
            return 1;
        }
        return n * Factorial(n - 1);
    }

    public static void Main(string[] args)
    {
        string? N = Console.ReadLine();        
        if (N == null)
        {
            return;
        }
        Console.WriteLine(Factorial(long.Parse(N)));
    }
}