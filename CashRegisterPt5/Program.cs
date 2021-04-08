using System;

namespace CashRegisterPt5
{
    class Program
    {
        static void Main(string[] args)
        {
            (double payment, double purchase) = Accept();
            double change = Math.Round(payment - purchase, 2);
            Console.Write($"Your change is : ${change}\n");
            Breakdown(change);
        }
        static void Breakdown(double change)
        {
            change = Condense(change, 20, "twenties");
            change = Condense(change, 10, "tens");
            change = Condense(change, 5, "fives");
            change = Condense(change, 1, "ones");
            change = Condense(change, 0.25, "quarters");
            change = Condense(change, 0.10, "dimes");
            change = Condense(change, 0.05, "nickels");
            change = Condense(change, 0.01, "pennies");
        }
        static double Condense(double change, double deNom, string curRency)
        {
            int leftOver = (int)(change / deNom);
            if (leftOver >= 1)
            {
                Console.WriteLine("You will receive: " + leftOver + " " + curRency + " in change.");
            }
            return Math.Round(change % deNom, 2);
        }
        static (double, double) Accept()
        {
            double purchase = Convert("Purchase price: $");
            double payment = Convert("Payment price: $");
            while (payment < purchase)
            {
                Console.Write("I am sorry, that is not enough cash money son.\n");
                purchase = Convert("Purchase price: $");
                payment = Convert("Payment price: $");
            }
            return (payment, purchase);
        }
        static double Convert(string prompt)// STEP 4
        {
            double amount = 0;
            bool succeeded = false;
            while (succeeded == false)
            {
                try
                {
                    if (amount <= 0)
                    {
                        Console.Write(prompt);
                        amount = double.Parse(Console.ReadLine());
                    }
                    else
                    {
                        succeeded = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You cannot enter letters");
                }
            }
            return amount;
        }
    }
}
