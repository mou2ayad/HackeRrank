class  Balanced_Brackets {
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
}
