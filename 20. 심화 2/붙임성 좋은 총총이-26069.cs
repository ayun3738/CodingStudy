using System.IO;
using System.Runtime.InteropServices;

class ChongChong{
    public static void chongChong(string[] args)
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string? T = sr.ReadLine();        
        if (T == null)
        {
            return;
        }
        HashSet<string> rainbows = new HashSet<string>();
        rainbows.Add("ChongChong");
        for (int i=0; i<int.Parse(T); i++)
        {
            string? S = sr.ReadLine();
            if (S == null)
            {
                return;
            }
            List<string> SList = S.Split(' ').ToList();
            if (rainbows.Contains(SList[0]))
            {
                rainbows.Add(SList[1]);
            }
            else if (rainbows.Contains(SList[1]))
            {
                rainbows.Add(SList[0]);
            }
        }
        sw.WriteLine(rainbows.Count);

        sr.Close();
        sw.Close();
    }
}