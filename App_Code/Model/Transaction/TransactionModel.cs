using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductModel
/// </summary>
public class TransactionModel : ITransactionModel
{
    clsCommonMethods client;
    public TransactionModel()
	{
        client = new clsCommonMethods();
	}
    
    public List<Transaction_Feed> GetAllTransactions()
    {
        List<Transaction_Feed> items = client.GetAllTransactionFeeds().ToList();
        return items;
    }

    public Transaction_Feed GetTransaction(long merchantID)
    {
        //Transaction_Feed item = client.GetAllMerchants().Where(p => p.MID == merchantID).FirstOrDefault();
        //return item;
        return null;
    }

    public void DBOperation(Constants.Action command, Transaction_Feed item = null, List<long> IDs = null)
    {
        switch (command)
        {
            case Constants.Action.Insert:
                client.InsertTransactionFeed(item);
                break;
            case Constants.Action.Delete:
                client.DeleteTransactionFeed(IDs);
                break;
            case Constants.Action.Update:
                client.UpdateTransactionFeed(IDs);
                break;
            default:
                break;
        }
    }


    public List<Transaction_Feed> GetSearchTransactions(string fromdate, string todate, string amountStatus)
    {
        List<Transaction_Feed> items = client.GetSarchTransactionFeed(fromdate, todate, amountStatus).ToList();
        return items;
    }
}