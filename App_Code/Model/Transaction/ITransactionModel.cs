using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IProductModel
/// </summary>

/// <summary>
/// Summary description for IUserGroup
/// </summary>
public interface ITransactionModel
{
    List<Transaction_Feed> GetAllTransactions();
    List<Transaction_Feed> GetSearchTransactions(string fromdate,string todate,string amountStatus);
    Transaction_Feed GetTransaction(Int64 merchantID);

    void DBOperation(Constants.Action command, Transaction_Feed item = null, List<Int64> IDs = null);
}



