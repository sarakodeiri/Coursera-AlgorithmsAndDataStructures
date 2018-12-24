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


        public Q3BloomFilter(int filterSize, int hashFnCount) //ToDo (First few lines)
        {
            count = hashFnCount;
            Random rnd = new Random();
            Filter = new BitArray(filterSize);
            randints = new int[count];

            for (int i = 0; i < count; i++)
                randints[i] = rnd.Next();

            HashFunctions = new Func<string, int>[count];

            for (int i = 0; i < count; i++)
            {
                int x = randints[i];
                HashFunctions[i] = str => PolyHash(str, x); //takes string, converts it into an int (the hash).
            }
        }

        //public int MyHashFunction(string str, int num) //num = previously generated random int
        //{
        //    return str.GetHashCode() + num;
        //}

        
        public int PolyHash(string str, int x)
        {
            int hash = 0;
            for (int i = str.Length - 1; i >= 0; i--)
                hash = (hash * x + str[i]) % 1000000007;

            return hash;
        }

        public void Add(string str) //ToDo
        {
            for (int i = 0; i < count; i++)
                Filter[HashFunctions[i](str)] = true;
        }

        public bool Test(string str) //ToDo
        {
            //int[] hashResult = new int[count];
            //for (int i = 0; i < count; i++)
            //    hashResult[i] = HashFunctions[i](str);

            for (int i = 0; i < count; i++)
                if (!Filter[HashFunctions[i](str)])
                    return false;
            return true;
        }
    }
}