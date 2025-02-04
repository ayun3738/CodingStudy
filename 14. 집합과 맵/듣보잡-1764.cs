using System.IO;

class NotHeardAndNotSeen{
    public static void notHeardAndNotSeen(string[] args)
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        
        string? NM = sr.ReadLine();
        if (NM == null)
        {
            return;
        }
        List<int> NMList = NM.Split(' ').Select(int.Parse).ToList();
        HashSet<string> notHeard = new HashSet<string>();
        HashSet<string> notSeen = new HashSet<string>();
        for (int i = 0; i < NMList[0]; i++)
        {
            string? name = sr.ReadLine();
            if (name == null)
            {
                return;
            }
            notHeard.Add(name);
        }
        for (int i = 0; i < NMList[1]; i++)
        {
            string? name = sr.ReadLine();
            if (name == null)
            {
                return;
            }
            notSeen.Add(name);
        }
        List<string> result = notHeard.Intersect(notSeen).ToList();
        result.Sort();
        sw.WriteLine(result.Count);
        foreach (string name in result)
        {
            sw.WriteLine(name);
        }
        
        sr.Close();
        sw.Close();
    }
}