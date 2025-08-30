using MiniAtmBankingSystem;
using System;

public class ExitCommand : ICommand
{
    public string Name => "Exit";

    public void Execute()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Exiting... Goodbye!");
        Console.ResetColor();

        Environment.Exit(0);
    }

}