using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Genetic_Algorithms
{
    //internal record Product(string Name, float price, float weight);


    internal class Program
    {
        public class Game
        {
            public string name { get; }

            public Game(string name)
            {
                this.name = name;
            }
        }



        public static class MyConsole
        {
            public static void Color(string Message, ConsoleColor Color)
            {
                Console.ForegroundColor = Color;
                Console.WriteLine(Message);
                Console.ResetColor();
            }
        }
     

        static void Main(string[] args)
        {
            List<string> productName = new List<string>();
            List<float> productPrice = new List<float>();
            List<float> productWeight = new List<float>();
            List<string> containsObjects = new List<string>();
            Random rnd = new Random();
            MyConsole.Color("Please write your directory of file", ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Red;
            string Dir = Console.ReadLine();
            Console.ResetColor();
            MyConsole.Color("Please write your Output of directory", ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Red;
            string Output = Console.ReadLine();
            Console.ResetColor();
            MyConsole.Color("Please write the file name", ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Red;
            string FileName = Console.ReadLine();
            Console.ResetColor();
            Console.ResetColor();
            MyConsole.Color("Please enter the Quantity of tries", ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Red;
            int NumbOfTimes = int.Parse(Console.ReadLine());
            int NumbOfFlips = 10;
            //each line is a difrent string*/
            string[] products = File.ReadAllLines(Dir);
            foreach (string productLine in products)
            {
                List<string> productItems = productLine.Split(';').ToList();

                productName.Add(productItems[0]);
                productPrice.Add(float.Parse(productItems[1], CultureInfo.InvariantCulture.NumberFormat));
                productWeight.Add(float.Parse(productItems[2], CultureInfo.InvariantCulture.NumberFormat));
            }

            List<bool> isIncluded = new List<bool>();
            float productPricesum = 0;
            float productWeightsum = 0;
            int counteditems = 0;
            //foreach () { }
            for (int i = 0; i < productName.Count; i++)
            {
                bool StatusBool = rnd.Next(2) == 0;
                Console.WriteLine(StatusBool);
                if (StatusBool)
				{
                    float.TryParse(productWeight[i].ToString(), out float floatparsedValue);
                    productWeightsum += floatparsedValue;
                    //Console.WriteLine("orgnl: " + productWeightsum + " + " + floatparsedValue + "=" + (productWeightsum + floatparsedValue));
                    float.TryParse(productPrice[i].ToString(), out floatparsedValue);
                    //Console.WriteLine("orgnl: " + productPricesum + " + " + floatparsedValue + "=" + (productPricesum + floatparsedValue));
                    productPricesum += floatparsedValue;
                    counteditems++;
                }
                isIncluded.Add(StatusBool);
            }
            Console.WriteLine("productWeightsum: " + productWeightsum/1000 + " productPricesum:" + productPricesum);
            Console.WriteLine("counteditems: " + counteditems);
            // i want to make multiple of the list 

            //flips the code
            for (int i = 0; i < NumbOfFlips; i++)
            {   
                int indexToFlip = rnd.Next(productName.Count);
				isIncluded[indexToFlip] = !isIncluded[indexToFlip];
                Console.WriteLine("Flipping: " + indexToFlip + " to: " + isIncluded[indexToFlip]);
            }
            foreach (bool b in isIncluded)
			{
                if (b)
                {
                    Console.Write("1");
                }
                else Console.Write("0");
			}
            Console.WriteLine();
            //     for (int i = 0; i < NumbOfTimes; i++)
            //     {
            //         for (int a = 0; a < productName.Count; a++)
            //{
            //                 containsObjects.Add(rnd.Next(0, 2).ToString());
            //                 Console.WriteLine("i: " + i + " a: " + a);
            //         }
            //     }
            //this puts all of it into a .txt file  
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Output, (FileName) + ".txt")))
                {

                foreach (string a in productName)
                {
                    outputFile.WriteLine(a);
                }
                foreach (float b in productPrice)
                {
                    outputFile.WriteLine(b);
                }
                foreach (float c in productWeight)
                {
                    outputFile.WriteLine(c);
                }
            }

            //var games = Lines.Select(b => new Game(b)).ToList();
                MyConsole.Color("Press any key to exit.", ConsoleColor.Green);
                System.Console.ReadKey();
        }
    }
}
