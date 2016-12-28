using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VW_Product
/// </summary>
public class VW_ProductPrensenter
{
    IVW_Product _view;
    ProductModel _model;
    public VW_ProductPrensenter(IVW_Product view)
	{
        _view = view;
        _model = new ProductModel();
        SubscribeViewToEvents();
	}
     private void SubscribeViewToEvents()
    {
        _view.Load += OnViewLoad;
        _view.DeleteCommand += _view_DeleteCommand;
        _view.PagingCommand += _view_PagingCommand;
        _view.RefreshCommand += _view_RefreshCommand;
    }
    void OnViewLoad(object sender, EventArgs e)
    {
        if (!_view.IsPostBack)
        {
            LoadViewFromModel();
            _view.DataBind();
        }
    }

    private void LoadViewFromModel()
    {
        //_view.ProductVW = _model.GetAllProducts();
    }
    void _view_RefreshCommand(object sender, EventArgs e)
    {
        _view.ProductVW = _model.GetAllProducts();
    }
    void _view_DeleteCommand(object sender, EventArgs e)
    {
        try
        {
            Product_Common c = new Product_Common();
            _model.DBOperation(Constants.Action.Delete, c, _view.Ids);
            //_view.strMessage = "Successfully Deleted!!!";
            _view_RefreshCommand(sender,e);

            _view.DataBind();
        }
        catch (Exception ex)
        {
           // _view.strMessage = ex.Message;
        }
    }
    void _view_PagingCommand(object sender, EventArgs e)
    {
        try
        {
            int totalRecord;
            _view.ProductVW = _model.GetAll_Proc_Product(_view.pageIndex, _view.pageSize, out totalRecord);
            _view.totalRecord = totalRecord;
            _view.DataBind();
        }
        catch (Exception ex)
        {
            // _view.strMessage = ex.Message;
        }
    }
    
}