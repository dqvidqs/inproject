using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inproject
{
    class BackProgTest
    {
        private static Data MainData;
        private static Data ValidData;
        private  int correct = 0;
        private  int incorrect = 0;
        private float[] values1;
        private float[] values2;
        private float[] values3;
        private float[] answers;
        private float avg;
        NeuralNetwork net = new NeuralNetwork(new int[] { 3, 8, 3, 1 }); //intiilize network
        public void LoadData(int From, int To, string[] Command)
        {
            correct = 0;
            avg = 0;
            MainData = Program.Read(From, To);
           
            values1 = new float[MainData.GetQuantity()];
            values2 = new float[MainData.GetQuantity()];
            values3 = new float[MainData.GetQuantity()];
            answers = new float[MainData.GetQuantity()];
            float sum = 0;
            for (int j = 0; j < MainData.GetQuantity(); j++)
            {
                float grade = float.Parse(MainData.GetDataByIndex(j, Convert.ToInt32(Command[4])));
                sum += grade;
            }
            avg = sum/MainData.GetQuantity();

            for (int j = 0; j < MainData.GetQuantity(); j++)
            {
                string gender = MainData.GetDataByIndex(j, Convert.ToInt32(Command[1]));
                if (gender == "male")
                {
                    values1[j] = 0;
                }
                else
                {
                    values1[j] = 1;
                }
                string edu = MainData.GetDataByIndex(j, Convert.ToInt32(Command[2]));
                switch (edu)
                {
                    case "bachelor's degree":
                        values2[j] = 1;
                        break;
                    case "some college":
                        values2[j] = 2;
                        break;
                    case "master's degree":
                        values2[j] = 3;
                        break;
                    case "associate's degree":
                        values2[j] = 4;
                        break;
                    case "high school":
                        values2[j] = 5;
                        break;
                    case "some high school":
                        values2[j] = 6;
                        break;
                }

                string prep = MainData.GetDataByIndex(j, Convert.ToInt32(Command[3]));
                if (prep == "none")
                {
                    values3[j] = 0;
                }
                else
                {
                    values3[j] = 1;
                }
                
                float grade = float.Parse(MainData.GetDataByIndex(j, Convert.ToInt32(Command[4])));
                if (grade < avg)
                {
                    answers[j] = 0;
                }
                else if(grade >= avg)
                {
                    answers[j] = 1;
                }

            }
            int testIter = 10000;
            //Itterate n times and train each possible output
            Console.WriteLine("train started");
            for (int i = 0; i < testIter; i++)
            {
                if((float)i*100f/(float)testIter%10 == 0)
                    Console.WriteLine("Training: " +(float)i * 100f / (float)testIter + "%");
                for (int j = 0; j < MainData.GetQuantity(); j++)
                {
                    net.FeedForward(new float[] { values1[j], values2[j],values3[j]});
                    net.BackProp(new float[] { answers[j] });
                    
                }
              
            }
            Console.WriteLine("train ended");

        }
        public void Valid(int From, int To, string[] Command)
        {
            ValidData = Program.Read(From, To);
            for (int k = 0; k < ValidData.GetQuantity(); k++)
            {
                float a;
                float b;
                float c;
                float ans;
                string gender = MainData.GetDataByIndex(k, Convert.ToInt32(Command[1]));
                if (gender == "male")
                {
                    a = 0;
                }
                else
                {
                    a = 1;
                }
                string edu = MainData.GetDataByIndex(k, Convert.ToInt32(Command[2]));
                switch (edu)
                {
                    case "bachelor's degree":
                        b = 1;
                        break;
                    case "some college":
                        b = 2;
                        break;
                    case "master's degree":
                        b = 3;
                        break;
                    case "associate's degree":
                        b = 4;
                        break;
                    case "high school":
                        b = 5;
                        break;
                    case "some high school":
                        b = 6;
                        break;
                    default:
                        b = 0;
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                }
                string prep = MainData.GetDataByIndex(k, Convert.ToInt32(Command[3]));
                if (prep == "none")
                {
                    c = 0;
                }
                else
                {
                    c = 1;
                }
                float grade = float.Parse(MainData.GetDataByIndex(k, Convert.ToInt32(Command[4])));
                if (grade < avg)
                {
                    ans = 0;
                }
                else if (grade >= avg)
                {
                    ans = 1;
                }
                else ans = -1;
                float ret = net.FeedForward(new float[] { a, b, c })[0];
                //Console.WriteLine(ret + " " + ans);
                if (ret > 0.5f && ans == 1)
                {
                    correct++;
                }
                else if (ret < 0.5f && ans == 0)
                {
                    correct++;
                }
                else if (ret > 0.5f && ans == 0)
                {
                    incorrect++;
                }
                else if (ret < 0.5f && ans == 1)
                {
                    incorrect++;
                }
            }
        }
        public float getEFF()
        {
            return (float)correct / (float)ValidData.GetQuantity();
        }
    }
}
