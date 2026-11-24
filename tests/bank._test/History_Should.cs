using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace bank._test;

[TestClass]
public sealed class HistoryShould
{
    [TestMethod]
    [DataRow(new int[]{100, 100, 100, 100, 100})]
    [DataRow(new int[]{100, 100, 100, 200, 100})]
    [DataRow(new int[]{})]
    public void TransactionHistoryDeposit(int[] deposits)
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


        List<Transaction> shouldTransactions = [];


        foreach (var amount in deposits)
        {
            bankAccount.Deposit(amount, TransactionFeeType.Zero);
            shouldTransactions.Add(new Transaction(amount, TransactionDirection.Deposit, TransactionFeeType.Zero));
        }

        CollectionAssert.AreEqual(shouldTransactions, bankAccount.Transactions);
    }
}