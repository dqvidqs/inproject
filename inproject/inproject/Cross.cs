using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inproject
{
    class Cross
    {
        private const int _default_parts = 10;
        private MetaData Meta;
        private int[] Indexes;
        public Cross()
        {
            Indexes = GetIndexes(_default_parts, Meta.Count);
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

        public void KNN()
        {
            //for(int i = )
        }
    }
}
