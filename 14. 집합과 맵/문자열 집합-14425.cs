class StringSet{
    public static void stringset(string[] args)
    {
        string? NM = Console.ReadLine();
        if (NM == null)
        {
            return;
        }
        List<int> NMList = NM.Split(' ').Select(int.Parse).ToList();
        HashSet<string> cardSet = new HashSet<string>();
        for (int i = 0; i < NMList[0]; i++)
        {
            string? cardsStr = Console.ReadLine();
            if (cardsStr == null)
            {
                return;
            }
            cardSet.Add(cardsStr);
        }

        int result = 0;
        for (int i=0; i<NMList[1]; i++)
        {
            string? target = Console.ReadLine();
            if (target == null)
            {
                return;
            }
            if (cardSet.Contains(target))
            {
                result++;
            }
        }
        Console.WriteLine(result);
    }
}