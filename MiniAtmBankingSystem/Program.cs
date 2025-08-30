using System;
using System.Net.WebSockets;
using System.Security.Principal;

namespace MiniAtmBankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            IAccountsManager manager = new AccountsManager();

            Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>
            {
                { "1", new CreateAccountCommand(manager) },
                { "2", new DepositMoneyCommand(manager) },
                { "3", new WithdrawMoneyCommand(manager) },
                { "4", new CheckBalanceCommand(manager) },
                { "5", new ExitCommand() }
            };

            PrintTitle();
            while (true)
            {
                PrintMenu(commands);
                ICommand cmd = GetCommand(commands);
                cmd.Execute();
            }

        }

        static void PrintTitle()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-----------------------------");
            Console.WriteLine("-------- ATM MACHINE --------");
            Console.WriteLine("-----------------------------");
            Console.ResetColor();
        }

        static void PrintMenu(Dictionary<string, ICommand> commands)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("\n--------- Main Menu ---------\n");

            foreach (var command in commands)
            {
                Console.WriteLine($"\t{command.Key} - {command.Value.Name}");
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        static ICommand GetCommand(Dictionary<string, ICommand> commands)
        {

            while (true)
            {
                Console.Write("Enter the number of your desired option: ");
                string input = Console.ReadLine();

                if (commands.ContainsKey(input))
                {
                    return commands[input];
                } else
                {
                    Console.WriteLine("Invalid Option");
                }

            }
        }
      
    }
}