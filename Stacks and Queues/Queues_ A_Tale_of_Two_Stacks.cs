using System;
using System.Collections.Generic;
using System.IO;

 
class Solution {
        Stack<int> main;
        Stack<int> temp;
       
        public Solution(int size)
        {
            main = new Stack<int>(size);
            temp = new Stack<int>(size);
            
        }
        public void put(int value)
        {                                             
            main.Push(value);
        }
        private void Swap(Stack<int> from,Stack<int> to)
        {
            while (from.Count > 0)
                to.Push(from.Pop());
        }
        public int pop()
        {
          if(temp.Count==0)
                Swap(main, temp);                             
            return temp.Pop();
        }
        public int peek()
        {
            if (temp.Count == 0)
                Swap(main, temp);            
            return temp.Peek();
        }
        public void Action(int ActionType, int value=0)
        {
            switch(ActionType)
            {
                case 1:
                {
                        this.put(value);
                    break;
                }
                case 2:
                {
                        this.pop();
                    break;
                }
                case 3:
                {
                       Console.WriteLine(this.peek());
                    break;
                }
                default:
                {
                    break;
                }

            }
        }

    static void Main(String[] args) {

        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
         var value1 = Console.ReadLine();            
         Solution q = new Solution(int.Parse(value1));     
           while(true)
            {
                string value = Console.ReadLine();
                if(string.IsNullOrEmpty(value))
                    break;
                var values = value.Split(' ');

                if (values.Length == 2)
                    q.Action(int.Parse(values[0]), int.Parse(values[1]));
                else
                    q.Action(int.Parse(values[0]));                
            }
    }
}

