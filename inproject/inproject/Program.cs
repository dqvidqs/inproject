using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace inproject
{
    class Program
    {
        static private MetaData Meta;
        static void Main(string[] args)
        {
            Setup();
            Options();
            Console.ReadKey();
        }
        private static void Setup()
        {
            Meta = new MetaData(Directory.GetCurrentDirectory());
        }
        private static void Options()
        {
            string[] Command = Console.ReadLine().Split(' ');
            switch (Command[0])
            {
                case "load":
                    //Load(Command);
                    Classification.Train(Command);
                    break;
            }
            Options();
        }
        public static Data Read(int From, int To)
        {
            Data Temp = new Data();
            string[] Content = SplitContent();
            if(From == -1)
            {
                From = 0;
            }
            if(To == -1)
            {
                To = Content.Length;
            }
            for(int i = From; i < To; i++)
            {
                try
                {
                    Temp.Add(Content[i]);
                }
                catch
                {
                Console.WriteLine("Out of Range");
                }
            }
            return Temp;
        }
        private static string[] SplitContent()
        {
            string Content = File.ReadAllText(Meta.File);
            Content = Content.Replace("\r", "");
            return Content.Split('\n');
        }
    }
}
