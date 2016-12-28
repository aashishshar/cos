using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IProductEntryView
/// </summary>
public interface ITransactionFeedEntryView : ITransactionFeedListView
{
    string ClickTime { get; set; }
    string TransactionTime { get; set; }
    string OmgTransactionID { get; set; }
    string OmgMerchantRef { get; set; }
    string UID { get; set; }
    string UID2 { get; set; }
    string MID { get; set; }
    string MerchantName { get; set; }
    string PID { get; set; }
    string Product { get; set; }
    string Referrer { get; set; }
    string SR { get; set; }
    string VR { get; set; }
    string NVR { get; set; }
    string Status { get; set; }
    string Paid { get; set; }
    string Completed { get; set; }
    string UKey { get; set; }
    string TransactionValue { get; set; }
    string VoucherCode { get; set; }
    string FromDate { get; set; }
    string ToDate { get; set; }
    string AmountStatus { get; set; }

    List<Transaction_Feed> Transaction_FeedInsert { get; set; }
    string strMessage { set; }
    List<Int64> Ids { get; set; }

    event EventHandler InsertCommand;
    event EventHandler DeleteCommand;
    event EventHandler UpdateCommand;
    event EventHandler SearchCommand;
}


public interface ITransactionFeedListView : IView
 {
    List<Transaction_Feed> Transaction_Feeds { get; set; }
 }

 