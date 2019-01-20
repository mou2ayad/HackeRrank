 class CommonChild
 {
        static int commonChild(String str1, String str2)
        {
            int[,] L = new int[str1.Length + 1, str2.Length + 1];
            
            for (int i = 0; i <= str1.Length; i++)
            {
                for (int j = 0; j <= str2.Length; j++)
                {
                    if (i == 0 || j == 0)
                        L[i,j] = 0;
                    else if (str1.ElementAt(i - 1) == str2.ElementAt(j - 1))
                    {
                        L[i,j] = L[i - 1,j - 1] + 1;
                    }
                    else
                    {
                        L[i,j] = Math.Max(L[i - 1,j], L[i,j - 1]);
                    }
                }
            }
            return L[str1.Length,str2.Length];
        }
}
class CommonChild2
{
        static int commonChild(string s1, string s2)
        {            
            string finaloutput = "";
            string tempoutput = "";
            for (int i = 0; i < s1.Length; i++)
            {
                tempoutput = commonChildSub(s1.Substring(i), s2);
                if (finaloutput.Length < tempoutput.Length)
                    finaloutput = tempoutput;
            }
            return finaloutput.Length;
        }
        static string commonChildSub(string s1, string s2)
        {
            string tempoutput = "";
            for (int i = 0; i < s1.Length; i++)
            {
                for(int j=0;j<s2.Length;j++)
                {
                    if(s1[i]==s2[j])
                    {
                        tempoutput = s1[i].ToString();
                        if(j+1<=s2.Length && i+1<=s1.Length)
                           return tempoutput += commonChildSub(s1.Substring(i + 1), s2.Substring(j + 1));          
                    }
                
                }                                            
            }
            return tempoutput;
        }
}
