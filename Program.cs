class Tmp{
    private static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    private static StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
    private static Dictionary<string, HashSet<int>> tasks = new Dictionary<string, HashSet<int>>();
    
    private static void remove_candidate(string set_type, int[,] board, int target_number)
    {
        tasks[set_type].Remove(target_number);
        if (tasks[set_type].Count == 0)
        {
            tasks.Remove(set_type);
            return;
        }
        if (tasks[set_type].Count == 1)
        {
            fill_board(board, set_type);
        }
    }

    private static void fill_board(int[,] board, string task )
    {
        int number = int.Parse(task.Substring(1));
        int target_number = tasks[task].First();
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
                if (tasks.ContainsKey(row))
                {
                    remove_candidate(row, board, target_number);
                }
                if (tasks.ContainsKey(col))
                {
                    remove_candidate(col, board, target_number);
                }
                if (tasks.ContainsKey(box))
                {
                    remove_candidate(box, board, target_number);
                }
                return ;
            }
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
        
        
        while(previous_len > 0)
        {
            List<string> target_tasks = new List<string>();
            foreach (string task in tasks.Keys)
            {
                if (tasks[task].Count == 1)
                {
                    target_tasks.Add(task);
                }
            }
            foreach(string task in target_tasks)
            {
                if (tasks.ContainsKey(task))
                {
                    if (tasks[task].Count == 1)
                    {
                        fill_board(board, task);
                    }
                }
            }
            int current_len = tasks.Count;
            if (current_len == previous_len & current_len > 0)
            {
                fill_board(board, tasks.Keys.First());
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
