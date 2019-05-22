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
                    Clas.LoadData(1, 901);
                    Clas.Train(Command);
                    break;
                case "knn":
                    KNearest nearest = new KNearest();
                    nearest.LoadData(901, 1001);
                    if (Command.Length == 1)
                    {
                        nearest.Valid(Clas.GetPoints(), Clas.GetTrainedIndexes(), Clas.GetGruopIndex(), 3);
                    }
                    if (Command.Length == 2)
                    {
                        nearest.Valid(Clas.GetPoints(), Clas.GetTrainedIndexes(), Clas.GetGruopIndex(), Convert.ToInt32(Command[1]));
                    }
                    break;
                case "crossk":
                    Cross cross = new Cross(Meta);
                    cross.KNN(Command);
                    break;
                case "linear"://pvz linear 7 6
                    LinearRegression linear = new LinearRegression();
                    linear.LoadData(1, 901, Command);
                    linear.Start();
                    break;
                case "crosslinear":// pvz crosslinear 6 7
                    CrossLinear cl = new CrossLinear(Meta);
                    cl.LinearRegression(Command);
                    break;
                case "backp":
                    BackProgTest test = new BackProgTest();
                    test.LoadData(1, 901, Command);
                    test.Valid(901, 1001, Command);
                    Console.WriteLine(test.getEFF());
                    test.LoadData(101, 1001, Command);
                    test.Valid(1, 101, Command);
                    Console.WriteLine(test.getEFF());
                    break;
                case "crossbp":
                    CrossBP crossBp = new CrossBP(Meta);
                    crossBp.CrossBp(Command);
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