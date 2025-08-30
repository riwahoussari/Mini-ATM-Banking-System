using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class BankAccount
{
    public int Balance { get; private set; }
    public string Username { get; private set; }
    private int _pin;

    public BankAccount(string username, int pin)
	{
		Username = username;
        _pin = pin; 
        Balance = 0;
	}

    public bool Authenticate(int pin)
    {
        return pin == _pin;
    }

    public void Deposit(int amount)
    {
        if (amount <= 0)
        {
            throw new Exception("Cannot deposite a negative amount");
        }
        Balance += amount;
    }

    public void Withdraw(int amount)
    {
        if (amount <= 0)
        {
            throw new Exception("Cannot withdraw a negative amount");
        }
        else if (amount > Balance)
        {
            throw new Exception("Not enough balance");

        }

        Balance -= amount;
    }
}
