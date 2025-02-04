using System.IO;

class DoubleDifference{
    public static void doubleDifference(string[] args)
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        
        string? NM = sr.ReadLine();
        string? N = sr.ReadLine();
        string? M = sr.ReadLine();
        if (N == null || M == null)
        {
            return;
        }
        HashSet<int> NList = N.Split(' ').Select(int.Parse).ToHashSet();
        HashSet<int> MList = M.Split(' ').Select(int.Parse).ToHashSet();
        int result = NList.Count() + MList.Count() - 2 * NList.Intersect(MList).Count();
        sw.WriteLine(result);

        sr.Close();
        sw.Close();
    }
}