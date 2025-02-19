class CantorSet{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

    private static void Kan(int n)
    {
        if (n == 0)
        {
            sw.Write("-");
            return;
        }
        Kan(n - 1);
        for (int i = 0; i < (int)Math.Pow(3, n - 1); i++)
        {
            sw.Write(" ");
        }
        Kan(n - 1);
    }

    public static void cantorSet(string[] args)
    {
        while (true)
        {
            string? N = sr.ReadLine();
            if (N == null | N == "")
            {
                sr.Close();
                sw.Close();
                return;
            }

            Kan(int.Parse(N));
            sw.Write("\n");
        }
    }
}
