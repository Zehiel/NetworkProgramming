using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MathSeries
{
    class Program
    {
        static List<double> values = new List<double>();

        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            
            double a = 2;
            double n = 1;
            do
            {
                System.Console.WriteLine(calculateSeriesValue(a, n));
                System.Console.WriteLine(calculateSeriesSum(values));
                n++;
                Thread.Sleep(1000);

            } while (Console.KeyAvailable == false);

        }

        static double calculateSeriesValue(double a,double n)
        {
            double value = Math.Pow(-1, n - 1) / ((2 * n) - 1);
            values.Add(value);
            return value;
        }

        static double calculateSeriesSum(List<double> inputValues)
        {
            double firstValue = (double)inputValues[0];
            double lastValue = (double)inputValues[inputValues.Count-1];
            double n = inputValues.Count;
            double sum = ((firstValue + lastValue) / 2) * n;
            return sum;
        }
    }
}
