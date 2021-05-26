using System;
using System.Threading;

namespace Admin
{
    public class Program
    {
        public static void Main()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\tAdmin Menu -> Wecome");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1) New Test");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2) Test add question");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("3) Test delete question");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("4) Delete Test");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Select: ");
            string select = Console.ReadLine();

            if (select == "1" )
            {
                AdminControl.NewTest();
            }
            else if (select == "2")
            {
                AdminControl.TestAddQuesion();
            }
            else if (select == "3")
            {
                AdminControl.TestDeleteQuesion();
            }
            else if (select == "4")
            {
                AdminControl.DeleteTest();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Program ends");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }
}