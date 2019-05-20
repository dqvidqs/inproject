using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inproject
{
    class KNearest
    {
        private static Data ValidData;
        private static int MAX_COUNT_GUESS = 3;
        public static void Valid(Points[] TrainedPoints, int[,] TrainedIndexes)
        {
            ValidData = Program.Read(901, 1001);
            for (int i = 0; i < ValidData.GetQuantity(); i++)
            {
                ValidOne(TrainedPoints, TrainedIndexes, i);
            }

        }
        private static void ValidOne(Points[] TrainedPoints, int[,] TrainedIndexes, int index)
        {
            Points ValidPoint = new Points(TrainedPoints.Length);
            string[] Gruop = new string[TrainedPoints.Length * MAX_COUNT_GUESS];
            int[] Counts = new int[TrainedPoints.Length * MAX_COUNT_GUESS];
            for (int i = 0; i < TrainedPoints.Length; i++)
            {
                ValidPoint.Coo[i].X = Convert.ToInt32(ValidData.GetDataByIndex(index, TrainedIndexes[i, 0]));
                ValidPoint.Coo[i].Y = Convert.ToInt32(ValidData.GetDataByIndex(index, TrainedIndexes[i, 1]));
                for (int j = 0; j < TrainedPoints[i].GetQuantity(); j++)
                {
                    double ax = TrainedPoints[i].Coo[j].X;
                    double ay = TrainedPoints[i].Coo[j].Y;
                    double bx = ValidPoint.Coo[i].X;
                    double by = ValidPoint.Coo[i].Y;
                    TrainedPoints[i].Coo[j].Distance = Math.Sqrt((ax - bx) * (ax - bx) + (ay - by) * (ay - by));
                }
                string[] gr = Check(TrainedPoints, i);
                int k = 0;
                foreach (string g in gr)
                {
                    Gruop[k + (i * MAX_COUNT_GUESS)] = g;
                    k++;
                }
            }
            for (int i = 0; i < TrainedPoints.Length * MAX_COUNT_GUESS; i++)
            {
                for (int j = 0; j < TrainedPoints.Length * MAX_COUNT_GUESS; j++)
                {
                    if (Gruop[j] == Gruop[i])
                    {
                        Counts[i]++;
                    }
                }
            }
            int max = 0;
            int current = -1;
            for (int i = 0; i < TrainedPoints.Length * MAX_COUNT_GUESS; i++)
            {
                if (Counts[i] > max)
                {
                    max = Counts[i];
                    current = i;
                }
            }
            Console.WriteLine("{0,3} Guess: {1}; Correct: {2}", index+2,Gruop[current]);
        }
        private static string[] Check(Points[] TrainedPoints, int Index)
        {
            int[] indexes = new int[MAX_COUNT_GUESS];
            double[] D = new double[MAX_COUNT_GUESS];
            string[] G = new string[MAX_COUNT_GUESS];
            for (int i = 0; i < D.Length; i++)
            {
                indexes[i] = -1;
                D[i] = 999;
            }
            for (int i = 0; i < D.Length; i++)
            {
                int index = -1;
                for (int j = 0; j < TrainedPoints[Index].GetQuantity(); j++)
                {
                    if (TrainedPoints[Index].Coo[j].Distance < D[i] & CheckIndex(indexes, j))
                    {
                        D[i] = TrainedPoints[Index].Coo[j].Distance;
                        G[i] = TrainedPoints[Index].Coo[j].Gruop;
                        index = j;
                    }
                }
                indexes[i] = index;
                //TrainedPoints[Index].Coo[index].Distance = 999;
            }
            return G;
        }
        private static bool CheckIndex(int[] indexes, int Index)
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] == Index)
                {
                    return false;
                }
            }
            return true;
        }
    }
}