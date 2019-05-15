using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inproject
{
    class Classification
    {
        //K-Nearest Neighbors
        private static Data MainData;
        private string[] Gender;//gender
        private string[] Gruop;//race/ethnicity
        private string[] Parent_education;//parental level of education
        private string[] Lunch;//lunch
        private string[] Test;//test preparation course
        private int[] Math;//math score
        private int[] Reading;//reading score
        private int[] Writing;//writing score
        public static void Start()
        {
            MainData = Program.Read(1, 901);
        }
    }
}
