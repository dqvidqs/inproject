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
        public static void Train(string[] Command)
        {
            int size = SelectIndex(Command);
            MainData = Program.Read(1, 901);
            TrainPoints = new Points[size];
            for(int i = 0; i < size; i++)
            {
                TrainPoints[i] = new Points(Convert.ToString(TrainIndex[i, 0]), Convert.ToString(TrainIndex[i, 1]));
                //TrainPoints[i] = new Points();
                for (int j = 0; j < MainData.GetQuantity(); j++)
                {
                    TrainPoints[i].Coo[i].X = Convert.ToInt32(MainData.GetDataByIndex(j, TrainIndex[i, 0]));
                    TrainPoints[i].Coo[i].Y = Convert.ToInt32(MainData.GetDataByIndex(j, TrainIndex[i, 0]));
                }
            }
        }
        private static int SelectIndex(string[] Command)
        {
            int[] indexes = new int[Command.Length - 1];
            for (int k = 1; k < Command.Length; k++)
            {
                indexes[k - 1] = Convert.ToInt32(Command[k]);
            }
            int size = Factorial(indexes.Length)/(2*(Factorial(indexes.Length-2)));
            TrainIndex = new int[size, 2];
            int i = 0;
            int j = 0;
            for (int k = 0; k < indexes.Length - 1; k++)
            {
                for (int l = k+1; l < indexes.Length; l++)
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
    }
}
