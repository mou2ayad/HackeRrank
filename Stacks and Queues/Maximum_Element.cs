using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


class Solution {
      public class ListItem
        {
            public ListItem(int val)
            {
                value = val;
            }
            public int value;
            public ListItem Next { set; get; }
            public ListItem Prev { set; get; }
        }
    public class MyList
    {
        ListItem Head;
        Dictionary<int, ListItem> ids = new Dictionary<int, ListItem>();
        public int GetMax()
        {
            return Head.value;
        }
        public void AddItem(int item, int id)
        {
            ListItem Newitem = new ListItem(item);

            if (Head == null)
                Head = Newitem;
            else
            {
                var tmp = Head;
                while (tmp.Prev != null && tmp.value > Newitem.value)
                {
                    tmp = tmp.Prev;
                }
                if (tmp.value <= Newitem.value)
                {
                    Newitem.Next = tmp.Next;
                    tmp.Next = Newitem;
                    Newitem.Prev = tmp;
                    if (tmp == Head)
                        Head = Newitem;
                }
                else if (tmp.Prev == null)
                {
                    tmp.Prev = Newitem;
                    Newitem.Next = tmp;

                }


            }
            ids.Add(id, Newitem);
        }
        public void DeleteItem(int id)
        {
            var item = ids[id];
            if (item.Prev == null && item.Next == null)
            {
                Head = null;
            }
            else if (item.Next == null)
            {
                Head = item.Prev;                
                item.Prev.Next = null;
            }
            else if (item.Prev != null && item.Next != null)
            {
                item.Prev.Next = item.Next;
                item.Next.Prev = item.Prev;
            }
            else
            {
                item.Next.Prev = null;
            }
            ids.Remove(id);
        }

    }
    static void Main(String[] args) {
        Stack<int> stk = new Stack<int>();
            MyList list = new MyList() ;
            int tmp;
            var cntOps = int.Parse(Console.ReadLine());

            while (cntOps > 0)
            {
                string value = Console.ReadLine();
                var values = value.Split(' ');
                switch (values[0])
                {
                    case "1":
                        tmp=int.Parse(values[1]);
                        stk.Push(tmp);
                        list.AddItem(tmp, stk.Count - 1);                                            
                        break;
                    case "2":
                        stk.Pop();
                        list.DeleteItem(stk.Count);
                        break;
                    case "3":
                        Console.WriteLine(list.GetMax());
                        break;                    
                    default:
                        break;
                }
                cntOps--;
            }
    }
        
}

