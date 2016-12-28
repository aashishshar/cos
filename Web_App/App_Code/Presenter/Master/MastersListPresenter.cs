using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



/// <summary>
/// Summary description for SubCategoryPresenter
/// </summary>
public class MastersListPresenter
{
    private object _view;
    private ModelCategory _modelCat;
    private ModelSubCategory _modelSubCat;

    private ISubCategoryView _masterListEntry;
    private ICategoryView _categoryView;
    private Constants.Master _enumMaster;
    public MastersListPresenter(object view, Constants.Master masterAction)
    {
        _view = view;
        _enumMaster = masterAction;
        
        InitilizeAttribute(_enumMaster);
        SubscribeViewToEvents();
    }

    void SubscribeViewToEvents()
    {
        switch (_enumMaster)
        {
            case Constants.Master.Category:
                _categoryView.Load += OnViewLoad;
                _categoryView.InsertCommand += _view_InsertCommand;
                _categoryView.DeleteCommand += _view_DeleteCommand;
                //_categoryView.refreshCategories += new EventHandler(refreshCategories);
                break;
            case Constants.Master.SubCategory:
                _masterListEntry.Load += OnViewLoad;
                _masterListEntry.InsertCommand += _view_InsertCommand;
                _masterListEntry.DeleteCommand += _view_DeleteCommand;
                //_masterListview.refreshDDL += new EventHandler(_view_refreshDDL);
                break;
            default:
                break;
        }
    }

    void OnViewLoad(object sender, EventArgs e)
    {

        switch (_enumMaster)
        {
            case Constants.Master.Category:
                if (!_categoryView.IsPostBack)
                {
                    BindCategory(_categoryView);
                }
                break;
            case Constants.Master.SubCategory:
                if (!_masterListEntry.IsPostBack)
                {
                    BindSubCategory(_masterListEntry);
                }
                break;
            default:
                break;
        }

    }

    private void BindCategory(ICategoryView catListView)
    {
        List<Category> categories = _modelCat.GetAllCategories();        
        catListView.Categories = categories;
    }

    private void BindSubCategory(ISubCategoryView subCatEntryView)
    {
        List<Sub_Category> subCategories = _modelSubCat.GetAllSubCategories();
        subCatEntryView.SubCategories = subCategories;
    }

    private void InitilizeAttribute(Constants.Master enumMaster)
    {
        try
        {
            switch (enumMaster)
            {
                case Constants.Master.Category:
                    _categoryView = (ICategoryView)_view;
                    _modelCat = new ModelCategory();
                    break;
                case Constants.Master.SubCategory:
                    _masterListEntry = (ISubCategoryView)_view;
                    _modelSubCat = new ModelSubCategory();
                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    void _view_InsertCommand(object sender, EventArgs e)
    {
        
            switch (_enumMaster)
            {
                case Constants.Master.Category:
                    try
                    {
                        Category cat = new Category();
                        cat.CategoryName_V = _categoryView.CategoryName_V;
                        cat.Status_N = Constants.Status.Active;
                        cat.CreatedBy = "";
                        cat.ParentCategoryID_N = _categoryView.ParentCategoryID_N;


                        _modelCat.DBOperation(Constants.Action.Insert.ToString(), cat);
                        _categoryView.strMessage = "Successfully Inserted!!!";
                        _categoryView.CategoryName_V = string.Empty;
                        BindCategory(_categoryView);
                    }
                    catch (Exception ex)
                    {
                        _categoryView.strMessage = ex.InnerException.Message;
                    }
                    break;
                case Constants.Master.SubCategory:
                    try
                    {
                        Sub_Category cat = new Sub_Category();
                        cat.SubCategoryName_V = _masterListEntry.SubCategoryName_V;
                        cat.CategoryID_N = _masterListEntry.CategoryID_N;
                        cat.Status_N = Constants.Status.Active;
                        cat.CreatedBy = "";

                       _modelSubCat.DBOperation(Constants.Action.Insert.ToString(), cat);
                        _masterListEntry.strMessage = "Successfully Inserted!!!";
                        _masterListEntry.SubCategoryName_V = string.Empty;
                        BindSubCategory(_masterListEntry);
                    }
                    catch (Exception ex)
                    {
                        _masterListEntry.strMessage = ex.InnerException.Message;
                    }
                    break;
                default:
                    break;
            }
            //DocumentType c = new DocumentType();

            //c.DocumentTitle = _view.DocumentTitle;
            //c.CategoryID_N = _view.CategoryID;
            //c.Category = _view.CategorySelected;
            //c.DocType = (Constants.DocTypes)_view.DocumentType;
            //c.UserGUID = _view.UserGUID;
            //c.Status_N = Constants.CurrentStatus.Active;
            //c.CreatedBy = "";
            //_model.DBOperation("Insert", c);
            //_view.message = "Successfully Inserted!!!";
            //PopulateGrid();
            //_view.DataBind();
        
        //ClearControls(); 
    }
    void _view_DeleteCommand(object sender, EventArgs e)
    {
        try
        {
            switch (_enumMaster)
            {
                case Constants.Master.Category:
                    try
                    {
                        _modelCat.DBOperation(Constants.Action.Delete.ToString(),null, _categoryView.CategoryID_N);
                        _categoryView.strMessage = "Successfully Deleted!!!";                     
                        BindCategory(_categoryView);
                    }
                    catch (Exception ex)
                    {
                        _categoryView.strMessage = ex.InnerException.Message;
                    }
                    break;
                case Constants.Master.SubCategory:
                    try
                    {
                        _modelSubCat.DBOperation(Constants.Action.Delete.ToString(), null, _masterListEntry.SubCategoryID_N);
                        _masterListEntry.strMessage = "Successfully Deleted!!!";
                        BindSubCategory(_masterListEntry);
                    }
                    catch (Exception ex)
                    {
                        _masterListEntry.strMessage = ex.InnerException.Message;
                    }
                    break;

            }
        }
        catch (Exception ex)
        {
            //_view.message = ex.Message;
        }
    }

}
    