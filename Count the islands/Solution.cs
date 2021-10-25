using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {
    static void Main(string[] args)
        {
   
        var array = GetMatrixFromConsole(out var c, out var r);
            int cnt = array[0, 0];
            cnt += Enumerable.Range(1, c-1)
                .Count(e => array[0, e] == 1 && array[0,e-1]!=1 );

            for (int i = 1; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                    cnt += (array[i, j] == 1) && ((j != 0 && array[i, j - 1] == 0) && array[i - 1, j - 1] == 0 &&
                                                  array[i - 1, j] == 0)
                        ? 1
                        : 0;

            }
            Console.WriteLine(cnt);
            

        }
    private static int[,] GetMatrixFromConsole(out int c, out int r)
        {
            var rc = Console.ReadLine().Split(" ".ToCharArray());
            r = int.Parse(rc[0].ToString());
            c = int.Parse(rc[1].ToString());
            var array = new int[r, c];
            for (int i = 0; i < r; i++)
            {
                var row = Console.ReadLine().Split(" ".ToCharArray());
                for (int j = 0; j < c; j++)
                    array[i, j] = Convert.ToInt32(row[j].ToString());
            }

            return array;
        }
 
}