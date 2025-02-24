class NM3{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
    
    private static void Permutation(int s, int e, int k, string result)
    {
        for (int i = s; i < e + 1; i++)
        {
            if (k == 1)
            {
                sw.WriteLine(result + i);
            }
            else
            {
                Permutation(1, e,k - 1, result + i + " ");
            }
        }
    }

    public static void nm3(string[] args)
    {
        
        string? NM = sr.ReadLine();
        if (NM == null)
        {
            return;
        }
        List<int> NMList = NM.Split(' ').Select(x => int.Parse(x)).ToList();
        Permutation(1, NMList[0], NMList[1], "");
        
        sr.Close();
        sw.Close();

    }
}
