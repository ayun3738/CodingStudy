class ChessColor{
    public static void chesscolor(string[] args)
    {
        // ReadLine()에 null이 들어올 수 있으므로 string?으로 선언
        string? NM = Console.ReadLine();
        if (NM == null)
        {
            return;
        }
        List<int> NMList = NM.Split(' ').Select(s => int.Parse(s)).ToList();
        int[,] chess = new int[NMList[0], NMList[1]];
        for (int i = 0; i < NMList[0]; i++)
        {
            string? line = Console.ReadLine();
            if (line == null)
            {
                return;
            }
            
            for (int j = 0; j < NMList[1]; j++)
            {
                if (line[j] == 'B')
                {
                    chess[i, j] = 1;
                }
                else
                {
                    chess[i, j] = 0;
                }
            }
        }
        
        int result = 64;
        for (int i = 0; i < NMList[0]-7; i++)
        {
            for (int j = 0; j < NMList[1]-7; j++)
            {
                int even = 0;
                int odd = 0;
                for (int k = i; k < i+8; k++)
                {
                    for (int l = j; l < j+8; l++)
                        if ((k+l)%2 == 0)
                        {
                            if (chess[k, l] == 1)
                            {
                                even++;
                            }
                        }
                        else
                        {
                            if (chess[k, l] == 1)
                            {
                                odd++;
                            }
                        }
                    }
                int tmp1 = 32 - even + odd;
                int tmp2 = 32 - odd + even;
                result = Math.Min(result, Math.Min(tmp1, tmp2));
                }
            }
        Console.WriteLine(result);
        }
}

