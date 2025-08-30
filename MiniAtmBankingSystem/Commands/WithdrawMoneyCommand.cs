using System;

public class WithdrawMoneyCommand : ICommand
{
    public string Name => "Withdraw Money";

    private readonly IAccountsManager _accountsManager;
    public WithdrawMoneyCommand(IAccountsManager accountsManager)
    {
        _accountsManager = accountsManager;
    }

    public void Execute()
    {
        Console.WriteLine("\n---- Withdraw Money ----");

        // withdraw amount
        int amount = InputValidator.GetAmount();

        // get account
        string username = InputValidator.GetUsername();
        int pin = InputValidator.GetPin();
        BankAccount account = InputValidator.GetAccount(_accountsManager, username, pin);

        if (account is BankAccount)
        {
            if (amount > account.Balance)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tNot enough balance.");
                Console.ResetColor();
            }
            else
            {
                account.Withdraw(amount);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tWithdrew: $" + amount + " Successfully.");
                Console.WriteLine("\n\tNew Balance: $" + account.Balance);
                Console.ResetColor();
            }
        }

    }
}
