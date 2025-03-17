class DrinkWine{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

    private static int calculate_max(int[] count_list)
    {
        int max = 0;
        foreach (int i in count_list)
        {
            if (i > max)
            {
                max = i;
            }
        }
        return max;
    }

    public static void drinkWine(string[] args)
    {
        string? N = sr.ReadLine();
        if (N == null)
        {
            return;
        }
        int Nint = int.Parse(N);
        int[] count_list = new int[3];
        for (int i = 0; i < Nint; i++)
        {
            string? drink = sr.ReadLine();
            if (drink == null)
            {
                return;
            }
            int drink_int = int.Parse(drink);
            int[] tmp = new int[3];
            tmp[0] = calculate_max(count_list);
            tmp[1] = count_list[0] + drink_int;
            tmp[2] = count_list[1] + drink_int;
            
            for (int j = 0; j < 3; j++)
            {
                count_list[j] = tmp[j];
            }
        }

        sw.WriteLine(calculate_max(count_list));

        sr.Close();
        sw.Close();
    }
}
