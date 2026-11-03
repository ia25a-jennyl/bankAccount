namespace bank;

public class SmallTransactionFee : ITransactionFee
{
    private int DepositFee { get; init; } = 1;
    private int WithdrawFee { get; init; } = 1;


    public int CalculateDepositFee(int amount)
    {
        return amount * DepositFee / 100;
    }


    public int CalculateWithdrawFee(int amount)
    {
        return amount * WithdrawFee / 100;
    }

}