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
        private static List<double> values = new List<double>();
        private static Random _random = new Random();



        private static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            int currentValueCursorLeft;
            int currentValueCursorTop;            
            double n = 1;


            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(100, 30);
            Console.SetWindowSize(100, 35);
            Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop);
            Console.Title = "Calculate Series Value and Sum";
            do
            {
                currentValueCursorLeft = Console.CursorLeft;
                currentValueCursorTop = Console.CursorTop;
                gotoxy(Console.WindowTop+80,Console.WindowLeft+9);
                System.Console.Write("                   ");                
                gotoxy(Console.WindowTop + 80, Console.WindowLeft + 10);
                System.Console.Write(String.Format("{0,7:0.0000}", calculateSeriesSum(values)));
                gotoxy(currentValueCursorLeft, currentValueCursorTop);
                Console.BackgroundColor = GetRandomConsoleColor();
                Console.ForegroundColor = GetRandomConsoleColor();
                System.Console.Write(String.Format("{0,7:0.0000}", calculateSeriesValue(a, n)));
                Console.ResetColor();
                System.Console.Write("\n");
                
                n++;
                Thread.Sleep(100);

            } while (Console.KeyAvailable == false);

        }

        /*
        ***************************************************************************       
        * Name: double calculateSeriesValue(double a,double n)
        * Description: Function calculating value of the sequence's term
        * Arguments: n - number of term to calculate 
        * Returns: calculated value in form of double type variable
        * Uses: none
        * Modifies: values (List of calculated terms)
        * Author: Andrzej Borzęcki 28.02.2017
        ***************************************************************************
        */

        private static double calculateSeriesValue(double n)
        {
            double value = Math.Pow(-1, n - 1) / ((2 * n) - 1);
            values.Add(value);
            return value;
        }

        /*
        ***************************************************************************       
        * Name: double calculateSeriesSum(List<double> inputValues)
        * Description: Function calculating sum of the sequence
        * Arguments: inputValues - List of already calculated sequence terms
        * Returns: calculated sum in form of double type variable
        * Uses: none
        * Modifies: none
        * Author: Andrzej Borzęcki 28.02.2017
        ***************************************************************************
        */

        private static double calculateSeriesSum(List<double> inputValues)
        {
            if (inputValues.Count > 0)
            {
                double firstValue = (double)inputValues[0];
                double lastValue = (double)inputValues[inputValues.Count - 1];
                double n = inputValues.Count;
                double sum = ((firstValue + lastValue) / 2) * n;
                return sum;
            }else
            {
                return 0;
            }
            
        }

        /*
        ***************************************************************************       
        * Name: void gotoxy(int x,int y)
        * Description: Wrapper for setting current console text cursor position
        * Arguments: x - position in x axis
        *            y - position in y axis
        * Returns: none
        * Uses: System
        * Modifies: none
        * Author: Andrzej Borzęcki 28.02.2017
        ***************************************************************************
        */

        private static void gotoxy(int x,int y)
        {
            Console.SetCursorPosition(x, y);
        }

        /*
        ***************************************************************************       
        * Name: ConsoleColor GetRandomConsoleColor()
        * Description: Function returning random ConsolColor from list of avalible ConsolColors
        * Arguments: none
        * Returns: randomized color
        * Uses: System
        * Modifies: none
        * Author: Andrzej Borzęcki 28.02.2017
        ***************************************************************************
        */

        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }

    }
}
