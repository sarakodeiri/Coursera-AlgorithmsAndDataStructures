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
            var problem = new ParallelProcessing("");
            problem.Solve(3, new long[] { 184, 167,
                121, 182, 129, 151, 107, 191, 125,
                194 });
        }
    }
}
