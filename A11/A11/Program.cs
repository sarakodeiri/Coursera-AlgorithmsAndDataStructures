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
            long[][] nodes = new long[3][];
            nodes[0] = new long[] {2, 1, 2};
            nodes[1] = new long[] {2, -1, -1};
            nodes[2] = new long[] {3, -1, -1};
            //nodes[3] = new long[] {12, -1, -1};
            //nodes[4] = new long[] {14, 2, -1};



            IsItBSTHard blah = new IsItBSTHard("TD3");
           // Tree tree = new Tree(nodes);
            blah.Solve(nodes);
        }
    }
}
