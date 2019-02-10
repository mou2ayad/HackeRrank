using System;
using System.Collections.Generic;
using System.IO;

 public class MyText
    {
        private string textValue;
        private MyText previousText;
        public override string ToString()
        {
            return textValue;
        }
        public MyText(string str)
        {
            this.textValue = str;            
        }
        public MyText append(string str)
        {
            var newText = new MyText(this.textValue + str);
            newText.previousText = this;
            return newText;            
        }
        public MyText delete(int k)
        {            
            var newText = new MyText(this.textValue.Substring(0, this.textValue.Length - k));
            newText.previousText = this;
            return newText;
        }
        public MyText undo()
        {
            if (this.previousText == null)
                return this;
            return this.previousText;
        }
        public void print(int k)
        {
            Console.WriteLine(this.textValue[k-1]);
        }


    }
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
         MyText text = new MyText("");
            var cntOps = int.Parse(Console.ReadLine());

            //CustomQueue q = new CustomQueue(int.Parse(value1));
            while (cntOps>0)
            {
                string value = Console.ReadLine();                
                var values = value.Split(' ');
                switch (values[0])
                {
                    case "1":
                        text=text.append(values[1]);
                        break;
                    case "2":
                        text = text.delete(int.Parse(values[1]));
                        break;
                    case "3":
                        text.print(int.Parse(values[1]));
                        break;
                    case "4":
                        text=text.undo();
                        break;
                    default:
                        break;
                }
                cntOps--;
            }
    }
}

