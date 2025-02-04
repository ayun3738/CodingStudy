using System.IO;

class PocketMonsterMaster{
    public static void pocketMonsterMaster(string[] args)
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        
        string? NM = sr.ReadLine();
        if (NM == null)
        {
            return;
        }
        List<int> NMList = NM.Split(' ').Select(int.Parse).ToList();
        Dictionary<string, int> name2index = new Dictionary<string, int>();
        Dictionary<int, string> index2name = new Dictionary<int, string>();
        for (int i = 0; i < NMList[0]; i++)
        {
            string? nameStr = sr.ReadLine();
            if (nameStr == null)
            {
                return;
            }
            name2index[nameStr] = i;
            index2name[i] = nameStr;
        }

        for (int i=0; i<NMList[1]; i++)
        {
            string? target = sr.ReadLine();
            if (target == null)
            {
                return;
            }
            if (int.TryParse(target, out int index))
            {
                sw.WriteLine(index2name[index-1]);
            }
            else
            {
                sw.WriteLine(name2index[target]+1);
            }
        }

        sr.Close();
        sw.Close();
    }
}