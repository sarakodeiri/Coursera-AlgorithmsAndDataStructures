using System;
using System.Linq;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class PhoneBook : Processor
    {
        public PhoneBook(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        
        public string[] Solve(string [] commands)
        {
            Dictionary<long, string> phoneBook = new Dictionary<long, string>();
            List<string> result = new List<string>();

            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var args = toks.Skip(1).ToArray();
                int number = int.Parse(args[0]);

                switch (cmdType)
                {
                    case "add":
                        Add(args[1], number, phoneBook); break;
                    case "del":
                        Delete(number, phoneBook); break;
                    case "find":
                        result.Add(Find(number, phoneBook)); break;
                }
            }
            return result.ToArray();
        }

        public void Add(string name, int number, Dictionary<long, string> phoneBook)
        {
            if (phoneBook.ContainsKey(number))
                phoneBook.Remove(number);
            phoneBook.Add(number, name);
        }

        public string Find(int number, Dictionary<long, string> phoneBook)
        {
            if (phoneBook.ContainsKey(number))
                return phoneBook[number];
            return "not found";
        }

        public void Delete(int number, Dictionary<long, string> phoneBook)
        {
            if (phoneBook.ContainsKey(number))
                phoneBook.Remove(number);
        }
    }
}
