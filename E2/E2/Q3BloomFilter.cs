using System;
using System.Collections;
using System.Linq;

namespace E2
{
    public class Q3BloomFilter
    {
        BitArray Filter; 
        int[] randints;
        int count;
        Func<string, int>[] HashFunctions;


        public Q3BloomFilter(int filterSize, int hashFnCount)
        {
            // زحمت بکشید پیاده سازی کنید
            count = hashFnCount;
            Random rnd = new Random();
            Filter = new BitArray(filterSize);
            randints = new int[count];

            for (int i = 0; i < count; i++)
                randints[i] = rnd.Next();

            HashFunctions = new Func<string, int>[hashFnCount];
            for (int i = 0; i < count; i++)
            {
                HashFunctions[i] = str => MyHashFunction(str, rnd.Next()); //takes string, converts it into an int (the hash).
            }
        }

        public int MyHashFunction(string str, int num) //previously generated random int
        {
            return str.GetHashCode() + num;
        }

        public void Add(string str) //ToDo
        {
            for (int i = 0; i < count; i++)
                Filter[MyHashFunction(str, randints[i])] = true;
        }

        public bool Test(string str)
        {
            // زحمت بکشید پیاده سازی کنید
            int[] hashResult = new int[count];

            for (int i = 0; i < count; i++)
                hashResult[i] = MyHashFunction(str, randints[i]);

            for (int i = 0; i < count; i++)
                return (Filter[hashResult[i]]);
            return true;
        }
    }
}