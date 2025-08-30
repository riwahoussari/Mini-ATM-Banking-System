using System;

public class CreateAccountCommand : ICommand
{
    public string Name => "Create Account";


    private readonly IAccountsManager _acccountsManager;
    public CreateAccountCommand(IAccountsManager acccountsManager)
    {
        _acccountsManager = acccountsManager;
    }

    public void Execute()
    {
        Console.WriteLine("\n---- Create Account ----");

        string username = InputValidator.GetValidUsername(_acccountsManager);
        int pin = InputValidator.GetPin();

        _acccountsManager.CreateAccount(username, pin);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n\tAccount Created Successfully");
        Console.ResetColor();
    }
}
