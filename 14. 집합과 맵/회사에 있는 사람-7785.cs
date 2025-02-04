using System.IO;

class CompanyMember{
    public static void companymember(string[] args)
    {
        StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        
        string? N = sr.ReadLine();
        if (N == null)
        {
            return;
        }
        HashSet<string> employee = new HashSet<string>();
        for (int i = 0; i < int.Parse(N); i++)
        {
            string? logStr = sr.ReadLine();
            if (logStr == null)
            {
                return;
            }
            List<string> log = logStr.Split(' ').ToList();
            if (log[1] == "enter")
            {
                employee.Add(log[0]);
            }
            else
            {
                employee.Remove(log[0]);
            }
        }

        List<string> employeeList = employee.ToList();
        employeeList.Sort();
        employeeList.Reverse();
        foreach (string emp in employeeList)
        {
            sw.WriteLine(emp);
        }

        sr.Close();
        sw.Close();
    }
}