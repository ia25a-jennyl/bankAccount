using System;
using Microsoft.Extensions.Logging;


namespace bank;

public class BankAccount
{
    private ILogger<BankAccount> _logger;
    private TransactionFeeFactory _transactionFeeFactory;
    public int Balance { get; private set; } 

    public BankAccount(ILogger<BankAccount> logger, TransactionFeeFactory transactionFeeFactory)
    {
        this._transactionFeeFactory = transactionFeeFactory;
        _logger = logger;
        this.Balance = 0;
    }

    public void Deposit(int amount, TransactionFeeType type)
    {
        if (amount <= 0) return;
        
        int fee = _transactionFeeFactory.Create(type).CalculateDepositFee(amount);
        
        _logger.LogInformation("{deposit} got deposited", amount - fee);
        Balance += amount - fee;
    }

    public void Withdraw(int amount, TransactionFeeType type)
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