using System.IO;

class NumberCard2{
    public static void numberCard2(string[] args)
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        
        string? N = sr.ReadLine();
        Dictionary<int, int> cardDict = new Dictionary<int, int>();
        string? cardStr = sr.ReadLine();
        if (cardStr == null)
        {
            return;
        }
        List<int> cardList = cardStr.Split(' ').Select(int.Parse).ToList();
        foreach (int card in cardList)
        {
            if (cardDict.ContainsKey(card))
            {
                cardDict[card]++;
            }
            else
            {
                cardDict[card] = 1;
            }

        }

        string? M = sr.ReadLine();
        string? targetsStr = sr.ReadLine();
        if (targetsStr == null)
        {
            return;
        }
        List<int> targets = targetsStr.Split(' ').Select(int.Parse).ToList();
        foreach (int target in targets)
        {
            if (cardDict.ContainsKey(target))
            {
                sw.Write(cardDict[target]);
            }
            else
            {
                sw.Write(0);
            }
            sw.Write(' ');
        }
        
        sr.Close();
        sw.Close();
    }
}