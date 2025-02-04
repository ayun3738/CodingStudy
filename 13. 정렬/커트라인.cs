class CutLine{
    public static void cutLine(string[] args)
    {
        string? NK = Console.ReadLine();
        if (NK == null)
        {
            return;
        }
        List<int> NKList = NK.Split(' ').Select(x => int.Parse(x)).ToList();
        string? input = Console.ReadLine();
        if (input == null)
        {
            return;
        }
        List<int> nums = input.Split(' ').Select(x => int.Parse(x)).ToList();
        nums.Sort();
        nums.Reverse();
        Console.WriteLine(nums[NKList[1]-1]);
        }
}

