using System.IO;

class BuildBridge{
    public static void buildBridge(string[] args)
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string? T = sr.ReadLine();        
        if (T == null)
        {
            return;
        }
        for (int i = 0; i < int.Parse(T); i++)
        {
            string? NM = sr.ReadLine();        
            if (NM == null)
            {
                return;
            }
            List<int> NMList = NM.Split(' ').Select(int.Parse).ToList();
            int result = 1;
            int dividor = 1;
            for (int j = NMList[1]; j > NMList[1]-NMList[0]; j--)
            {
                result *= j;
                while (dividor <= NMList[0] && result % dividor == 0)
                {
                    result /= dividor;
                    dividor++;
                }
            }
            sw.WriteLine(result);
        }

        sr.Close();
        sw.Close();
    }
}