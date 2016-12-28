using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for SubCategoryPresenter
/// </summary>
public class SubCategoryListPresenter
{
    private IMasterSubCategoryListView _view;
    private ModelSubCategory _model;
    public SubCategoryListPresenter(IMasterSubCategoryListView view)
	{
        _view = view;
        _model = new ModelSubCategory();
        SubscribeViewToEvents();
	}

    void SubscribeViewToEvents()
    {
        _view.Load += OnViewLoad;        
    }

    void OnViewLoad(object sender, EventArgs e)
    {
        if (!_view.IsPostBack)
        {
            List<KeyValuePair<int,string>> subCategories = BindingControl.BindSubCategory(_view.CategoryID);
            _view.populateSubCategories(subCategories);
        }
    }
}