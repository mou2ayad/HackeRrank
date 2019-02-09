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

    // Complete the isBalanced function below.
    static string isBalanced(string s) {
         if (s.Length % 2 != 0)
                return "NO";
            Stack<char> stl = new Stack<char>();
            stl.Push(s[0]);
            for(int i=1;i<s.Length;i++)
            {
                  if(stl.Count==0 ||  !isPair(stl.Peek(), s[i]))
                    stl.Push(s[i]);                
                else
                    stl.Pop();
            }
            if (stl.Count > 0)
                return "NO";
            return "YES";
            

    }
     static bool isPair(char s1,char s2)
        {
            if (s1 == '{' && s2 == '}')
                return true;
            if (s1 == '[' && s2 == ']')
                return true;
            if (s1 == '(' && s2 == ')')
                return true;
            return false;
        }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            string s = Console.ReadLine();

            string result = isBalanced(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
