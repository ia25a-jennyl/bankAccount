using System;
using Microsoft.Extensions.Logging;


namespace bank;

public class BankAccount
{
    private ILogger<BankAccount> _logger;
    private ITransactionFeeFactory _transactionFeeFactory;
    public int Balance { get; private set; } 

    public BankAccount(ILogger<BankAccount> logger, ITransactionFeeFactory transactionFeeFactory, int balance)
    {
        this._transactionFeeFactory = transactionFeeFactory;
        _logger = logger;
        this.Balance = balance;
    }

    public void Deposit(int amount, Enum type)
    {
        if (amount <= 0) return;
        
        int fee = _transactionFeeFactory.Create(type).CalculateDepositFee(amount);
        
        _logger.LogInformation("{deposit} got deposited", amount - fee);
        Balance += amount - fee;
    }

    public void Withdraw(int amount, Enum type)
    {
        int fee = _transactionFeeFactory.Create(type).CalculateWithdrawFee(amount);

        if (fee + amount > Balance)
        {
            _logger.LogError("Not enough balance to withdraw that amount");
            return;
        }
        
        Balance -= amount + fee;
        
        _logger.LogInformation("{withdraw} got withdrawn", amount);
        
    }
    


}