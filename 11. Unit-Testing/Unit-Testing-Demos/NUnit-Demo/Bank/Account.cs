using System;

public class Account
{
    public Account()
    {
        this.Balance = 0;
    }

    public float Balance { get; private set; }

    public void Deposit(float amount)
    {
        if (amount == 0)
        {
            throw new ArgumentException("Can not deposit ammount of 0.00");
        }

        this.Balance += amount;
    }

    public void Withdraw(float amount)
    {
        if (amount == 0)
        {
            throw new ArgumentException("Can not withdrwa ammount of 0.00");
        }

        this.Balance -= amount;
    }

    public void TransferFunds(Account destinationAcc, float amount)
    {
        if (destinationAcc == this)
        {
            throw new ArgumentException("Source and destination accounts can not be the same");
        }

        this.Balance -= amount;
        destinationAcc.Balance += amount;
    }
}