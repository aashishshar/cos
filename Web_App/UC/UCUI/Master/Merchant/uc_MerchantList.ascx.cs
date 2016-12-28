using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UC_UCUI_Master_Merchant_uc_MerchantList : System.Web.UI.UserControl, IMerchantListView
{

    private MerchantListPrensenter _presenter;


    public UC_UCUI_Master_Merchant_uc_MerchantList()
    {
        this._presenter = new MerchantListPrensenter(this);
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMerchant();
        }
    }


    private void BindMerchant()
    {
        ddlMerchatList.DataSource = Merchants;
        ddlMerchatList.DataTextField = "MerchantNameDetail";
        ddlMerchatList.DataValueField = "MID";
        ddlMerchatList.DataBind();

        

        ddlMerchatList.Items.Insert(0, "SELECT MERCHANT");

    }

    public Int64 GetMIDByAMID(int AMID,string MerchantNameDescription)//Here OfferID for Payoom and his merchant name
    {
        MerchantModel _model = new MerchantModel();
        Merchant p = _model.GetMerchantMID(AMID,MerchantNameDescription);
        if (p.MID != 0)
            return Convert.ToInt64(p.MID);//ddlMercharList.Items.FindByText(searchText).Value);
        else
            return 0;
    }

    public Int64 GetValueFindByText(string Text)
    {
        MerchantModel _model = new MerchantModel();
        Merchant p = _model.FindMerchant(Text);

        ////var p = ddlMercharList.Items.FindByText
        ////    (from m in ddlMercharList.Items.AsQueryable()
        ////         where m.MerchantNameDetail.Equals(searchText)
        ////         select m.MID).SingleOrDefault();
        //string p = ddlMercharList.Items.FindByText(searchText).Value.ToString();
        if (p.MID != 0)
            return Convert.ToInt64(p.MID);//ddlMercharList.Items.FindByText(searchText).Value);
        else
            return 0;
        //MerchantModel obj = new MerchantModel();

        //var mid = (from m in obj.GetAllMerchants()
        //          where m.MerchantNameDetail == Text
        //          select m.MID).SingleOrDefault();

        //return 0;

    }

    //public int GetMIDByOMGID(string omgMID)
    //{
    //    MerchantModel _model = new MerchantModel();
    //    Merchant p = _model.GetAllMerchants().Where(w => w.OMGMID == Convert.ToInt32(omgMID)).FirstOrDefault();

    //    ////var p = ddlMercharList.Items.FindByText
    //    ////    (from m in ddlMercharList.Items.AsQueryable()
    //    ////         where m.MerchantNameDetail.Equals(searchText)
    //    ////         select m.MID).SingleOrDefault();
    //    //string p = ddlMercharList.Items.FindByText(searchText).Value.ToString();
    //    if (p.MID != 0)
    //        return Convert.ToInt32(p.MID);//ddlMercharList.Items.FindByText(searchText).Value);
    //    else
    //        return 0;
    //    //MerchantModel obj = new MerchantModel();

    //    //var mid = (from m in obj.GetAllMerchants()
    //    //          where m.MerchantNameDetail == Text
    //    //          select m.MID).SingleOrDefault();

    //    //return 0;

    //}



    public string LiveMID(string Text)
    {
        MerchantModel _model = new MerchantModel();
        Merchant p = _model.FindMerchant(Text);

        ////var p = ddlMercharList.Items.FindByText
        ////    (from m in ddlMercharList.Items.AsQueryable()
        ////         where m.MerchantNameDetail.Equals(searchText)
        ////         select m.MID).SingleOrDefault();
        //string p = ddlMercharList.Items.FindByText(searchText).Value.ToString();
        if (p.OMGMID != 0)
        {
            return p.OMGMID.ToString();//ddlMercharList.Items.FindByText(searchText).Value);
        }
        else
        {
            return "";
        }
    }

    public string SelectedMerchant
    {
        get
        {
            return ddlMerchatList.SelectedValue.ToString();
        }
        set
        {
            ddlMerchatList.SelectedValue = value;
        }
    }

    public string SelectedMerchantText
    {
        get
        {
            return ddlMerchatList.SelectedItem.Text;
        }
        set
        {
            ddlMerchatList.SelectedItem.Text = value;
        }
    }



    public List<Merchant> Merchants { get; set; }


    public bool IsValid
    {
        get { throw new NotImplementedException(); }
    }

    public string MID { get; set; }

    public string MerchantName { get; set; }


    public event EventHandler ViewCommand;
}