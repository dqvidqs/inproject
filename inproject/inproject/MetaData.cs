using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inproject
{
    class MetaData
    {
        private string _path;
        private const string _data_file = "\\StudentsPerformance.csv";
        private int _data_count_row = 1001;
        public int Count { get { return _data_count_row; } set { _data_count_row = value; } }
        private int _first_ignore_Lines = 1;
        public int Ignore { get { return _first_ignore_Lines; } set { _first_ignore_Lines = value; } }
        public MetaData(string Path)
        {
            _path = Path;
        }
        public string File { get { return _path + _data_file; } }
    }
}
