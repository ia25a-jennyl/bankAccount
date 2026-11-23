namespace bank;

public class ZeroTransacionFee : ITransactionFee
{
    public int CalculateDepositFee(int amount)
    {
        return 0;
    }

    public int CalculateWithdrawFee(int amount)
    {
        return 0;
    }
}