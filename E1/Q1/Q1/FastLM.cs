using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class FastLM
    {
        public readonly WordCount[] WordCounts;


        public FastLM(WordCount[] wordCounts)
        {
            this.WordCounts = wordCounts.OrderBy(wc => wc.Word).ToArray();
        }

        public bool GetCount(string word, out ulong count)
        {
            count = 0;
            long index = BinarySearch(WordCounts, 0, WordCounts.Length - 1, word);

            if (WordCounts[(int)index].Word != word)
                return false;
            else
            {
                count = WordCounts[(int)index].Count;
                return true;
            }
        }

        public long BinarySearch(WordCount[] words, int low, int high, string word)
        {
            if (high < low)
                return low - 1;

            int mid = (high + low) / 2;
            
            if (word == words[mid].Word)
                return mid;

            else if (String.Compare(word, words[mid].Word) < 0)
                return BinarySearch(words, low, mid - 1, word);

            else
                return BinarySearch(words, mid + 1, high, word);
        }
    }
}
