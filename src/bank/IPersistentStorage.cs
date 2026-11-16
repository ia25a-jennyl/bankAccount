using System;
using System.IO;

namespace bank;

public interface IPersistentStorage<T, TDataTransferObject>
{
    void SaveToJson(T item, string fileName);
    TDataTransferObject LoadFromJson(string jsonString);
}