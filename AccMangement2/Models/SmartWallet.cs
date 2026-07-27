using System;
using System.Collections.Generic;
using System.Text;

namespace AccMangement2.Models;

class SmartWallet(string id, string username, string password, string address, string phoneNumber, string accountType, string signature, decimal balance, bool status)
{
    public string id = id;
    public string username = username;
    public string password = password;
    public string address = address;
    public string phoneNumber = phoneNumber;
    public string accountType = accountType;
    public string signature = signature;
    public decimal balance = balance;
    public bool status = status;

    //1.Get the Balance
    public static void GetBalance(List<SmartWallet> smartWallets)
    {
        Console.WriteLine("Enter you ID :");
        string id = Console.ReadLine();
        Console.WriteLine("Enter Your Password :");
        string password = Console.ReadLine();
        bool found = false;
        foreach (SmartWallet smartWallet in smartWallets)
        {
            if (smartWallet.id == id && smartWallet.password == password)
            {
                Console.WriteLine($"Your balance is : {smartWallet.balance}");
                found = true;
            }

        }
        if (!found)
        {
            Console.WriteLine("invalid Id Or password");
        }


    }

    //2.Withdraw
    public bool Withdraw(decimal amount)
    {
        decimal totalAmount = amount + (amount * 0.01m);
        if (totalAmount <= balance)
        {
            balance -= amount;
            return true;
        }
        return false;
    }

    //3.Transfer
    public bool Transfer(decimal amount, SmartWallet des)
    {
        if (amount <= balance)
        {
            balance -= amount;
            des.balance += amount;
            return true;
        }
        return false;
    }

    //4.Deposit
    public bool Deposit(decimal amount, string password)
    {
        if (password == this.password)
        {
            this.balance += amount;
            return true;
        }
        return false;

    }

    //5.Forget password
    public bool ForgetPassword(string id, string newpassword)
    {
        if (id == this.id)
        {
            this.password = newpassword;
            return true;
        }
        return false;
    }

    //6.Change password
    public bool ChangePassword(string oldPassword, string newPassword)
    {
        if (oldPassword == this.password)
        {
            this.password = newPassword;
            return true;
        }
        return false;
    }
}
