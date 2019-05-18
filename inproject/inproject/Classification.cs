using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inproject
{
    class Classification
    {
        private static Data MainData;
        private static Points[] TrainPoints;
        private static int[,] TrainIndex;
        private static string[] Gruop;
        public static void Train(string[] Command)
        {
            //command: load [grupe] [klasifikuot,klasifikuot..]
            //pvz load 1 5 6 7
            int size = SelectIndex(Command);
            int gr = Convert.ToInt32(Command[1]);           
            MainData = Program.Read(1, 901);
            Gruop = GetGruops(gr);
            TrainPoints = new Points[size];
            for (int i = 0; i < size; i++)
            {
                TrainPoints[i] = new Points(Convert.ToString(TrainIndex[i, 0]), Convert.ToString(TrainIndex[i, 1]));
                //TrainPoints[i] = new Points();
                for (int j = 0; j < MainData.GetQuantity(); j++)
                {
                    for (int k = 0; k < Gruop.Length; k++) {
                        if (MainData.GetDataByIndex(j, gr) == Gruop[k]) {
                            TrainPoints[i].Coo[j].X = Convert.ToInt32(MainData.GetDataByIndex(j, TrainIndex[i, 0]));
                            TrainPoints[i].Coo[j].Y = Convert.ToInt32(MainData.GetDataByIndex(j, TrainIndex[i, 0]));
                            TrainPoints[i].Coo[j].Gruop = k;
                        }
                    }
                }
            }
        }
        private static int SelectIndex(string[] Command)
        {
            int[] indexes = new int[Command.Length - 2];
            for (int k = 2; k < Command.Length; k++)
            {
                indexes[k - 2] = Convert.ToInt32(Command[k]);
            }
            int size = Factorial(indexes.Length) / (2 * (Factorial(indexes.Length - 2)));
            TrainIndex = new int[size, 2];
            int i = 0;
            int j = 0;
            for (int k = 0; k < indexes.Length - 1; k++)
            {
                for (int l = k + 1; l < indexes.Length; l++)
                {
                    TrainIndex[i, j % 2] = indexes[k];
                    j++;
                    TrainIndex[i, j % 2] = indexes[l];
                    j++;
                    i++;
                }
            }
            return size;
        }
        private static int Factorial(int n)
        {
            int factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
        private static string[] GetGruops(int gr)
        {
            List<string> gruop = new List<string>();
            for (int i = 0; i < MainData.GetQuantity(); i++)
            {
                if (!gruop.Contains(MainData.GetDataByIndex(i, gr)))
                {
                    gruop.Add(MainData.GetDataByIndex(i, gr));
                }
            }
            return gruop.ToArray();
        }
    }
}
