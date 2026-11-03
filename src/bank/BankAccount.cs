using Microsoft.Extensions.Logging;


namespace bank;

public class BankAccount
{
    private readonly ITransactionFee _transactionFee;
    private ILogger<BankAccount> _logger;
    
    public int Balance { get; private set; }

    public BankAccount(ITransactionFee transactionFee, ILogger<BankAccount> logger)
    {
        _transactionFee = transactionFee;
        _logger = logger;
    }

    public void Deposit(int amount)
    {
        if (amount <= 0) return;
        int fee = _transactionFee.CalculateDepositFee(amount); 
        _logger.LogInformation("{deposit} got deposited", amount - fee);
        Balance += amount - fee;
    }

    public void Withdraw(int amount)
    {
        int fee = _transactionFee.CalculateWithdrawFee(amount);

        if (fee + amount > Balance)
        {
            _logger.LogError("Not enough balance to withdraw that amount");
            return;
        }
        
        Balance -= amount + fee;
        
        _logger.LogInformation("{withdraw} got withdrawn", amount);
        
    }
    


}