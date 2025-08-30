using System;

public class DepositMoneyCommand : ICommand
{
    public string Name => "Deposit Money";

    private readonly IAccountsManager _accountsManager;
    public DepositMoneyCommand(IAccountsManager accountsManager)
    {
        _accountsManager = accountsManager;
    }

    public void Execute()
    {
        Console.WriteLine("\n---- Deposit Money ----");

        // deposit amount
        int amount = InputValidator.GetAmount();

        // get account
        string username = InputValidator.GetUsername();
        int pin = InputValidator.GetPin();
        BankAccount account = InputValidator.GetAccount(_accountsManager, username, pin);

        if (account is BankAccount)
        {
            account.Deposit(amount);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tDeposited: $" + amount + " Successfully.");
            Console.WriteLine("\n\tNew Balance: $" + account.Balance);
            Console.ResetColor();
        }

    }


}
