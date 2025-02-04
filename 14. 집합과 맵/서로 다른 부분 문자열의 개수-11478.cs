using System.IO;

class SubStringCount{
    public static void subStringCount(string[] args)
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string? S = sr.ReadLine();        
        if (S == null)
        {
            return;
        }

        HashSet<string> result = new HashSet<string>();
        for (int i = 0; i < S.Length; i++)
        {
            for (int j = i + 1; j < S.Length+1; j++)
            {
                result.Add(S[i..j]);
            }
        }
        sw.WriteLine(result.Count);

        sr.Close();
        sw.Close();
    }
}