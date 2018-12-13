using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] test = new string[] {
            "add 9999999 bigNum",
            "find 9999999",
            "add 9999998 notSoBig",
            "del 9999998",
            "find 9999998",
            "add 1 aaaaaaaaaaaaaaa",
            "add 2 testForLen",
            "find 2",
            "find 1"};
            PhoneBook pb = new PhoneBook("TD1");
            pb.Solve(test);
        }
    }
}
