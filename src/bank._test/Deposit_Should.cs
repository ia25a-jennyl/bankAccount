using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace bank._test;

[TestClass]
public sealed class Deposit_Should
{
    
    
    [TestMethod]
    public void Deposit_SmallFee(int amount, int res)
    {

        ServiceCollection services = new ServiceCollection();
        
        services.AddLogging(loggerBuilder =>
        {
            loggerBuilder.ClearProviders();
            loggerBuilder.AddConsole();
        });
        
        services.AddSingleton<BankAccountFactory>();
        var serviceProvider = services.BuildServiceProvider();
        var factory = serviceProvider.GetRequiredService<BankAccountFactory>();
        var bankAccount = factory.createBankAccount(new SmallTransactionFee());
        
        bankAccount.Deposit(amount);
        
        Assert.AreEqual(bankAccount.Balance, res);
    }
}