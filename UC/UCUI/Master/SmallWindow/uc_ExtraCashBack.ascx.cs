﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Master_SmallWindow_uc_ExtraCashBack : System.Web.UI.UserControl,IMerchant_CommisionListView
{

    private Merchant_CommisionListPrensenter _presenter;

    public UC_UCUI_Master_SmallWindow_uc_ExtraCashBack()
    {
        this._presenter = new Merchant_CommisionListPrensenter(this);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {            
            BindItems();
        }
       
    }

    private void BindItems()
    {
        rptItem.DataSource = Merchant_Commisions.Where(x=>x.Status==Constants.Status.Active);
        rptItem.DataBind();
    }

    public List<Merchant_Commision> Merchant_Commisions { get; set; }





    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }

    public string MerchantName { get; set; }
}