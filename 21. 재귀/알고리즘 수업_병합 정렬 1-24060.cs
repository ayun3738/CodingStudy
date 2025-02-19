class MergeSort{
    private static int CNT = 0;
    private static int K = 0;
    private static Tuple<bool, int> CheckK(int n)
    {
        if(K < CNT + n)
        {
            return Tuple.Create(true, K - CNT);
        }
        else
        {
            return Tuple.Create(false, 0);
        }
    }

    public static void mergeSort(string[] args)
    {
        string? NK = Console.ReadLine();        
        if (NK == null)
        {
            return;
        }
        List<int> arr = NK.Split(' ').Select(x => int.Parse(x)).ToList();
        K = arr[1] ;
        string? input = Console.ReadLine();
        if (input == null)
        {
            return;
        }
        List<int> arr2 = input.Split(' ').Select(x => int.Parse(x)).ToList();
        List<int> result = merge_sort(arr2);
        Tuple<bool, int> total = CheckK(result.Count);
        if(total.Item1)
        {
            Console.WriteLine(result[total.Item2]);
        }
        else
        {
            Console.WriteLine(-1);
        }
    }

    private static List<int> merge(List<int> left, List<int> right)
    {
        List<int> result = new List<int>();
        int i = 0;
        int j = 0;
        while (i < left.Count && j < right.Count)
        {
            if (left[i] <= right[j])
            {
                result.Add(left[i]);
                i++;
            }
            else
            {
                result.Add(right[j]);
                j++;
            }
        }
        while (i < left.Count)
        {
            result.Add(left[i]);
            i++;
        }
        while (j < right.Count)
        {
            result.Add(right[j]);
            j++;
        }
        return result;
    }
    private static List<int> merge_sort(List<int> arr)
    {
        if (arr.Count <= 1)
        {
            CNT++;
            return arr;
        }
        int q = arr.Count / 2 + arr.Count % 2;
        List<int> left = merge_sort(arr.GetRange(0, q));
        Tuple<bool, int> lcheck = CheckK(left.Count);
        if(lcheck.Item1)
        {
            Console.WriteLine(left[lcheck.Item2]);
            Environment.Exit(0);
        }
        List<int> right = merge_sort(arr.GetRange(q, arr.Count - q));
        Tuple<bool, int> rcheck = CheckK(right.Count);
        if(rcheck.Item1)
        {
            Console.WriteLine(right[rcheck.Item2]);
            Environment.Exit(0);
        }
        return merge(left, right);
    }
}