using System.Text;

class NumberCard{
    public static void numbercard(string[] args)
    {
        string? N = Console.ReadLine();
        if (N == null)
        {
            return;
        }
        HashSet<int> cardSet = new HashSet<int>();
        string? cardsStr = Console.ReadLine();
        if (cardsStr == null)
        {
            return;
        }
        cardSet = cardsStr.Split(' ').Select(int.Parse).ToHashSet();
        
        string? M = Console.ReadLine();
        if (M == null)
        {
            return;
        }
        string? targetsStr = Console.ReadLine();
        if (targetsStr == null)
        {
            return;
        }
        List<int> targets = targetsStr.Split(' ').Select(int.Parse).ToList();
        
        StringBuilder result = new StringBuilder();
        foreach (int target in targets)
        {
            if (cardSet.Contains(target))
            {
                result.Append("1 ");
            }
            else
            {
                result.Append("0 ");
            }
        }
        Console.WriteLine(result);
    }
}