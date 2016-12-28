using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Master_SmallWindow_uc_CommisionProgramDDL : System.Web.UI.UserControl//,IMerchant_CommisionListView
{
    // private Merchant_CommisionListPrensenter _presenter;

    // public UC_UCUI_Master_SmallWindow_uc_CommisionProgramDDL()
    //{
    //    this._presenter = new Merchant_CommisionListPrensenter(this);
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{            
        //    BindItems();
        //}
       
    }

    public void CommisionByMerchantName(string MerchantName)
    {        
             MerchantModel _model=new MerchantModel();
            
            //this.MerchantName = MerchantName;
            //this._presenter = new Merchant_CommisionListPrensenter(this);
            //BindItems();
        ddlCommisionList.DataSource = _model.GetCommisionByMerchant(MerchantName);
        ddlCommisionList.DataBind();

        ddlCommisionList.Items.Insert(0, "[ Select ]");        
    }

    public string GetProgramID()
    {
        if (ddlCommisionList.SelectedIndex > 0)
        {
            return ddlCommisionList.SelectedValue.ToString();
        }
        else
            return "";
    }

    private void BindItems()
    {
        //ddlCommisionList.DataSource = Merchant_Commisions;
        //ddlCommisionList.DataBind();

        //ddlCommisionList.Items.Insert(0, "[ Select ]");
    }

    //public List<Merchant_Commision> Merchant_Commisions { get; set; }





    //public bool IsValid
    //{
    //    get { throw new NotImplementedException(); }
    //}

    //public string MerchantName { get; set; }
}