namespace bank;

public interface ITransactionFee
{
    int CalculateDepositFee(int amount);
    int CalculateWithdrawFee(int amount);
}