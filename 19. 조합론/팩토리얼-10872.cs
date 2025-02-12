using System.IO;

class Factorial{
    public static void factorial(string[] args)
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string? N = sr.ReadLine();        
        if (N == null)
        {
            return;
        }
        int Nint = int.Parse(N);
        int result = 1;
        for (int i = 1; i < Nint+1; i++)
        {
            result *= i;
        }
        sw.WriteLine(result);

        sr.Close();
        sw.Close();
    }
}