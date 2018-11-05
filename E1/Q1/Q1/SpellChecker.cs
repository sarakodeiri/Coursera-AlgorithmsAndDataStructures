using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class SpellChecker
    {
        public readonly FastLM LanguageModel;

        public SpellChecker(FastLM lm)
        {
            this.LanguageModel = lm;
        }

        public string[] Check(string misspelling)
        {
            List<WordCount> candidates = 
                new List<WordCount>();

            //TODO 

            List<string> oneEditDistance = CandidateGenerator.GetCandidates(misspelling).ToList();
            oneEditDistance.Add(misspelling);

            oneEditDistance.OrderBy(i => i);
            LanguageModel.WordCounts.OrderBy(i => i.Word);

            List<WordCount> finals = new List<WordCount>();

            //NAIVE
            //for (int i = 0; i < oneEditDistance.Count; i++)
            //    for (int j = 0; j < LanguageModel.WordCounts.Length; j++)
            //        if (LanguageModel.WordCounts[j].Word == oneEditDistance[i])
            //            finals.Add(LanguageModel.WordCounts[j]);

            for (int i=0; i<LanguageModel.WordCounts.Count(); i++)
            {
                long index = BinarySearch(oneEditDistance.ToArray(), 0, oneEditDistance.Count - 1, 
                    LanguageModel.WordCounts[i].Word);
                if (oneEditDistance[i] == LanguageModel.WordCounts[(int)index].Word)
                    finals.Add(LanguageModel.WordCounts[(int)index]);

            }

                    return finals
                    .OrderByDescending(x => x.Count)
                    .Select(x => x.Word)
                    .Distinct()
                    .ToArray();
        }

        public long BinarySearch(string[] words, int low, int high, string word)
        {
            if (high < low)
                return low - 1;

            int mid = (high + low) / 2;

            if (word == words[mid])
                return mid;

            else if (String.Compare(word, words[mid]) < 0)
                return BinarySearch(words, low, mid - 1, word);

            else
                return BinarySearch(words, mid + 1, high, word);
        }

        public string[] SlowCheck(string misspelling)
        {
            List<WordCount> candidates =
                new List<WordCount>();
            // TODO

            return candidates
                    .OrderByDescending(x => x.Count)
                    .Select(x => x.Word)
                    .Distinct()
                    .ToArray();
        }

        public int EditDistance(string str1, string str2)
        {
            int n = str1.Length;
            int m = str2.Length;

            int[,] Distance = new int[n + 1, m + 1];
            for (int i = 0; i < n + 1; i++)
            {
                Distance[i, 0] = i;
            }

            for (int j = 0; j < m + 1; j++)
            {
                Distance[0, j] = j;
            }

            for (int j = 1; j <= m; j++)
            {
                for (int i = 1; i <= n; i++)
                {
                    // TODO
                }
            }
            return Distance[n, m];
        }
    }
}
