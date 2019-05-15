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
        public MetaData(string Path)
        {
            _path = Path;
        }
        public string File { get { return _path + _data_file; } }
    }
}
