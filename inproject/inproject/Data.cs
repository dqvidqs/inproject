using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inproject
{
    class Data
    {
        private class Student
        {
            private string[] Row = new string[8];
            private string _gender;//gender
            private string _gruop;//race/ethnicity
            private string _parent_education;//parental level of education
            private string _lunch;//lunch
            private string _test;//test preparation course
            private int _math;//math score
            private int _reading;//reading score
            private int _writing;//writing score*/
            public Student(string DataString)
            {
                try
                {
                    string[] Row = DataString.Split(',');
                    for (int i = 0; i < this.Row.Length; i++)
                    {
                        this.Row[i] = Row[i];
                    }
                    this._gender = Row[0];
                    this._gruop = Row[1];
                    this._parent_education = Row[2];
                    this._lunch = Row[3];
                    this._test = Row[4];
                    this._math = Convert.ToInt32(Row[5]);
                    this._reading = Convert.ToInt32(Row[6]);
                    this._writing = Convert.ToInt32(Row[7]);
                }
                catch
                {
                    Console.WriteLine("Incorrect Data Line!");
                }
            }
            public string GetRowByIndex(int i)
            {
                return this.Row[i];
            }
        }
        private Student[] Students;
        private const int _default_quantity = 1000;
        private int Quantity;
        public Data()
        {
            this.Quantity = 0;
            Students = new Student[_default_quantity];
        }
        public Data(int Quantity)
        {
            this.Quantity = 0;
            Students = new Student[Quantity];
        }
        public bool Add(string Row)
        {
            if (Quantity == Students.Length)
            {
                Console.WriteLine("Overflow Data");
                return false;
            }
            Students[Quantity] = new Student(Row);
            Quantity++;
            return true;
        }
        public string GetDataByIndex(int i, int y)
        {
            return Students[i].GetRowByIndex(y);
        }
        public int GetQuantity()
        {
            return Quantity;
        }
    }
}
