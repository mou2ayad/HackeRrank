class AlternatingCharacters
{
  static int alternatingCharacters(string s) {
          if (string.IsNullOrEmpty(s))
                return 0;
            if (s.Length == 0)
                return 0;
            int charForDelete = 0;
            int ind = 0;
            for(int i=1;i<s.Length;i++)
            {

                if (s[ind] == s[i])
                {
                    charForDelete++;
                }
                else
                    ind = i;

            }
            return charForDelete;
    }
}
