using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inproject
{
    class CrossBP
    {
        private const int _default_parts = 10;
        private MetaData Meta;
        private int[] Indexes;
        public CrossBP(MetaData Data)
        {
            Meta = Data;
            Indexes = GetIndexes(_default_parts, Meta.Count);
            for (int i = 0; i < Indexes.Length - 1; i++)
            {
                Indexes[i] += Meta.Ignore;
            }
        }
        private int[] GetIndexes(int Parts, int Quantity)
        {
            int[] indexes = new int[Parts + 1];
            int current = Quantity / Parts;
            int part = current;
            for (int i = 1; i < indexes.Length - 1; i++)
            {
                indexes[i] = current;
                current += part;
            }
            indexes[indexes.Length - 1] = Quantity;
            return indexes;
        }
        public void CrossBp(string[] Command)
        {
            for (int i = 0; i < Indexes.Length - 1; i++)
            {
                int min = 0 + Meta.Ignore;
                int max = Meta.Count;
                BackProgTest bp = new BackProgTest();
                bp.LoadData(Indexes[i], Indexes[i + 1], Command);
                Console.WriteLine(bp.getEFF());
            }
        }
    }
}
