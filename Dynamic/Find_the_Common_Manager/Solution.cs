using System;
using System.Collections.Generic;
namespace CommonManager
{
 class Solution
    {
        public string name { set; get; }
        public Solution manager { set; get; }
        public Solution(string name)
        {
            this.name = name;
        }
        static void OutputCommonManager(int count)
        {
            Dictionary<string, Solution> dic = new Dictionary<string, Solution>(count);
            string first = string.Empty;
            string second = string.Empty;

            string value = Console.ReadLine();
            first = value.Trim();
            dic.Add(first, new Solution(first));
            value = Console.ReadLine();
            second = value.Trim();
            dic.Add(second, new Solution(second));
            value = Console.ReadLine();
            do
            {
                var values = value.Split(' ');
                if (!dic.ContainsKey(values[0]))
                    dic.Add(values[0], new Solution(values[0]));
                if (!dic.ContainsKey(values[1]))
                    dic.Add(values[1], new Solution(values[1]) { manager = dic[values[0]] });
                else
                    dic[values[1]].manager = dic[values[0]];
                value = Console.ReadLine();

            } while (!string.IsNullOrEmpty(value.Trim()));
            var firstEmp = dic[first];
            List<string> firstLine = new List<string>();
            firstLine.Add(first);
            var mgr = firstEmp.manager;
            while (mgr != null)
            {
                firstLine.Add(mgr.name);
                mgr = mgr.manager;
            }
            var SecondEmp = dic[second];
            List<string> SecondLine = new List<string>();
            SecondLine.Add(second);
            mgr = SecondEmp.manager;
            while (mgr != null)
            {
                SecondLine.Add(mgr.name);
                mgr = mgr.manager;
            }
            for (int i = 0; i < firstLine.Count; i++)
            {
                for (int j = 0; j < SecondLine.Count; j++)
                {
                    if (firstLine[i].Equals(SecondLine[j]))
                    {
                        Console.WriteLine(firstLine[i]);
                        return;
                    }

                }
            }

        }

        static void Main(string[] args)
        {
            string count = Console.ReadLine();
            OutputCommonManager(int.Parse(count));

        }
 }
