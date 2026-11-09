using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace bank;

public static class Program
{
    static TransactionFeeType GetTransactionFeeType()
    {
        Console.WriteLine("What kind of transaction fee do you want to use?");
        Console.WriteLine("1. Small");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Large");
        int enumType = Convert.ToInt32(Console.ReadLine());
        if (!Enum.IsDefined(typeof(TransactionFeeType), enumType)) throw  new Exception($"Invalid value for fee type: {enumType}");
        return (TransactionFeeType) enumType;
    }

    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddLogging(loggerBuilder =>
            {
                loggerBuilder.ClearProviders();
                loggerBuilder.AddConsole();
            }
        );
        builder.Services.AddScoped<BankAccount>();
        builder.Services.AddScoped<TransactionFeeFactory>();
        var host = builder.Build();

        Console.WriteLine("What Transaction Fee do you want to use?");
        Console.WriteLine("1. Small");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Large");

        int choice = Convert.ToInt32(Console.ReadLine());

        BankAccount bankAccount = host.Services.GetRequiredService<BankAccount>();

        while (true)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Deposit Money");
            Console.WriteLine("2. Withdraw Money");
            Console.WriteLine("3. Exit");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("How much Money do you want to deposit?");
                    int amountDeposit = Convert.ToInt32(Console.ReadLine());
                    
                    bankAccount.Deposit(amountDeposit, GetTransactionFeeType());
                    
                    Console.WriteLine("The new balance is: " + bankAccount.Balance);
                    break;
                case 2:
                    Console.WriteLine("How much Money do you want to deposit?");
                    int amountWithdraw = Convert.ToInt32(Console.ReadLine());
                    
                    bankAccount.Withdraw(amountWithdraw, GetTransactionFeeType());
                    
                    Console.WriteLine("The new balance is: " + bankAccount.Balance);
                    break;
                default:
                    Console.WriteLine("Bye Bye!");
                    return;
            }
        }
    }
}