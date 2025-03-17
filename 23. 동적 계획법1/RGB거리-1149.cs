class RGBroad{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

    public static void rgbroad(string[] args)
    {
        string? N = sr.ReadLine();
        if (N == null)
        {
            return;
        }
        int Nint = int.Parse(N);
        int[] sum_list = new int[3];
        for (int i = 0; i < Nint; i++)
        {
            string? numbers = sr.ReadLine();
            if (numbers == null)
            {
                return;
            }
            int[] numbers_list = numbers.Split(' ').Select(int.Parse).ToArray();
            int[] tmp_list = new int[3];
            tmp_list[0] = sum_list[0];
            tmp_list[1] = sum_list[1];
            tmp_list[2] = sum_list[2];

            sum_list[0] = Math.Min(tmp_list[1] + numbers_list[0], tmp_list[2] + numbers_list[0]);
            sum_list[1] = Math.Min(tmp_list[0] + numbers_list[1], tmp_list[2] + numbers_list[1]);
            sum_list[2] = Math.Min(tmp_list[0] + numbers_list[2], tmp_list[1] + numbers_list[2]);
        }
            
        sw.WriteLine(sum_list.Min());

        sr.Close();
        sw.Close();
    }
}
