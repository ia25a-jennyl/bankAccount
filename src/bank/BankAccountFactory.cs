using Microsoft.Extensions.Logging;

namespace bank;

public class BankAccountFactory
{
    private ILogger<BankAccount> _logger;

    public BankAccountFactory(ILogger<BankAccount> logger)
    {
        _logger = logger;
    }

    public BankAccount CreateBankAccount(ITransactionFee transactionFee, int balance = 0)
    {
        return new BankAccount(transactionFee, _logger, balance);
    }
}