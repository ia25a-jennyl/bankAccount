using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace bank;

public record BankAccountDto(int Balance, List<Transaction> Transactions);

public class PersistentStorageBankAccount: IPersistentStorage<BankAccount, BankAccountDto>
{
    public void SaveToJson(BankAccount item, string fileName)
    {
        string outputJson = JsonSerializer.Serialize<BankAccountDto>(new BankAccountDto(item.Balance,  item.Transactions));
        File.WriteAllText(fileName, outputJson);
        
    }

    public BankAccountDto LoadFromJson(string jsonString)
    {
        return JsonSerializer.Deserialize<BankAccountDto>(jsonString);
    }
}