using ServiceLabTask.Models;
using System.Text;

namespace ServiceLabTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Our Bank system\n");

            Operations1 operations1 = new Operations1();
            bool testing = true;
            do
            {
                operations1.ShowingOperations();

                bool test = int.TryParse(Console.ReadLine(), out int operationNum);
                if (test)
                {
                    switch (operationNum)
                    {
                        case 1:
                            operations1.UserRegistration();
                            break;
                        case 2:
                            operations1.UserLogin();
                            break;
                        case 3:
                            operations1.FindUser();
                            break;
                        case 4:
                            testing = false;
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid number.");
                    Console.WriteLine();
                    Console.ResetColor();

                }

            } while (testing);
        }
    }
}
