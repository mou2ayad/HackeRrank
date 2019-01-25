using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {

    /*
     * Complete the equalStacks function below.
     */
      static int GetMax(int n1, int n2, int n3)
        {
            return Math.Max(Math.Max(n1, n2), n3);
        }
        static int GetMin(int n1, int n2, int n3)
        {
            return Math.Min(Math.Min(n1, n2), n3);
        }
        
      static int equalStacks(int[] ar1, int[] ar2, int[] ar3)
        {
            Stack<int> op1 = new Stack<int>();
            Stack<int> op2 = new Stack<int>();
            Stack<int> op3 = new Stack<int>();
            op1.Push(0);
            op2.Push(0);
            op3.Push(0);
            int i = GetMax(ar1.Length, ar2.Length, ar3.Length);            
            i--;
            while (i>=0)
            {
                if(ar1.Length-1>=i)
                {
                    op1.Push(op1.Peek() + ar1[i]);
                }
                if (ar2.Length - 1 >= i)
                {
                    op2.Push(op2.Peek() + ar2[i]);
                }
                if (ar3.Length - 1 >=i)
                {
                    op3.Push(op3.Peek() + ar3[i]);
                }
                i--;
            }
            int target = GetMin(op1.Peek(), op2.Peek(), op3.Peek());
            int[] found = new int[3];
            while(found.Sum()!=3)
            {
                if(op1.Peek()!=target)
                {
                    found[0] =0;
                    op1.Pop();
                    target =Math.Min(op1.Peek(),target);
                }                
                else
                {
                    found[0] = 1;
                }

                if (op2.Peek() != target)
                {
                    found[1] = 0;
                    op2.Pop();
                    target = Math.Min(op2.Peek(), target);
                }
                else
                {
                    found[1] = 1;
                }

                if (op3.Peek() != target)
                {
                    found[2] = 0;
                    op3.Pop();
                    target = Math.Min(op3.Peek(), target);
                }
                else
                {
                    found[2] = 1;
                }
            }
            return target;

        }
       
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] n1N2N3 = Console.ReadLine().Split(' ');

        int n1 = Convert.ToInt32(n1N2N3[0]);

        int n2 = Convert.ToInt32(n1N2N3[1]);

        int n3 = Convert.ToInt32(n1N2N3[2]);

        int[] h1 = Array.ConvertAll(Console.ReadLine().Split(' '), h1Temp => Convert.ToInt32(h1Temp))
        ;

        int[] h2 = Array.ConvertAll(Console.ReadLine().Split(' '), h2Temp => Convert.ToInt32(h2Temp))
        ;

        int[] h3 = Array.ConvertAll(Console.ReadLine().Split(' '), h3Temp => Convert.ToInt32(h3Temp))
        ;
        int result = equalStacks(h1, h2, h3);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
