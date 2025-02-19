class Fibonacci5{
    public static void fibonacci5(string[] args)
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string? N = sr.ReadLine();        
        if (N == null)
        {
            return;
        }
        sw.WriteLine(Fibonacci(int.Parse(N)));

        sr.Close();
        sw.Close();
    }

    private static int Fibonacci(int n)
    {
        if (n < 2)
        {
            return n;
        }
        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}