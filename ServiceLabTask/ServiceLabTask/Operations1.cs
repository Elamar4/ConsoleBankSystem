using ServiceLabTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLabTask
{
    internal class Operations1
    {
        Bank1 bank1 = new Bank1();

        public void ShowingOperations()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please choose an operation:");
            Console.WriteLine(new string('=', 40));
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. User Registration");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("2. Login");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("3. Find User");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("4. Exit");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('=', 40));
            Console.ResetColor();
        }
        public void UserRegistration()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string('=', 90));
            Console.Write("Plese enter your Name--->");
            string name = Console.ReadLine();
            Console.WriteLine(new string('-', 40));
            Console.Write("Plese enter your Surname--->");
            string surname = Console.ReadLine();
            Console.WriteLine(new string('-', 40));
            Console.Write("Plese enter your Balance--->");
            double balance;
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out balance))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid number for Balance.");
                    Console.ResetColor();
                    Console.Write("Please enter your Balance--->");
                }
            }
            Console.WriteLine(new string('-', 40));
            Console.Write("Plese enter your Email--->");
            string email = Console.ReadLine();
            if (bank1.users.Any())
            {
                while (bank1.users.Any(u => u.Email == email))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This email has been using,Try with another email:");
                    Console.WriteLine(new string('=', 40));
                    Console.ResetColor();
                    email = Console.ReadLine();
                    Console.WriteLine();
                }
            }
            Console.WriteLine(new string('-', 40));
            Console.Write("Plese enter your Password--->");
            string password = ReadPassword();
            Console.WriteLine(new string('-', 40));
            Console.Write("Are you Admin(yes/no)--->");
            string adminInput = Console.ReadLine().ToLower();
            bool isAdmin = adminInput == "yes";

            Console.ResetColor();
            bank1.users.Add(new User(name, surname, balance, email, password, isAdmin));


        }
        public void UserLogin()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string('=', 90));
            Console.Write("Please enter your Email: ");
            string loginEmail = Console.ReadLine();
            Console.WriteLine(new string('-', 40));
            Console.Write("Please enter your Password: ");
            string loginPassword = ReadPassword();
            Console.WriteLine(new string('=', 90));
            Console.ResetColor();
            var foundUser = bank1.users.FirstOrDefault(u => u.Email == loginEmail);
            if (foundUser != null && foundUser.Password == loginPassword && !foundUser.IsBlocked)
            {
                foundUser.IsLogged = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login successful! Welcome, " + foundUser.Name);
                Console.ResetColor();
                /////////////////////////////////
                bool test = true;
                while (test)
                {
                    Console.WriteLine();
                    Console.WriteLine("1. Check Balance");
                    Console.WriteLine("2. Top up balance");
                    Console.WriteLine("3. Change Password");
                    Console.WriteLine("4. Bank user list");
                    Console.WriteLine("5. Block User");
                    Console.WriteLine("0. Log out");
                    Console.WriteLine();
                    Console.Write("Select an option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{foundUser.Name} your balance is {foundUser.Balance}");
                            Console.WriteLine(new string('-', 40));
                            Console.ResetColor();
                            break;
                        case "2":
                            int amount;
                            Console.Write("Please indicate how much the amount will be increased: ");
                          
                            while (!int.TryParse(Console.ReadLine(), out amount) || amount < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Please enter a positive number and enter just digits of number");
                                Console.ResetColor();
                                Console.Write("Please indicate how much the amount will be increased: ");
                            }

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine();
                            foundUser.Balance += amount;
                            Console.WriteLine($"Balance has been successfully increased. Your Balance is: {foundUser.Balance}");
                            Console.ResetColor();
                            Console.WriteLine();
                            break;

                        case "3":
                            Console.Write("Please indicate new password:");
                            string newpass = ReadPassword();
                            foundUser.Password = newpass;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Password changed.");
                            Console.ResetColor();
                            break;
                        case "4":
                            if (foundUser.IsAdmin)
                            {
                                Console.WriteLine(new string('=', 40));
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine();
                                Console.WriteLine("List of Bank users:");
                                for (int i = 0; i < bank1.users.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}.{bank1.users[i].Name} {bank1.users[i].Surname}");
                                }
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Just Admins can choose this operation");
                                Console.WriteLine(new string('-', 40));
                                Console.ResetColor();
                            }
                            Console.WriteLine(new string('=', 40));
                            break;
                        case "5":
                            if (foundUser.IsAdmin)
                            {
                                Console.WriteLine("Which Email will bloked?");
                                string blokedEmail = Console.ReadLine();
                                var user = bank1.users.FirstOrDefault(u => u.Email == blokedEmail);

                                if (user is not null)
                                {
                                    user.IsBlocked = true;
                                    Console.WriteLine("User blocked.");
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("There is no user with this email");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Just Admins can choose this operation");
                                Console.WriteLine(new string('-', 40));
                                Console.ResetColor();
                            }
                            break;
                        case "0":
                            Console.WriteLine("Logging out...");
                            test = false;
                            break;
                        default:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid option. Please try again.");
                            Console.ResetColor();
                            break;
                    }
                    Console.WriteLine();
                }
            }
            else if (foundUser.IsBlocked)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This Email was bloked by Admin");
                Console.WriteLine(new string('=', 40));
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You must register first,do you wanna it(yes/no)");
                string test = Console.ReadLine();
                if (test == "yes")
                    UserRegistration();
                Console.WriteLine();

            }
        }
        public void FindUser()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string('=', 90));
            Console.Write("Please enter the Email of the user to find: ");
            string searchEmail = Console.ReadLine();
            Console.WriteLine(new string('=', 90));
            Console.ResetColor();

            var foundUser = bank1.users.FirstOrDefault(u => u.Email == searchEmail);
            if (foundUser != null)
            {
                Console.WriteLine($"User name is-->{foundUser.Name}");
                Console.WriteLine($"User surname is-->{foundUser.Surname}");
                Console.WriteLine($"User Balance is-->{foundUser.Balance}");
                Console.WriteLine($"User email is-->{foundUser.Email}");
                Console.WriteLine($"This user is Bloked-->{foundUser.IsBlocked}");
                Console.WriteLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"There is no user with the email '{searchEmail}'.");
                Console.WriteLine(new string('=', 90));
                Console.ResetColor();
                Console.WriteLine();
            }
        }
        public string ReadPassword()
        {
            StringBuilder password = new StringBuilder();
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password.Length--;
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password.Append(key.KeyChar);
                    Console.Write("*");
                }
            }
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password.ToString();
        }
    }
}
