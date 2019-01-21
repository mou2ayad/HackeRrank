using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

       static Dictionary<int, int> values = new Dictionary<int, int>();
       
        
        static int maxSubsetSum(int[] arr, int startFrom = 0)
        {
            int maxvalue = 0;
            if (values.ContainsKey(startFrom))
                return values[startFrom];
            if (arr.Length - 2 <= startFrom)
            {
                AddToDic(startFrom, 0);
                return 0;
            }
            for(int i=arr.Length-2;i>=startFrom;i--)
            {
                for(int j=i+2;j<arr.Length;j++)
                {
                    maxvalue = Math.Max(maxvalue,arr[i] + arr[j]);                    
                    maxvalue = Math.Max(maxvalue, arr[i] + maxSubsetSum(arr, j));
                }
            }
            AddToDic(startFrom, maxvalue);
            return maxvalue;
        }
        static void AddToDic(int key,int value)
        {
            if (values.ContainsKey(key))
                values[key] = value;
            else
                values.Add(key, value);
        }
    // Complete the maxSubsetSum function below.
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int res = maxSubsetSum(arr);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
