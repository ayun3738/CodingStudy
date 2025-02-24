class NM1{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
    
    private static void Permutation(HashSet<int> nset, int n, int k, string result)
    {
        for (int i = 1; i < n+1; i++)
        {
            if (nset.Contains(i))
            {
                continue;
            }
            if (k == 1)
            {
                sw.WriteLine(result + i);
            }
            else
            {
                nset.Add(i);
                Permutation(nset, n, k - 1, result + i + " ");
                nset.Remove(i);
            }
        }
    }

    public static void nm1(string[] args)
    {
        
        string? NM = sr.ReadLine();
        if (NM == null)
        {
            return;
        }
        List<int> NMList = NM.Split(' ').Select(x => int.Parse(x)).ToList();
        HashSet<int> NSet = new HashSet<int>();
        Permutation(NSet, NMList[0], NMList[1], "");
        
        sr.Close();
        sw.Close();

    }
}
