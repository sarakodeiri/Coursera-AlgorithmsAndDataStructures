using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Program
    {
        public static string Process (string inStr, Func<long, long> longProcessor)
        {
            long n = long.Parse(inStr);
            return longProcessor(n).ToString();
        }

        public static string Process(string inStr, Func<long, long, long> longProcessor)
        {
            var toks = inStr.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            long a = long.Parse(toks[0]);
            long b = long.Parse(toks[1]);
            return longProcessor(a, b).ToString();
        }

        // First Question

        public static long Fibonacci (long n)
        {
            if (n == 0)
                return 0;

            if (n == 1)
                return 1;

            int a = 0;
            int b = 1;
            int Answer = 1;

            for (int i = 2; i <= n; i++)
            {
                Answer = a + b;
                a = b;
                b = Answer;
            }
            return Answer;
        }


        public static string ProcessFibonacci(string inStr)
            => Process(inStr, Fibonacci);

        //Second Question

        public static long Fibonacci_LastDigit(long n)
        {
            List<long> LastFib = new List<long>();
            LastFib.Add(0);
            LastFib.Add(1);

            if (n == 0)
                return 0;
            
            for (int i = 2; i < (n+3); i++)
                LastFib.Add((LastFib[i - 1] + LastFib[i - 2]) % 10);
            
            int a = (int)n;
            return LastFib[a];
        }

        public static string ProcessFibonacci_LastDigit(string inStr)
            => Process(inStr, Fibonacci_LastDigit);

        //Third Question

        public static long GCD (long a, long b)
        {
            long Bigger = a;
            long Smaller = b;

            if (Bigger < Smaller)
                (Bigger, Smaller) = (Smaller, Bigger); //😊

            for (long i=Smaller; i>0; i--)
            {
                if (Smaller % i == 0 && Bigger % i == 0)
                    return i;
            }
            
            return 1;
        }

        public static string ProcessGCD(string inStr)
            => Process(inStr, GCD);

        //Forth Question

        public static long LCM(long a, long b)
        {
            return (a * b) / GCD(a, b);
        }

        public static string ProcessLCM(string inStr)
            => Process(inStr, LCM);

        //Fifth Question

        public static long GetPisano(long  m)
        {
            long a = 0, b = 1, c = a + b;
            for (long i = 0; i < int.MaxValue; i++)
            {
                c = (a + b) % m;
                a = b;
                b = c;
                if (a == 0 && b == 1)
                    return i + 1;
            }
            return 0;
        }

        public static long Fibonacci_Mod(long a, long b)
        {
            long PeriodLength = GetPisano(b);
            long[] ModArray = new long[PeriodLength];
            ModArray[0] = 0;
            ModArray[1] = 1;
            for (int i = 2; i < PeriodLength; i++)
                ModArray[i] = (ModArray[i - 1] + ModArray[i - 2]) % b;
            long Remainder = a % PeriodLength;
            long res = ModArray[Remainder];

            return res;
        }

        public static string ProcessFibonacci_Mod(string inStr)
            => Process(inStr, Fibonacci_Mod);

        //Sixth Question

        public static long Fibonacci_Sum(long n)
        {
            long TenPeriod = GetPisano(10);
            long Result = Fibonacci_LastDigit((n + 2) % TenPeriod);
            if (Result == 0)
                Result = 9;
            else
                Result--;
            return Result;
        }

        public static string ProcessFibonacci_Sum(string inStr)
            => Process(inStr, Fibonacci_Sum);

        //Seventh Question

        public static long Fibonacci_Partial_Sum(long a, long b)
        {
            if (a > b)
                (a, b) = (b, a); // 😊😊

            long HighRange = Fibonacci_Sum(b);
            long LowRange = Fibonacci_Sum(a - 1);
            if (HighRange < LowRange)
                HighRange += 10;

            return HighRange - LowRange;
        }

        public static string ProcessFibonacci_Partial_Sum(string inStr)
            => Process(inStr, Fibonacci_Partial_Sum);

        //Eighth Question

        public static long Fibonacci_Sum_Squares(long n)
        {
            long TenPeriod = GetPisano(10);
            long Fn, Fnn;
            Fn = Fibonacci_LastDigit(n % TenPeriod);
            Fnn = Fibonacci_LastDigit((n+1) % TenPeriod);

            return (Fn*Fnn)%10;
        }

        public static string ProcessFibonacci_Sum_Squares(string inStr)
            => Process(inStr, Fibonacci_Sum_Squares);

        static void Main(string[] args)
        {
            Fibonacci_Mod(239, 1000);
            Console.ReadKey();
        }

    }

}
