using System.IO;
using System.Runtime.InteropServices;

class Statistics{
    public static void statistics(string[] args)
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string? T = sr.ReadLine();        
        if (T == null)
        {
            return;
        }
        List<int> DataCount = Enumerable.Repeat(0, 8001).ToList();
        for (int i = 0; i < int.Parse(T); i++)
        {
            string? N = sr.ReadLine();        
            if (N == null)
            {
                return;
            }
            DataCount[int.Parse(N) + 4000]++;
        }
        int mean = 0;
        var median = 0;
        bool median_flag = false;
        var max_freq = 1;
        List<int> freqList = new List<int>();
        int cnt = 0;
        int min_v = 4000;
        bool min_flag = false;
        int max_v = -4000;

        for (int i = 0; i < 8001; i++)
        {
            if (DataCount[i] > 0)
            {
                var tmp = i - 4000;
                if (min_flag == false)
                {
                    min_v = tmp;
                    min_flag = true;
                }
                max_v = tmp;
                mean += tmp * DataCount[i];
                cnt += DataCount[i];
                if (cnt > int.Parse(T) / 2 && median_flag == false)
                {
                    median_flag = true;
                    median = tmp;
                }
                if (DataCount[i] > max_freq)
                {
                    max_freq = DataCount[i];
                    freqList.Clear();
                    freqList.Add(tmp);
                }
                else if (DataCount[i] == max_freq)
                {
                    freqList.Add(tmp);
                }
            }
        }
        mean = (int)Math.Round(mean/ double.Parse(T));
        sw.WriteLine(mean);
        sw.WriteLine(median);
        sw.WriteLine(freqList.Count == 1 ? freqList[0] : freqList[1]);
        sw.WriteLine(max_v - min_v);

        sr.Close();
        sw.Close();
    }
}