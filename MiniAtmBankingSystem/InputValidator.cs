using System;

public static class InputValidator
{
    public static string GetUsername()
    {
        while (true)
        {
            Console.ResetColor();

            Console.Write("\n\tEnter Username: ");
            string input = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            if (input is null || input == "")
            {
                Console.WriteLine("\tUsername cannot be empty");
                continue;
            }

            if (input.Split(" ").Length > 1)
            {
                Console.WriteLine("\tUsername cannot contain spaces");
                continue;
            }

            return input;
        }
    }

    public static string GetValidUsername(IAccountsManager accountsManager)
    {
        while (true)
        {
            Console.ResetColor();

            Console.Write("\n\tEnter Username: ");
            string input = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            if (input is null || input == "")
            {
                Console.WriteLine("\tUsername cannot be empty");
                continue;
            }

            if (input.Split(" ").Length > 1)
            {
                Console.WriteLine("\tUsername cannot contain spaces");
                continue;
            }

            if (!accountsManager.AvailableUsername(input))
            {
                Console.WriteLine("\tUsername already taken.");
                continue;
            }

            return input;
        }
    }

    public static int GetPin()
    {
        while (true)
        {
            Console.ResetColor();

            Console.Write("\n\tEnter 4-digit PIN: ");
            string input = Console.ReadLine();
            int pin;

            Console.ForegroundColor = ConsoleColor.Red;
            if (input is null || input == "")
            {
                Console.WriteLine("\tPIN cannot be empty");
                continue;
            }

            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("\tPIN must be numerical");
                continue;
            }
            else
            {
                pin = number;
            }

            if (input.Length != 4)
            {
                Console.WriteLine("\tPIN should have exactly 4 digits");
                continue;
            }

            return pin;
        }
    }

    public static BankAccount GetAccount(IAccountsManager accountsManager, string username, int pin)
    {
        BankAccount account = accountsManager.GetAccount(username, pin);

        if (account is null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tInvalid Credentials.");
            Console.ResetColor();
            return null;
        }

        return account;
    }

    public static int GetAmount()
    {
        while (true)
        {
            Console.ResetColor();

            Console.Write("\n\tEnter Amount ($): ");
            string input = Console.ReadLine();
            int amount;

            Console.ForegroundColor = ConsoleColor.Red;
            if (input is null || input == "")
            {
                Console.WriteLine("\tAmount cannot be empty");
                continue;
            }

            if (!int.TryParse(input, out int number) || number <= 0)
            {
                Console.WriteLine("\tAmount must be a strictly positive number");
                continue;
            }
            else
            {
                amount = number;
            }

            return amount;
        }
    }
}