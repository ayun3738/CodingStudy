class Triangle{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

    public static void triangle(string[] args)
    {
        string? N = sr.ReadLine();
        if (N == null)
        {
            return;
        }
        int Nint = int.Parse(N);
        long[] sum_list = new long[Nint + 1];
        for (int i = 1; i <= Nint; i++)
        {
            string? numbers = sr.ReadLine();
            if (numbers == null)
            {
                return;
            }
            long[] numbers_list = numbers.Split(' ').Select(long.Parse).ToArray();
            for (int j = i-1; j >= 0; j--)
            {
                sum_list[j+1] = Math.Max(sum_list[j] + numbers_list[j], sum_list[j+1] + numbers_list[j]);
            }
            // for (int j = 0; j < Nint; j++)
            // {
            //     sw.Write(sum_list[j] + " ");
            // }
            // sw.WriteLine();
        }
            
        sw.WriteLine(sum_list.Max());

        sr.Close();
        sw.Close();
    }
}
