namespace bank;

public enum TransactionDirection
{
   Deposit, Withdraw 
}

public record Transaction(int BalanceChange, TransactionDirection Direction, TransactionFeeType FeeType);