using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServiceLabTask.Models
{
    internal class User
    {
        private static int id = 0;
        public User(string name, string surname, double balance, string email, string password, bool isAdmin)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Balance = balance;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
            IsBlocked = false;
            IsLogged = false;
            id++;
        }
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                bool test = true;
                do
                {
                    if (value.Length < 3 || value.Any(char.IsDigit) || !value.Any(char.IsLetter))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The length of Name must be at least 3 and do not contans any number.");
                        Console.WriteLine(new string('=', 40));
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Pls type value of Name again:");
                        Console.ResetColor();
                        value = Console.ReadLine();
                    }
                    else
                    {
                        test = false;
                        _name = value;
                    }
                } while (test);
            }
        }

        private string _surname;
        public string Surname
        {
            get => _surname;
            set
            {
                bool test = true;
                do
                {
                    if (value.Length < 3 || value.Any(char.IsDigit) || !value.Any(char.IsLetter))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The length of Surname must be at least 3 and do not contans any number.");
                        Console.WriteLine(new string('=', 40));
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Pls type value of Name again:");
                        Console.ResetColor();
                        value = Console.ReadLine();
                    }
                    else
                    {
                        test = false;
                        _surname = value;
                    }
                } while (test);
            }
        }
        public double Balance { get; set; }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                bool test = true;
                do
                {
                    if (value.Length < 5 || !value.Contains('@'))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The length of Email must be at least 5 and must contans '@' character.");
                        Console.WriteLine(new string('=', 40));
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Pls type value of Email  again:");
                        Console.ResetColor();
                        value = Console.ReadLine();
                    }
                    else
                    {
                        test = false;
                        _email = value;
                        Console.WriteLine(new string('=', 40));
                    }
                } while (test);
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                while (true)
                {
                    if (value.Length < 8 || !value.Any(char.IsLower) || !value.Any(char.IsUpper))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (value.Length < 8)
                        {
                            Console.WriteLine("Error: Password must be at least 8 characters long.");
                        }
                        if (!value.Any(char.IsLower))
                        {
                            Console.WriteLine("Error: Password must contain at least one lowercase letter.");
                        }
                        if (!value.Any(char.IsUpper))
                        {
                            Console.WriteLine("Error: Password must contain at least one uppercase letter.");
                        }
                        Console.ResetColor();
                        Console.WriteLine(new string('=', 40));
                        Console.WriteLine("Please enter a valid password:");
                        Operations1 op = new Operations1();
                        value = op.ReadPassword();
                    }
                    else
                    {

                        password = value;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Password set successfully and registered.");
                        Console.WriteLine(new string('=', 40));
                        Console.WriteLine();
                        Console.ResetColor();
                        break;
                    }
                }
            }
        }

        public bool IsAdmin { get; set; }
        public bool IsBlocked { get; set; } = false;
        public bool IsLogged { get; set; } = false;
    }
}
