using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public class Program
    {
        public static int NaiveMaxPairwiseProduct(List <int> numbers)
        {
                int product = 0;
                int n = numbers.Count();
                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        product = Math.Max(product,
                        numbers[i] * numbers[j]);
                    }
                }
                return product;
        }

        public static int FastMaxPairwiseProduct(List<int> numbers)
        {
            int index = 0;
            for (int i = 1; i < numbers.Count; i++)
                if (numbers[i] > numbers[index])
                    index = i;

            // چه جالب. من اینو بلد نبودم 👏🏻
            (numbers[index], numbers[numbers.Count - 1]) = (numbers[numbers.Count() - 1], numbers[index]);

            index = 0;
            for (int i = 1; i < numbers.Count - 1; i++)
                if (numbers[i] > numbers[index])
                    index = i;

            (numbers[index], numbers[numbers.Count - 2]) = (numbers[numbers.Count - 2], numbers[index]);

            return numbers[numbers.Count - 1] * numbers[numbers.Count - 2];
        }

        public static string Process(string input)
        {
            var inData = input.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s))
                .ToList();
            return FastMaxPairwiseProduct(inData).ToString();
        }

        static void Main(string[] args)
        {
        }
    }
}
