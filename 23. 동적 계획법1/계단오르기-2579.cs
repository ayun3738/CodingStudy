class UpStairs{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

    public static void upstairs(string[] args)
    {
        string? N = sr.ReadLine();
        if (N == null)
        {
            return;
        }
        int Nint = int.Parse(N);
        int[,] sum_list = new int[Nint + 1, 2];
        string? number = sr.ReadLine();
        if (number == null)
        {
            return;
        }
        sum_list[1,0] = int.Parse(number);
        sum_list[1,1] = int.Parse(number);
        for (int i = 2; i <= Nint; i++)
        {
            string? numbers = sr.ReadLine();
            if (numbers == null)
            {
                return;
            }
            
            int numbersInt = int.Parse(numbers);
            sum_list[i,0] = Math.Max(sum_list[i-2,0], sum_list[i-2,1]) + numbersInt;
            sum_list[i,1] = sum_list[i-1,0] + numbersInt;
            // sw.WriteLine(sum_list[i,0] + " " + sum_list[i,1] );
        }

        int result = Math.Max(sum_list[Nint,0], sum_list[Nint,1]);
        sw.WriteLine(result);

        sr.Close();
        sw.Close();
    }
}
