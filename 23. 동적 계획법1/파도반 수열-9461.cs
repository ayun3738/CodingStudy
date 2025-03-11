class Padovan_Sequence{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

    private static long padovan(int N, List<long> list_padovan)
    {
        int cnt = list_padovan.Count;
        while(cnt <= N)
        {
            long tmp = list_padovan[cnt - 1] + list_padovan[cnt - 5];
            list_padovan.Add(tmp);
            cnt++;
        }
        
        return list_padovan[N];
    }

    public static void padovan_sequence(string[] args)
    {
        string? T = sr.ReadLine();
        if (T == null)
        {
            return;
        }

        List<long> list_padovan = new List<long> ();
        list_padovan.Add(0);
        list_padovan.Add(1);
        list_padovan.Add(1);
        list_padovan.Add(1);
        list_padovan.Add(2);

        for (int i = 0; i < int.Parse(T); i++)
        {
            string? N = sr.ReadLine();
            if (N == null)
            {
                return;
            }
            sw.WriteLine(padovan(int.Parse(N), list_padovan));
        }

        sr.Close();
        sw.Close();
    }
}
