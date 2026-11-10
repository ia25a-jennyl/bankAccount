using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace bank._test;


[TestClass]
public sealed class Withdraw_Should
{
    [TestMethod]
    [DataRow(1000, 500, 495)]
    [DataRow(1, 1, 0)]
    public void Withdraw_SmallFee(int init, int amount, int res)
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
        
        bankAccount.Deposit(init, TransactionFeeType.Zero);
        bankAccount.Withdraw(amount, TransactionFeeType.Small);
        
        Assert.AreEqual(res, bankAccount.Balance);
    }
    
    [TestMethod]
    [DataRow(1000, 500, 475)]
    [DataRow(1, 1, 0)]
    public void Withdraw_MediumFee(int init, int amount, int res)
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
        
        bankAccount.Deposit(init, TransactionFeeType.Zero);
        bankAccount.Withdraw(amount, TransactionFeeType.Medium);
        
        Assert.AreEqual(res, bankAccount.Balance);
    }
    
    [TestMethod]
    [DataRow(1000, 500, 450)]
    [DataRow(1, 1, 0)]
    public void Withdraw_LargeFee(int init, int amount, int res)
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
        
        bankAccount.Deposit(init, TransactionFeeType.Zero);
        bankAccount.Withdraw(amount, TransactionFeeType.Large);
        
        Assert.AreEqual(res, bankAccount.Balance);
    }
    
    [TestMethod]
    [DataRow(1000, 500, 500)]
    [DataRow(1, 1, 0)]
    public void Withdraw_ZeroFee(int init, int amount, int res)
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
        
        bankAccount.Deposit(init, TransactionFeeType.Zero);
        bankAccount.Withdraw(amount, TransactionFeeType.Zero);
        
        Assert.AreEqual(res, bankAccount.Balance);
    }
    
    
}