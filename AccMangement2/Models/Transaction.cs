using AccMangement2.Enums;

namespace AccMangement2.Models;

class Transaction(string id, DateTime date, string sourceName, string destinationName, decimal amount, TransactionType type, TransactionStatus status)
{
    string id = id;
    DateTime date = date;
    string sourceName = sourceName;
    string destinationName = destinationName;
    decimal amount = amount;
    TransactionType Type = type;
    TransactionStatus status = status;
}
