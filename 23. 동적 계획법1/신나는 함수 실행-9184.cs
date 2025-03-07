class HappyFunction{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
    private static Dictionary<Tuple<int, int, int>, int> w_map = new Dictionary<Tuple<int, int, int>, int>();
    private static int calculate(int a, int b, int c)
    {
        Tuple<int, int, int> tmp = new Tuple<int, int, int> (a, b, c);
        if (a <= 0 || b <= 0 || c <= 0)
        {
            return 1;
        }
        if (a > 20 || b > 20 || c > 20)
        {
            return calculate(20, 20, 20);
        }
        if (w_map.ContainsKey(tmp))
        {
            return w_map[tmp];
        }
        if (a < b && b < c)
        {
            w_map[tmp] = calculate(a, b, c - 1) + calculate(a, b - 1, c - 1) - calculate(a, b - 1, c);
            return w_map[tmp];
        }
        w_map[tmp] = calculate(a - 1, b, c) + calculate(a - 1, b - 1, c) + calculate(a - 1, b, c - 1) - calculate(a - 1, b - 1, c - 1);
        return w_map[tmp];
    }

    public static void happyFunction(string[] args)
    {
        calculate(20, 20, 20);
        while(true)
        {
            string? abc = sr.ReadLine();
            if (abc == null)
            {
                break;
            }
            List<int> abc_list = abc.Split(' ').Select(x => int.Parse(x)).ToList();
            if (abc_list[0] == -1 && abc_list[1] == -1 && abc_list[2] == -1)
            {
                break;
            }
            int target = calculate(abc_list[0], abc_list[1], abc_list[2]);
            sw.WriteLine("w(" + abc_list[0] + ", " + abc_list[1] + ", " + abc_list[2] + ") = " + target);
        }

        sr.Close();
        sw.Close();
    }
}
