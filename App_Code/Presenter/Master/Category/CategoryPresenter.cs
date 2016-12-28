using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CategoryPresenter
/// </summary>
public class CategoryPresenter
{
    private ICategoryListView _view;
    private ModelCategory _model; 
	public CategoryPresenter(ICategoryListView view)
	{
        _view = view;
        _model = new ModelCategory();
        SubscribeViewToEvents();
	}
    private void SubscribeViewToEvents()
    {
        _view.Load += OnViewLoad;
    }
    void OnViewLoad(object sender, EventArgs e)
    {
        if (!_view.IsPostBack)
        {
            List<KeyValuePair<int, string>> lst = _model.GetCategoriesList();
            _view.populateCategories(lst);
            _view.SelectionChangedCategory += new EventHandler(_view_SelectionChanged);
            _view.postback = true;
        }
    }
    void _view_SelectionChanged(object sender, EventArgs e)
    {
        LoadCurrentCategoryOnView();
    }

    private void LoadCurrentCategoryOnView()
    {
        ModelCategory m = new ModelCategory();
        _view.ShowCategory = m.GetCategory(Convert.ToInt32(_view.SelectedValueDDL));
    }

    public virtual void OnViewInitialized()
    {
        _view.refreshCategories += new EventHandler(_view_refreshDDL);
    }

    void _view_refreshDDL(object sender, EventArgs e)
    {
        List<KeyValuePair<int, string>> lst = _model.GetCategoriesList();
        _view.populateCategories(lst);
    } 
}