using News.Logic.DB;
using News.Logic.Manager;
using System;

namespace NewsConsole
{
    class Program
    {
        private static NewsManager news = new NewsManager();
        private static TopicManager topics = new TopicManager();
        
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("The list of Topics: ");
            Console.ResetColor();
            Console.WriteLine();
            topics.GetAllTopics().ForEach(topic =>
            {
                Console.WriteLine(topic.Title);
            });
            
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("The list of Articles: ");
            Console.ResetColor();
            Console.WriteLine();
            news.GetLatestNews().ForEach(article =>
            {
                Console.WriteLine(article.Title);
            });

        }
    }
}
