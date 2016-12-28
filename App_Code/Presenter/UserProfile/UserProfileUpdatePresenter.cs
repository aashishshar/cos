using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Security;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for UserProfileEntryPresenter
/// </summary>
public class UserProfileUpdatePresenter
{
    private IUserProfileUpdateView _view;
    private ModelUserProfile _model;
    public UserProfileUpdatePresenter(IUserProfileUpdateView view)
	{
        _view = view;
        _model = new ModelUserProfile();
        SubscribeViewToEvents();
	}

    void SubscribeViewToEvents()
    {
        _view.Load += OnViewLoad;
        _view.UpdateCommand += _view_UpdateCommand;
        //_view.UpdateCommand += _view_UpdateCommand;
        //_view.TagRemoved += OnTagRemoved;
    }

    void OnViewLoad(object sender, EventArgs e)
    {
        if (!_view.IsPostBack)
        {
            //BindingControl.BindEnumDropDown<Constants.EducationTitle>((DropDownList)_view.ddlEducation);
           // BindingControl.BindEnumDropDown<Constants.ProfessionTitle>((DropDownList)_view.ddlProfession);
            //BindingControl.BindEnumDropDown<Constants.ProfessionStatus>((DropDownList)_view.ddlExp);
            LoadViewFromModel();
            _view.DataBind();
        }


        
    }

    private void LoadViewFromModel()
    {
        try
        {
            ModelUserProfile model = new ModelUserProfile();
            var user = model.GetUserProfileByID(_view.UserProfileID);
            _view.UserProfileID = user.UserProfileID;
            _view.FullName = user.FullName;
            _view.BankAcHolderName = user.BankAcHolderName;
            _view.BankAccountNo = user.BankAccountNo;
            _view.IFSCCode = user.IFSCCode;
            _view.ProfilePicture = user.ProfilePicture;
            _view.PhoneNo = user.PhoneNo;
            //_view.IsOtherInfo = user.IsOtherInfo;
            _view.State = user.State;
            _view.City = user.City;
            _view.FullAddress = user.FullAddress;
            _view.PinCode = user.PinCode;
            _view.BankBranchName = user.BankBranchName;
            _view.BankName = user.BankName;
            _view.DOB = user.DOB;
            _view.FullAddress = user.FullAddress;
            _view.FullNameOnAdd = user.FullNameOnAdd;
            _view.IsOfferReceiveWeekly = user.IsOfferReceiveWeekly;
            _view.IsOtherInfo = user.IsOtherInfo;
            _view.ProfilePicture = user.ProfilePicture;            
          
        }
        catch (Exception ex)
        {
            _view.message = ex.Message;
        }

    }

    void _view_UpdateCommand(object sender, EventArgs e)
    {
        try
        {
            UserProfile user = new UserProfile();
            user.UserProfileID = _view.UserProfileID;
            user.FullName = _view.FullName;
            user.BankAcHolderName = _view.BankAcHolderName;
            user.BankAccountNo = _view.BankAccountNo;
            user.IFSCCode = _view.IFSCCode.ToString();
            user.ProfilePicture = _view.ProfilePicture;
            user.PhoneNo = _view.PhoneNo;
            //user.IsOtherInfo = _view.IsOtherInfo;
            user.State = _view.State;
            user.City = _view.City;
            user.FullAddress = _view.FullAddress;
            user.PinCode = _view.PinCode;
            user.BankBranchName = _view.BankBranchName;
            user.BankName = _view.BankName;
            user.DOB = _view.DOB;
            user.FullAddress = _view.FullAddress;
            user.FullNameOnAdd = _view.FullNameOnAdd;
            user.IsOfferReceiveWeekly = _view.IsOfferReceiveWeekly;
            user.IsOtherInfo = _view.IsOtherInfo;
            user.ProfilePicture = _view.ProfilePicture;

            _model.DBOperation(Constants.Action.Update.ToString(), user);
            _view.message = "Successfully Updated!!!";
            LoadViewFromModel();
            _view.DataBind();
        }
        catch (Exception ex)
        {
            _view.message = ex.Message;
        }
        //ClearControls(); 
    }

}