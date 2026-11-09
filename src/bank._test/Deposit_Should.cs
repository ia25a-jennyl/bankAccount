using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace bank._test;

[TestClass]
public sealed class Deposit_Should
{
    
    [TestMethod]
    [DataRow(1000, 990)]
    [DataRow(5000, 4950)]
    [DataRow(100, 99)]
    [DataRow(1, 1)]
    [DataRow(2000, 1980)]
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
        var bankAccount = factory.CreateBankAccount(new SmallTransactionFee());

        bankAccount.Deposit(amount);

        Assert.AreEqual(bankAccount.Balance, res);
    }
    
    [TestMethod]
    [DataRow(1000, 950)]
    [DataRow(5000, 4750)]
    [DataRow(100, 95)]
    [DataRow(1, 1)]
    [DataRow(2000, 1900)]
    public void Deposit_MediumFee(int amount, int res)
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
        var bankAccount = factory.CreateBankAccount(new MediumTransactionFee());

        bankAccount.Deposit(amount);

        Assert.AreEqual(bankAccount.Balance, res);
    }
    [TestMethod]
    [DataRow(1000, 900)]
    [DataRow(5000, 4500)]
    [DataRow(100, 90)]
    [DataRow(1, 1)]
    [DataRow(2000, 1800)]
    public void Deposit_LargeFee(int amount, int res)
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
        var bankAccount = factory.CreateBankAccount(new LargeTransactionFee());

        bankAccount.Deposit(amount);

        Assert.AreEqual(bankAccount.Balance, res);
    }
}