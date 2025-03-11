class Tmp{
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

    public static void Main(string[] args)
    {
        string? N = sr.ReadLine();
        if (N == null)
        {
            return;
        }

        string? numbers = sr.ReadLine();
        if (numbers == null)
        {
            return;
        }
        
        List<long> sum_list = new List<long> ();
        bool positive = false;
        long sum_value = 0;
        long result = -1001;
        foreach (string number in numbers.Split(' '))
        {
            long tmp = long.Parse(number);
            if (tmp < 0 && positive)
            {
                sum_list.Add(sum_value);
                result = Math.Max(result, sum_value);
                sum_value = 0;
                positive = false;
            }
            else if (tmp >= 0 && !positive)
            {
                sum_list.Add(sum_value);
                sum_value = 0;
                positive = true;
            }
            sum_value += tmp;
            result = Math.Max(result, tmp);
        }
        sum_list.Add(sum_value);
        for (int s = 0; s < sum_list.Count; s++)
        {
            for (int e = s + 1; e < sum_list.Count; e++)
            {
                result = Math.Max(result, sum_list[s..e].Sum());
            }
        }

        sw.WriteLine(result);

        sr.Close();
        sw.Close();
    }
}
