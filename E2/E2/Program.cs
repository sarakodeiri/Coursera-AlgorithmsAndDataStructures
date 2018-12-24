using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2
{
    public class Program
    {
        static void Main(string[] args)
        {

            Q1LinkedList list = new Q1LinkedList();
            for (int i = 0; i < 5; i++)
                list.Insert(i);

            list.DeepReverse();
            string bah = string.Empty;
        }


    }
}
