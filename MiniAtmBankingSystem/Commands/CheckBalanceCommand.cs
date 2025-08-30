using System;

public class CheckBalanceCommand : ICommand
{
    public string Name => "Check Balance";

	private readonly IAccountsManager _accountsManager;
	public CheckBalanceCommand(IAccountsManager accountsManager)
	{
		_accountsManager = accountsManager;
	}


    public void Execute()
    {
        Console.WriteLine("\n---- Check Balace ----");

        // get account
        string username = InputValidator.GetUsername();
        int pin = InputValidator.GetPin();
        BankAccount account = InputValidator.GetAccount(_accountsManager, username, pin);
		
        if (account is BankAccount)
		{
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tBalance: $" + account.Balance);
            Console.ResetColor();
        }
    }

    
}
