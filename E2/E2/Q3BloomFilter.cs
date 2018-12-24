using System;
using System.Collections;
using System.Linq;

namespace E2
{
    public class Q3BloomFilter
    {
        BitArray Filter; 
        int[] RandInts;
        int Count;
        int FilterSize;
        Func<string, int>[] HashFunctions;


        public Q3BloomFilter(int filterSize, int hashFnCount) //ToDo (First few lines)
        {
            Count = hashFnCount;
            FilterSize = filterSize;
            Random rnd = new Random();
            Filter = new BitArray(filterSize);
            RandInts = new int[Count];

            for (int i = 0; i < Count; i++)
                RandInts[i] = rnd.Next();

            HashFunctions = new Func<string, int>[Count];

            for (int i = 0; i < Count; i++)
            {
                int x = RandInts[i];
                HashFunctions[i] = str => PolyHash(str, x); //takes string, converts it into an int (the hash).
            }
        }

        //public int MyHashFunction(string str, int num) //num = previously generated random int
        //{
        //    return str.GetHashCode() + num;
        //}

        public int PolyHash(string str, int x) //Copied from A10
        {
            int hash = 0;
            for (int i = str.Length - 1; i >= 0; i--)
                hash = (hash * x + str[i]) % 1000000007;

            return hash;
        }

        public void Add(string str) //ToDo
        {
            for (int i = 0; i < Count; i++)
                Filter[HashFunctions[i](str) % FilterSize] = true;
        }

        public bool Test(string str) //ToDo
        {
            for (int i = 0; i < Count; i++)
                if (!Filter[HashFunctions[i](str) % FilterSize])
                    return false;
            return true;
        }
    }
}