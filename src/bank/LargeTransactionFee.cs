namespace bank;

public class LargeTransactionFee : ITransactionFee
{
    private int DepositFee { get; init; } = 10;
    private int WithdrawFee { get; init; } = 10;


    public int CalculateDepositFee(int amount)
    {
        return amount * DepositFee / 100;
    }
    
    public int CalculateWithdrawFee(int amount)
    {
        return amount * WithdrawFee / 100;
    }
    
}