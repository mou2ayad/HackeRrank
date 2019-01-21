using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostPopularDestination
{
    class Solution
    {
        static void OutputMostPopularDestination(int count)
        {
            int cnt = count;
            Dictionary<string, int> dic = new Dictionary<string, int>();
            while (cnt!=0)
            {
                string value = Console.ReadLine();
                if (!dic.ContainsKey(value.Trim()))
                    dic.Add(value, 1);
                else
                    dic[value] += 1;
                cnt--;
            }
            int maxValue = dic.Values.Max();
            foreach (var k in dic)
                if (k.Value == maxValue)
                {
                    Console.WriteLine(k.Key);
                    break;
                }

        }

        static void Main(string[] args)
        {
            string count = Console.ReadLine();
            OutputMostPopularDestination(int.Parse(count));

        }

    }
}
