using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Password_Generator
{
    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            bool exit = false;
            while(!exit)
            {
                displayMenu();
                string input = ReadLine();

                WriteLine("");

                int passwordLength;
                // Validate input.
                if (input == "exit") return;
                else if (!int.TryParse(input, out passwordLength))
                    displayMessage(ref input, "Invalid input. Press 'Enter' and try again.");
                else if (passwordLength < 6 || passwordLength > 20)
                    displayMessage(ref input, "Invalid input. Press 'Enter' and try again.");
                else
                {
                    generatePasswords(passwordLength);
                    WriteLine("");
                    displayMessage(ref input, "Press 'enter' to restart.");
                }

                if (input == "exit")
                    exit = true;
            }

        }

        private static void displayMenu()
        {
            WriteLine("This application produces a set of 5 randomly generated passwords.");
            WriteLine("To close the application, type 'exit' at any time.");
            WriteLine("------------------------------------------------------------------");
            WriteLine("Enter desired length of the password");
            WriteLine("Length must be greater than 6 and less than 20:");
        }
        // Displays a message based on the scenario and checks if user is exiting the program.
        private static void displayMessage(ref string input, string message)
        {
            WriteLine(message);
            input = ReadLine();
            Clear();
        }

        private static void generatePasswords(int passwordLength)
        {
            char[] password = new char[passwordLength];
            string chars = "!@#$%^&*()abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < passwordLength; j++)
                {
                    password[j] = chars[random.Next(chars.Length)];
                }
                WriteLine(password);
            }
        }
    }
}
