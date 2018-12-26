using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A11
{
    public class Program
    {
        static void Main(string[] args)
        {
            long[][] nodes = new long[6][];
            nodes[0] = new long[] { 9, 4, -1 };
            nodes[1] = new long[] { 11, 5, -1 };
            nodes[2] = new long[] { 0, -1, -1 };
            nodes[3] = new long[] {9, -1, -1};
            nodes[4] = new long[] {2, 2, 3};
            nodes[5] = new long[] { 9, -1, -1};


            //            0 - 1 3
            //28 - 1 - 1
            //7 - 1 4
            //22 2 1
            //15 - 1 - 1


            IsItBSTHard blah = new IsItBSTHard("TD3");
            // Tree tree = new Tree(nodes);
            blah.Solve(nodes);
        }
    }
}
