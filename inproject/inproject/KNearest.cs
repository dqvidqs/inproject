using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inproject
{
    class KNearest
    {
        private static double True = 0;
        private static double False = 0;
        private static int _default_k = 3;
        public  static int K { get { return _default_k; } }
        private static Data ValidData;
        public void LoadData(int From, int To)
        {
            ValidData = Program.Read(From, To);
        }
        public void Valid(Points[] TrainedPoints, int[,] TrainedIndexes, int IndexGruop, int KNN)
        {
            True = 0;
            False = 0;
            Console.WriteLine("K = {0}", KNN);
            //ValidData = Program.Read(901, 1001);
            for (int i = 0; i < ValidData.GetQuantity(); i++)
            {
                ValidOne(TrainedPoints, TrainedIndexes, i, IndexGruop, KNN);
            }
            Console.WriteLine("True Positive : {0}%", True / (True + False) * 100);
        }
        private static void ValidOne(Points[] TrainedPoints, int[,] TrainedIndexes, int index, int IndexGruop, int K)
        {

            Points ValidPoint = new Points(TrainedPoints.Length);
            string[] Gruop = new string[TrainedPoints.Length * K];
            int[] Counts = new int[TrainedPoints.Length * K];
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
                string[] gr = Check(TrainedPoints, i, K);
                int k = 0;
                foreach (string g in gr)
                {
                    Gruop[k + (i * K)] = g;
                    k++;
                }
            }
            for (int i = 0; i < TrainedPoints.Length * K; i++)
            {
                for (int j = 0; j < TrainedPoints.Length * K; j++)
                {
                    if (Gruop[j] == Gruop[i])
                    {
                        Counts[i]++;
                    }
                }
            }
            int max = 0;
            int current = -1;
            for (int i = 0; i < TrainedPoints.Length * K; i++)
            {
                if (Counts[i] > max)
                {
                    max = Counts[i];
                    current = i;
                }
            }
            if(Gruop[current] == ValidData.GetDataByIndex(index, IndexGruop))
            {
                True++;
            }
            else
            {
                False++;
            }
            //Console.WriteLine("{0,3} Guess: {1}; Correct: {2}", index,Gruop[current], ValidData.GetDataByIndex(index, IndexGruop));
        }
        private static string[] Check(Points[] TrainedPoints, int Index, int K)
        {
            int[] indexes = new int[K];
            double[] D = new double[K];
            string[] G = new string[K];
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