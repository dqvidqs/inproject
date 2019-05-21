using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inproject
{
    class LinearRegression
    {
        private static Data MainData;
        private double[] xValues;
        private double[] yValues;
        private static double correct = 0;
        private static double incorrect = 0;

        public void LoadData(int From, int To, string[] Command)
        {
            correct = 0;
            incorrect = 0;
            MainData = Program.Read(From, To);
            xValues = new double[MainData.GetQuantity()];
            yValues = new double[MainData.GetQuantity()];
            for (int j = 0; j < MainData.GetQuantity(); j++)
            {
                xValues[j] = Convert.ToInt32(MainData.GetDataByIndex(j, Convert.ToInt32(Command[1])));
                yValues[j] = Convert.ToInt32(MainData.GetDataByIndex(j, Convert.ToInt32(Command[2])));
            }
        }
        public void Start()
        {
            double quantity = MainData.GetQuantity();
            double rSquared, intercept, slope;

            Regression(xValues, yValues, out rSquared, out intercept, out slope);

            //Console.WriteLine($"R-squared = {rSquared}");
            //Console.WriteLine($"Intercept = {intercept}");
            //Console.WriteLine($"Slope = {slope}");
            for (int i = 0; i < xValues.Length; i++)
            {
                var prediction = (slope * xValues[i]) + intercept;
                //Console.WriteLine("X value : {0, 3} Y value: {1, 3} Y prediction: {2, 3}", xValues[i], yValues[i], prediction);
                if (yValues[i] > prediction - 5 && yValues[i] < prediction + 5)
                {
                    correct++;
                }
                else
                {
                    incorrect++;
                }

            }
            double percent = correct / quantity * 100;
            //Console.WriteLine("correct(+-5): {0}/{1} ({2}%)", correct, xValues.Length, Math.Round(percent, 2));
            Console.WriteLine("True Positive : {0}%", Math.Round(percent, 2));

        }
        /// <summary>
        /// Fits a line to a collection of (x,y) points.
        /// </summary>
        /// <param name="xVals">The x-axis values.</param>
        /// <param name="yVals">The y-axis values.</param>
        /// <param name="rSquared">The r^2 value of the line.</param>
        /// <param name="yIntercept">The y-intercept value of the line (i.e. y = ax + b, yIntercept is b).</param>
        /// <param name="slope">The slop of the line (i.e. y = ax + b, slope is a).</param>
        public static void Regression(double[] xVals, double[] yVals, out double rSquared, out double yIntercept, out double slope)
        {
            if (xVals.Length != yVals.Length)
            {
                throw new Exception("Input values should be with the same length.");
            }

            double sumOfX = 0;
            double sumOfY = 0;
            double sumOfXSq = 0;
            double sumOfYSq = 0;
            double sumCodeviates = 0;

            for (var i = 0; i < xVals.Length; i++)
            {
                var x = xVals[i];
                var y = yVals[i];
                sumCodeviates += x * y;
                sumOfX += x;
                sumOfY += y;
                sumOfXSq += x * x;
                sumOfYSq += y * y;
            }

            var count = xVals.Length;
            var ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
            var ssY = sumOfYSq - ((sumOfY * sumOfY) / count);

            var rNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
            var rDenom = (count * sumOfXSq - (sumOfX * sumOfX)) * (count * sumOfYSq - (sumOfY * sumOfY));
            var sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

            var meanX = sumOfX / count;
            var meanY = sumOfY / count;
            var dblR = rNumerator / Math.Sqrt(rDenom);

            rSquared = dblR * dblR;
            yIntercept = meanY - ((sCo / ssX) * meanX);
            slope = sCo / ssX;
        }
    }
}
