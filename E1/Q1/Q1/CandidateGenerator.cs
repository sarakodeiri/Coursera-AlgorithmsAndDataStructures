using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public static class CandidateGenerator
    {
        public static readonly char[] Alphabet =
            Enumerable.Range('a', 'z' - 'a' + 1)
                      .Select(c => (char)c)
                      .ToArray();

        public static string[] GetCandidates(string word)
        {
            List<string> candidates = new List<string>();
            //TODO

            for (int i = 0; i < Alphabet.Length; i++)
                for (int j = 0; j < word.Length + 1; j++)
                    candidates.Add(Insert(word, j, Alphabet[i]));

            for (int i = 0; i < Alphabet.Length; i++)
                for (int j = 0; j < word.Length; j++)
                    candidates.Add(Substitute(word, j, Alphabet[i]));

            for (int j = 0; j < word.Length; j++)
                 candidates.Add(Delete(word, j));

            foreach (var a in candidates)
                Console.WriteLine(a);

            return candidates.ToArray();
        }

        private static string Insert(string word, int pos, char c)
        {
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length+1];
               
            for (int i=0; i<pos; i++)
                newWord[i] = wordChars[i];

            newWord[pos] = c;

            for (int i = pos + 1; i < newWord.Length; i++)
                newWord[i] = wordChars[i - 1];
            
            return new string(newWord);
        }

        private static string Delete(string word, int pos)
        {
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length-1];

            for (int i = 0; i < pos; i++)
                newWord[i] = wordChars[i];

            for (int i = pos + 1; i < wordChars.Length; i++)
                newWord[i - 1] = wordChars[i];

            //List<char> myWord = wordChars.ToList();
            //myWord.Remove(myWord[pos]);
            //newWord = myWord.ToArray();

            //TODO
            return new string(newWord);
        }

        private static string Substitute(string word, int pos, char c)
        {
            char[] wordChars = word.ToCharArray();
            char[] newWord = new char[wordChars.Length];


            for (int i = 0; i < pos; i++)
                newWord[i] = wordChars[i];

            newWord[pos] = c;

            for (int i = pos + 1; i < newWord.Length; i++)
                newWord[i] = wordChars[i];
            
            //TODO
            return new string(newWord);
        }

    }
}
