class MakeOne{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

    public static void makeone(string[] args)
    {
        string? N = sr.ReadLine();
        if (N == null)
        {
            return;
        }
        int Nint = int.Parse(N);
        int[] count_list = new int[Nint + 1];
        for (int i = 1; i <= Nint; i++)
        {
            count_list[i] = i - 1;
        }
        for (int i = 1; i < Nint; i++)
        {
            if (i * 3 <= Nint)
            {
                count_list[i * 3] = Math.Min(count_list[i] + 1, count_list[i * 3]);
            }
            if (i * 2 <= Nint)
            {
                count_list[i * 2] = Math.Min(count_list[i] + 1, count_list[i * 2]);
            }
            count_list[i + 1] = Math.Min(count_list[i] + 1, count_list[i + 1]);
        }

        sw.WriteLine(count_list[Nint]);

        sr.Close();
        sw.Close();
    }
}
