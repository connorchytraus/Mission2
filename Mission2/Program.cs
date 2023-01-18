using System;
using System.Collections.Generic;

namespace Mission2
{
    class Program
    {
        static void Main(string[] args)
        {
            //create variables
            string ?number = "";

            // initialize array
            int[] listnum = new int[11];
            for (int k = 0; k < listnum.Length; k++)
            {
                listnum[k] = 0;
            }

            //game intro
            Console.WriteLine("Welcome to the dice throwing simulator!");
            Console.WriteLine(" ");
            Console.Write("How many dice rolls would you like to simulate? ");
            number = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine("DICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each '*' represents 1% of the total number of rolls.");
            Console.WriteLine("Total number of rolls = " + number + ".");
            Console.WriteLine(" ");

            //convert entered string to int
            int count = 0;
            Int32.TryParse(number, out count);

            for (int i = 0; i < count; i++)
            {
                //generate random numbers between 1 and 6 twice
                int total = 0;

                Random rndfirst = new Random();
                int first = rndfirst.Next(1, 7);

                Random rndsecond = new Random();
                int second = rndsecond.Next(1, 7);

                //add total to the count in the array
                total = second + first;
                total = total - 2;
                
                int current = listnum[total];
                listnum[total] = current + 1;
            }

            //find total to find % for histogram
            double percentTotal = 0;

            for (int t = 0; t < listnum.Length; t++)
            {
                percentTotal = listnum[t] + percentTotal;
            }


            for (int t = 0; t < listnum.Length; t++)
            {
                //find the percent each number was rolled

                string asterisk = "";
                double numAst = (listnum[t] / percentTotal) * 100;
                numAst = Math.Round(numAst);


                //create a line of *** for the percent
                for (int i = 0; i < numAst; i++)
                {
                    asterisk = asterisk + "*";
                }
                //print it out
                Console.WriteLine(t+2 + ": " + asterisk);
            }

            Console.WriteLine(" ");
            Console.WriteLine("Thank you for using the dice throwing simulator. Goodbye!");
        }
    }
}
