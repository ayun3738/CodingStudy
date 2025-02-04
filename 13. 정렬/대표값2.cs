class RepresentativeValue2{
    public static void representativeValue2(string[] args)
    {
        List<int> nums = new List<int>();
        for (int i =0; i<5; i++)
        {
            string? input = Console.ReadLine();
            if (input == null)
            {
                return;
            }
            nums.Add(int.Parse(input));
        }
        nums.Sort();
        Console.WriteLine(nums.Sum() / 5);
        Console.WriteLine(nums[2]);
        
        }
}

