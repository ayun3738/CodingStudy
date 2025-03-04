using System.Collections;
using System.ComponentModel;
using System.Globalization;

class Tmp{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
    private static Dictionary<string, HashSet<int>> tasks = new Dictionary<string, HashSet<int>>();
    
    private static void remove_candidate(string set_type, int target_number)
    {
        if (tasks.ContainsKey(set_type))
        {
            tasks[set_type].Remove(target_number);
        }
    }

    private static void fill_board(int[,] board, string task )
    {
        int number = int.Parse(task.Substring(1));
        int target_number = tasks[task].First();
        // sw.WriteLine(task + " " + target_number);
            int real_row;
            int real_col;
            for (int i = 0; i < 9; i++){
                switch(task[0])
                {
                    case 'r':
                        real_row = number;
                        real_col = i;
                        break;
                    case 'c':
                        real_row = i;
                        real_col = number;
                        break;
                    default:
                        real_row = number / 3 * 3 + i / 3;
                        real_col = number % 3 * 3 + i % 3;
                        break;
                }    
                if (board[real_row, real_col] == 0)
                {
                    board[real_row, real_col] = target_number;
                    string row = 'r' + real_row.ToString();
                    string col = 'c' + real_col.ToString();
                    string box = 'b' + (real_row / 3 * 3 + real_col / 3).ToString();

                }
            }
        sw.WriteLine(task + " " + target_number);
        tasks[task].Remove(target_number);
        if (tasks[task].Count == 1)
        {
            fill_board(board, task);
        }
        else if (tasks[task].Count == 0)
        {
            foreach (string key in tasks.Keys)
            {
                // Console.WriteLine(key);
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

            for (int j = 0; j < 9; j++)
            {
                if (board[i, j] != 0)
                {
                    tasks['r' + i.ToString()].Remove(board[i, j]);
                    tasks['c' + j.ToString()].Remove(board[i, j]);
                    tasks['b' + (i / 3 * 3 + j / 3).ToString()].Remove(board[i, j]);
                }
            }
        }
        int previous_len = 1;
        sw.WriteLine();
        while(previous_len > 0)
        {
            int current_len = tasks.Count;
            if (current_len == previous_len)
            {
                fill_board(board, tasks.Keys.First());
            }
            foreach(string task in tasks.Keys)
            {
                // sw.WriteLine(task + " " + tasks[task].Count);
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
