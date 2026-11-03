namespace bank;

public class MediumTransactionFee : ITransactionFee
{
    private int DepositFee { get; init; } = 5;
    private int WithdrawFee { get; init; } = 5;


    public int CalculateDepositFee(int amount)
    {
        return amount * DepositFee / 100;
    }


    public int CalculateWithdrawFee(int amount)
    {
        return amount * WithdrawFee / 100;
    }

}