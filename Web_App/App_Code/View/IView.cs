using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IView
/// </summary>
public interface IView
{
    event EventHandler Init;

    event EventHandler Load;

    bool IsPostBack { get; }

    void DataBind();

    bool IsValid { get; }
}