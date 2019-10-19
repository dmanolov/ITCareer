using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Брой_на_думите
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            List<string> availableWords = new List<string>();

            // reading every available word from word.txt
            using (StreamReader reader = new StreamReader("../../words.txt"))
            {
                string word = reader.ReadLine();
                while (word != null)
                {
                    availableWords.Add(word); 
                    word = reader.ReadLine();
                }
            }

            // reading every word in every line and checking for their occurences from text.txt
            using (StreamReader reader = new StreamReader("../../text.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] currentWords = line
                        .Split(new char[] { ' ', ',', '.', '!', '?', '-' }
                        , StringSplitOptions.RemoveEmptyEntries);

                    foreach (var sensitiveWord in currentWords)
                    {
                        string word = sensitiveWord.ToLower();

                        if (availableWords.Contains(word))
                        {
                            if (words.ContainsKey(word))
                            {
                                words[word]++;
                            }
                            else
                            {
                                words.Add(word, 1);
                            }
                        }
                    }
                    line = reader.ReadLine();
                }
            }

            // ordering words by their occurences
            words = words.OrderByDescending(w => w.Value)
                .ToDictionary(k => k.Key, v => v.Value);

            // writing the words and their occurences in result.txt file
            using (StreamWriter writer = new StreamWriter("../../result.txt"))
            {
                foreach (var word in words)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
