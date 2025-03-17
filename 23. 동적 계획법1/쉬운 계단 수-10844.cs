class EasyStairsNumber{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

    public static void easyStairsNumber(string[] args)
    {
        string? N = sr.ReadLine();
        if (N == null)
        {
            return;
        }
        int Nint = int.Parse(N);
        long[] count_list = new long[10];
        for (int i = 1; i < 10; i++)
        {
            count_list[i] = 1;
        }
        for (int i = 1; i < Nint; i++)
        {
            long[] tmp = new long[10];
            tmp[0] = count_list[1];
            tmp[9] = count_list[8];
            for (int j = 1; j < 9; j++)
            {
                tmp[j] = count_list[j - 1] + count_list[j + 1];
            }
            for (int j = 0; j < 10; j++)
            {
                count_list[j] = tmp[j] % 1000000000;
            }
        }

        sw.WriteLine(count_list.Sum() % 1000000000);

        sr.Close();
        sw.Close();
    }
}
