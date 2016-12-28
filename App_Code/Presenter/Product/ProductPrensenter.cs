using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProductPrensenter
/// </summary>
public class ProductPrensenter
{

    IProductEntryView _view;
    ProductModel _model;
    public ProductPrensenter(IProductEntryView view)
	{
        _view = view;
        _model = new ProductModel();
        SubscribeViewToEvents();
	}

    private void SubscribeViewToEvents()
    {
        _view.Load += OnViewLoad;
        _view.InsertCommand += _view_InsertCommand;
        _view.DeleteCommand += _view_DeleteCommand;
    }
    void OnViewLoad(object sender, EventArgs e)
    {
        if (!_view.IsPostBack)
        {
            //LoadViewFromModel();
            //_view.DataBind();
        }
    }

    private void LoadViewFromModel()
    {

    }
    void _view_InsertCommand(object sender, EventArgs e)
    {
        try
        {
            if (_view.ProductVW!=null)
            {
                foreach (Product_Common cmn in _view.ProductVW)
                {
                    _model.DBOperation(Constants.Action.Insert, cmn);
                }
            }
            else
            {
                Product_Common c = new Product_Common();

                c.Title = _view.Title;
                if (_view.CategoryID_N > 0)
                    c.CategoryID_N = _view.CategoryID_N;
                c.SerialNo = _view.SerialNo;
                c.ProductCategoryName = _view.ProductCategoryName;
                c.NavigationURL = _view.NavigationURL;
                c.ModifiedDate = DateTime.Now;
                c.ImageUrl = _view.ImageUrl;
                c.Description = _view.Description;
                c.CreatedDate = DateTime.Now;
                c.Ad_Type = _view.Ad_Type;
                //c.Ad_For = _view.Ad_For;
                c.MID = _view.MID;
                //c.CreatedBy = Membership.GetUser().ProviderUserKey.ToString();
                c.Availability = _view.Availability;
                _model.DBOperation(Constants.Action.Insert, c);
            }
            _view.strMessage = "Successfully Inserted!!!";            
            LoadViewFromModel();
            _view.DataBind();
        }
        catch (Exception ex)
        {
            _view.strMessage = ex.InnerException.Message;
        }
    }

    void _view_DeleteCommand(object sender, EventArgs e)
    {
        try
        {
            //UserGroup c = new UserGroup();

            //c.GroupName = _view.GroupName;

            //c.UserID = (Guid)Membership.GetUser().ProviderUserKey;

            //c.Status_N = Constants.CurrentStatus.Active;
            //c.CreatedBy = Membership.GetUser().ProviderUserKey.ToString();
            //_model.DBOperation(Constants.Action.Insert, c);
            //_view.message = "Successfully Inserted!!!";
            //_view.GroupName = string.Empty;
            //LoadViewFromModel();
            //_view.DataBind();
        }
        catch (Exception ex)
        {
            _view.strMessage = ex.Message;
        }
    }
}