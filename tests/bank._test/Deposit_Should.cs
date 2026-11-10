using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace bank._test;

[TestClass]
public sealed class DepositShould
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
        
        
        services.AddSingleton<TransactionFeeFactory>();
        services.AddSingleton<BankAccount>();
        var serviceProvider = services.BuildServiceProvider();
        var bankAccount = serviceProvider.GetRequiredService<BankAccount>();

        bankAccount.Deposit(amount, TransactionFeeType.Small);

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

        services.AddSingleton<TransactionFeeFactory>();
        services.AddSingleton<BankAccount>();
        var serviceProvider = services.BuildServiceProvider();
        var bankAccount = serviceProvider.GetRequiredService<BankAccount>();

        bankAccount.Deposit(amount, TransactionFeeType.Medium);

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

        services.AddSingleton<TransactionFeeFactory>();
        services.AddSingleton<BankAccount>();
        var serviceProvider = services.BuildServiceProvider();
        var bankAccount = serviceProvider.GetRequiredService<BankAccount>();

        bankAccount.Deposit(amount, TransactionFeeType.Large);

        Assert.AreEqual(bankAccount.Balance, res);
    }
    
    
    
    
    [TestMethod]
    [DataRow(1000)]
    [DataRow(5000)]
    [DataRow(100)]
    [DataRow(1)]
    [DataRow(2000)]
    public void Deposit_NoFee(int amount)
    {
        ServiceCollection services = new ServiceCollection();

        services.AddLogging(loggerBuilder =>
        {
            loggerBuilder.ClearProviders();
            loggerBuilder.AddConsole();
        });

        services.AddSingleton<TransactionFeeFactory>();
        services.AddSingleton<BankAccount>();
        var serviceProvider = services.BuildServiceProvider();
        var bankAccount = serviceProvider.GetRequiredService<BankAccount>();

        bankAccount.Deposit(amount, TransactionFeeType.Zero);

        Assert.AreEqual(bankAccount.Balance, amount);
    }
}