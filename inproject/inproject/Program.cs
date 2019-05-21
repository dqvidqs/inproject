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
        static private Classification Clas;
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
            switch (Command[0].ToLower())
            {
                case "load":
                    //Load(Command);
                    Clas = new Classification();
                    Clas.Train(Command);

                    break;
                case "knn":
                    if (Command.Length == 1)
                    {
                        KNearest.Valid(Clas.GetPoints(), Clas.GetTrainedIndexes(), Clas.GetGruopIndex(), 3);
                    }
                    if (Command.Length == 2)
                    {
                        KNearest.Valid(Clas.GetPoints(), Clas.GetTrainedIndexes(), Clas.GetGruopIndex(), Convert.ToInt32(Command[1]));
                    }
                    break;
            }
            Options();
        }
        public static Data Read(int From, int To)
        {
            // Data Temp = new Data();
            Data Temp = new Data(900);
            string[] Content = SplitContent();
            if (From == -1)
            {
                From = 0;
            }
            if (To == -1)
            {
                To = Content.Length;
            }
            for (int i = From; i < To; i++)
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