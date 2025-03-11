class Tmp{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

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
                sum_value = tmp;
                positive = false;
            }
            else if (tmp >= 0 && !positive)
            {
                sum_list.Add(sum_value);
                sum_value = tmp;
                positive = true;
            }
            else
            {
                sum_value += tmp;
                result = Math.Max(result, tmp);
            }
        }
        sum_list.Add(sum_value);
        // for (int i = 0; i < sum_list.Count; i++)
        // {
        //     Console.Write(sum_list[i]);
        //     Console.Write(" ");
        // }
        // Console.WriteLine();
        for (int s = 0; s < (sum_list.Count >> 1) - 1; s++)
        {
            long tmp_sum = sum_list[(s << 1) + 1];
            for (int e = s+1; e < (sum_list.Count >> 1); e++)
            {
                tmp_sum += sum_list[e << 1];
                if (tmp_sum < 0)
                {
                    // Console.WriteLine("break " + s + " " + e + " " + tmp_sum);
                    break;
                }
                tmp_sum += sum_list[(e << 1) + 1];
                result = Math.Max(result, tmp_sum);
                // sw.WriteLine(result + " " + s + " " + e + " " + tmp_sum);
            }
        }

        sw.WriteLine(result);

        sr.Close();
        sw.Close();
    }
}
