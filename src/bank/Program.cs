using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace bank;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddLogging(loggerBuilder =>
            {
                loggerBuilder.ClearProviders();
                loggerBuilder.AddConsole();
            }
        );
        builder.Services.AddScoped<BankAccountFactory>();
        var host = builder.Build();

        Console.WriteLine("What Transaction Fee do you want to use?");
        Console.WriteLine("1. Small");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Large");

        int choice = Convert.ToInt32(Console.ReadLine());

        BankAccountFactory factory = host.Services.GetRequiredService<BankAccountFactory>();
        BankAccount bankAccount = null;

        switch (choice)
        {
            case 1:
                bankAccount = factory.CreateBankAccount(new SmallTransactionFee());
                break;
            case 2:
                bankAccount = factory.CreateBankAccount(new MediumTransactionFee());
                break;
            case 3:
                bankAccount = factory.CreateBankAccount(new LargeTransactionFee());
                break;
            default:
                Console.Error.WriteLine("Invalid choice");
                System.Environment.Exit(1);
                break;
        }

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
                    bankAccount.Deposit(amountDeposit);
                    Console.WriteLine("The new balance is: " + bankAccount.Balance);
                    break;
                case 2:
                    Console.WriteLine("How much Money do you want to deposit?");
                    int amountWithdraw = Convert.ToInt32(Console.ReadLine());
                    bankAccount.Withdraw(amountWithdraw);
                    Console.WriteLine("The new balance is: " + bankAccount.Balance);
                    break;
                default:
                    Console.WriteLine("Bye Bye!");
                    return;
            }
        }
    }
}