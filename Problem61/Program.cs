using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem61
{
    public class Frequency
    {
        public string term { get; set; }
        public int frequency { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] stopwords = new StreamReader("stop_words.txt").ReadToEnd().ToLower().TrimEnd('\n').TrimEnd('\n').TrimEnd(',').Split(',');
            List<string> text = new StreamReader("pride-and-prejudice.txt").ReadToEnd().ToLower().Replace("_", "").Replace(".", "").Replace("'s", "").Replace(",", "").Replace("\n\n", " ").Replace("\n", " ").Split(' ').ToList();

            List<Frequency> result = new List<Frequency>();

            text.ForEach(word => result.Add(new Frequency { term = text.Where(match => match == word && stopwords.Contains(word) == false).Count() == 0 ? "A-Z" : text.Where(match => match == word && stopwords.Contains(word) == false).FirstOrDefault(term => term == word).ToString(), frequency = text.Where(match => match == word && stopwords.Contains(word) == false).Count() == 0 ? 0 : text.Count(match => match == word) }));

            //foreach (string token in text)
            //{
            ////    //var match = from word in text where word == token where stopwords.Contains(word) == false select word;
            //    var match = text.Where(x => x == token && stopwords.Contains(token) == false).ToList();
            //    try
            //    {
            //        result.Add(new Frequency { term = match.FirstOrDefault(x => x == token).ToString(), frequency = match.Count() });
            //    }
            //    catch { }
            //}

            Console.ReadKey();
        }
    }
}
