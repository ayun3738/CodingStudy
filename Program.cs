using System.Collections;
using System.ComponentModel;
using System.Globalization;

class Tmp{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
    private static Dictionary<string, HashSet<int>> tasks = new Dictionary<string, HashSet<int>>();
    
    private static void fill_board(int[,] board, string task )
    {
        int number = int.Parse(task.Substring(1));
        int target_number = tasks[task].First();
        switch(task[0])
        {
            case 'r':
                for (int i = 0; i < 9; i++)
                {
                    if (board[number, i] == 0)
                    {
                        board[number, i] = target_number;
                    }
                }
                break;
            case 'c':
                for (int i = 0; i < 9; i++)
                {
                    if (board[i, number] == 0)
                    {
                        board[i, number] = target_number;
                    }
                }
                break;
            default:
                for (int i = 0; i < 9; i++)
                {
                    int real_row = number / 3 * 3 + i / 3;
                    int real_col = number % 3 * 3 + i % 3;
                    if (board[real_row, real_col] == 0)
                    {
                        board[real_row, real_col] = target_number;
                    }
                }
                break;
        }

        tasks[task].Remove(target_number);
        if (tasks[task].Count == 1)
        {
            fill_board(board, task);
        }
        else if (tasks[task].Count == 0)
        {
            foreach (string key in tasks.Keys)
            {
                Console.WriteLine(key);
            }
            tasks.Remove(task);
        }
    }


    public static void Main(string[] args)
    {
        for (int i = 0; i < 9; i++)
        {
            tasks.Add('r' + i.ToString(), new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            tasks.Add('c' + i.ToString(), new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            tasks.Add('b' + i.ToString(), new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        }
        int[,] board = new int[9, 9];
        for (int i = 0; i < 9; i++)
        {
            string? tmp = sr.ReadLine();
            if (tmp == null)
            {
                return;
            }
            string[] tmps = tmp.Split(' ');
            for (int j = 0; j < 9; j++)
            {
                board[i, j] = int.Parse(tmps[j]);
            }
        }
        int previous_len = tasks.Count;
        while(previous_len > 0)
        {
            int current_len = tasks.Count;
            if (current_len == previous_len)
            {
                fill_board(board, tasks.Keys.First());
            }
            foreach(string task in tasks.Keys)
            {
                if (tasks[task].Count == 1)
                {
                    fill_board(board, task);
                }
            }
            previous_len = current_len;
        }

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                sw.Write(board[i, j] + " ");
            }
            sw.WriteLine();
        }

        sr.Close();
        sw.Close();

    }
}
