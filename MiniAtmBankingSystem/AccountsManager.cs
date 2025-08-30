using System;

public interface IAccountsManager
{
    bool AvailableUsername(string username);
    void CreateAccount(string username, int pin);
    BankAccount GetAccount(string username, int pin);
}

public class AccountsManager : IAccountsManager
{
	private List<BankAccount> _accounts = new List<BankAccount>();
	
	public bool AvailableUsername(string username)
	{
		foreach (BankAccount account in _accounts)
		{
			if (account.Username == username)
			{
				return false;
			}
		}

		return true;
	}

	public void CreateAccount(string username, int pin)
	{
		BankAccount newAccount = new BankAccount(username, pin);
		_accounts.Add(newAccount);
	}

	public BankAccount GetAccount(string username, int pin)
	{
        foreach (BankAccount account in _accounts)
        {
            if (account.Username == username)
            {
				bool autheticated = account.Authenticate(pin);

				if (autheticated)
				{
					return account;
				}
				else
				{
					return null;
				}
            }
        }

        return null;
    }

}
