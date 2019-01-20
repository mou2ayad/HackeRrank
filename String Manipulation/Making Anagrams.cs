class MakingAnagrams
{
      static int makeAnagram(string a, string b)
        {
            if (a == null || b == null)
                return 0;
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (var ch in a)
            {
                if (dic.ContainsKey(ch))
                    dic[ch] += 1;
                else
                    dic.Add(ch, 1);
            }
            foreach (var ch in b)
            {
                if (dic.ContainsKey(ch))
                    dic[ch] -= 1;
                else
                    dic.Add(ch, -1);
            }
            int totaldiff = 0;
            foreach (var v in dic)
            {
                totaldiff += Math.Abs(v.Value);
            }
            return totaldiff;

        }
}
