class HanoiTower{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

    private static void Hanoi(List<int> HList)
    {
        if(HList[0] == 1)
        {
            sw.WriteLine(HList[1] + " " + HList[2]);
            return;
        }
        Hanoi(new List<int> {HList[0] - 1, HList[1], 6 - HList[1] - HList[2]});
        sw.WriteLine(HList[1] + " " + HList[2]);
        Hanoi(new List<int> {HList[0] - 1, 6 - HList[1] - HList[2], HList[2]});
    }
    public static void hanoiTower(string[] args)
    {
        string? N = sr.ReadLine();
        if (N == null)
        {
            return;
        }
        sw.WriteLine((int)Math.Pow(2, int.Parse(N)) - 1);
        List<int> HList = new List<int> {int.Parse(N), 1, 3};
        Hanoi(HList);
        sr.Close();
        sw.Close();
    }
}
