using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_Activity_24
{
    internal class Program
    {
        class Review
        {
            public string Text { get; private set; }
            public string Sentiment { get; private set; }

            public Review(string text)
            {
                Text = text.Trim();
            }
            public void Analyze(string[] positiveKeywords, string[] negativeKeywords)
            {
                string clean = Text.ToLower();
                
                clean = clean.Replace(".", "").Replace(",", "").Replace("!", "").Replace("?", "");

                string[] words = clean.Split(' ');

                int posCount = 0;
                int negCount = 0;

                foreach (string w in words)
                {
                    foreach (string p in positiveKeywords)
                    {
                        if (w == p) posCount++;
                    }
                    foreach (string n in negativeKeywords)
                    {
                        if (w == n) negCount++;
                    }
                }
                if (posCount > negCount) Sentiment = "Positive";
                else if (negCount > posCount) Sentiment = "Negative";
                else Sentiment = "Neutral";
            }
        }
        static void Main()
        {
            string[] positiveKeywords = { "good", "great", "excellent", "happy", "love" };
            string[] negativeKeywords = { "bad", "poor", "terrible", "sad", "hate" };

            Console.WriteLine("Enter number of reviews:");
            int n = int.Parse(Console.ReadLine());

            List<Review> reviews = new List<Review>();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter review #" + (i + 1) + ":");
                string text = Console.ReadLine();
                Review r = new Review(text);
                r.Analyze(positiveKeywords, negativeKeywords);
                reviews.Add(r);
            }

            int pos = 0, neg = 0, neu = 0;

            Console.WriteLine("Review Sentiments");
            for (int i = 0; i < reviews.Count; i++)
            {
                Console.WriteLine("Review #" + (i + 1) + ": " + reviews[i].Sentiment);
                if (reviews[i].Sentiment == "Positive") pos++;
                else if (reviews[i].Sentiment == "Negative") neg++;
                else neu++;
            }

            Console.WriteLine("\nTotal Reviews: " + n);
            Console.WriteLine("Positive: " + pos);
            Console.WriteLine("Negative: " + neg);
            Console.WriteLine("Neutral: " + neu);
        }
    }
}
            
