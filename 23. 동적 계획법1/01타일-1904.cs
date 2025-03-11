class Tile01{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

    public static void tile01(string[] args)
    {
        string? N = sr.ReadLine();
        if (N == null)
        {
            return;
        }

        int Nint = int.Parse(N);
        List<int> list_01 = new List<int> ();
        list_01.Add(0);
        for (int i = 1; i <= Nint; i++)
        {
            if (i <= 2)
            {
                list_01.Add(i);
            }
            else
            {
                int tmp = list_01[i - 1] + list_01[i - 2];
                tmp = tmp % 15746;
                list_01.Add(tmp);
            }
        }
        sw.WriteLine(list_01[Nint]);

        sr.Close();
        sw.Close();
    }
}
