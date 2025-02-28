class NQueen{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
    private static int cnt = 0;
    private static int[,] direction = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 }, { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 } };
    private static void fill_board(int[,] board, int y, int x)
    {
        int N = board.GetLength(0);
        board[y, x] += 1;
        for (int i = 0; i < direction.GetLength(0); i++)
        {
            int dx = direction[i, 0];
            int dy = direction[i, 1];
            int tmpx = x + dx;
            int tmpy = y + dy;
            while (tmpx >= 0 && tmpx < N && tmpy >= 0 && tmpy < N)
            {
                board[tmpy, tmpx] += 1;
                tmpx += dx;
                tmpy += dy;
            }
        }
    }

    private static void repair_board(int[,] board, int y, int x)
    {
        int N = board.GetLength(0);
        board[y, x] -= 1;
        for (int i = 0; i < direction.GetLength(0); i++)
        {
            int dx = direction[i, 0];
            int dy = direction[i, 1];
            int tmpx = x + dx;
            int tmpy = y + dy;
            while (tmpx >= 0 && tmpx < N && tmpy >= 0 && tmpy < N)
            {
                board[tmpy, tmpx] -= 1;
                tmpx += dx;
                tmpy += dy;
            }
        }
    }

    private static void put_queen(int[,] board, int depth)
    {
        int N = board.GetLength(0);
        // sw.WriteLine(depth);

        if (depth == N)
        {
            cnt += 1;
            return;
        }
        for (int j = 0; j < N; j++)
        {
            if (board[depth, j] == 0)
            {
                // sw.WriteLine("i: " + depth + " j: " + j);
                fill_board(board, depth, j);
                // for (int a = 0; a < N; a++)
                // {
                //     for (int b = 0; b < N; b++)
                //     {
                //         sw.Write(board[a, b]);
                //     }
                //     sw.WriteLine();
                // }
                put_queen(board, depth + 1);
                repair_board(board, depth, j);
            }
        }
    }

    public static void nqueen(string[] args)
    {
        string? N = sr.ReadLine();
        if (N == null)
        {
            return;
        }
        int Nint = int.Parse(N);
        int[,] board = new int[Nint, Nint];
        for (int i = 0; i < Nint; i++)
        {
            for (int j = 0; j < Nint; j++)
            {
                board[i, j] = 0;
            }
        }
        put_queen(board, 0);
        sw.WriteLine(cnt);

        sr.Close();
        sw.Close();

    }
}
