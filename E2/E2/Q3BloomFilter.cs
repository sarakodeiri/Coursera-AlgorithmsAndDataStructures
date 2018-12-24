using System;
using System.Collections;
using System.Linq;

namespace E2
{
    public class Q3BloomFilter
    {
        BitArray Filter; 
        int[] RandInts;
        int FilterSize;
        int HashFNCount;
        Func<string, int>[] HashFunctions;


        public Q3BloomFilter(int filterSize, int hashFnCount) //ToDo (First few lines)
        {
            Filter = new BitArray(filterSize);
            HashFNCount = hashFnCount;
            RandInts = new int[HashFNCount];
            FilterSize = filterSize;

            Random rnd = new Random();
            for (int i = 0; i < HashFNCount; i++)
                RandInts[i] = rnd.Next();

            HashFunctions = new Func<string, int>[HashFNCount];
            for (int i = 0; i < HashFNCount; i++)
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
            int p = 1000000007;
            for (int i = str.Length - 1; i >= 0; i--)
                hash = (hash * x + str[i]) % p;

            return (hash%p + 1000*p) % p;
        }

        public void Add(string str) //ToDo
        {
            for (int i = 0; i < HashFNCount; i++)
            {
                int hashed = (HashFunctions[i](str))*(Filter.Length) % Filter.Length;
                Filter[hashed] = true;

            }
        }

        public bool Test(string str) //ToDo
        {
            for (int i = 0; i < HashFNCount; i++)
                if (!Filter[HashFunctions[i](str) % FilterSize])
                    return false;
            return true;
        }
    }
}