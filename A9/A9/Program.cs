using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A9
{
    public class Program
    {
        static void Main(string[] args)
        {
            var problem = new MergingTables("");
            problem.Solve(new long[] { 10, 0 ,5, 0, 3, 3 }, new long[] { 6, 5, 4, 3 }, new long[] { 6, 6, 5, 4 });
        }
    }
}
