using System;
using System.Collections.Generic;

public class Bank
{
    private readonly List<Account> accounts;

    public Bank()
    {
        this.accounts = new List<Account>();
    }

    public int AccountsCount
    {
        get
        {
            return this.accounts.Count;
        }
    }

    public Account this[int index]
    {
        get
        {
            if ((index < 0) || (index >= this.accounts.Count))
            {
                throw new ArgumentException("Invalid account index.");
            }

            var account = this.accounts[index];
            return account;
        }
    }

    public void AddAccount(Account acc)
    {
        if (acc == null)
        {
            throw new ArgumentException("NULL accounts are not allowed!");
        }

        this.accounts.Add(acc);
    }

    public void RemoveAccount(Account acc)
    {
        var index = this.accounts.IndexOf(acc);
        if (index == -1)
        {
            throw new ArgumentException("Account not found. Can not be removed.");
        }

        this.accounts.RemoveAt(index);
    }
}