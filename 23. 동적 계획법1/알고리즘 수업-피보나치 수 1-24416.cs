class AlgorithmFibonacci1{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

    public static void algorithmFibonacci1(string[] args)
    {
        string? N = sr.ReadLine();
        if (N == null)
        {
            return;
        }
        int Nint = int.Parse(N);
        List<int> fin = new List<int>();
        fin.Add(1);
        fin.Add(1);
        for (int i=2; i < Nint; i++)
        {
            fin.Add(fin[i-1] + fin[i-2]);
        }
        sw.WriteLine(fin[Nint-1] + " " + (Nint-2));

        sr.Close();
        sw.Close();
    }
}
