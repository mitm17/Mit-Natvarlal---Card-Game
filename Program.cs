using System;

namespace mitproject// Note: actual namespace depends on the project name.
{
   class Program
    {
        static void Main(string[] args) //where the execution 
        {                               //of the program begins
            Testing.RunTest(); //from the Testing class the RunTest method is called
            Console.WriteLine("enter to exit");
            Console.ReadLine(); //exits the program after waiting for the user to press enter
        }
    }
}