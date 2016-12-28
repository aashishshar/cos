using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI.WebControls;
using System.Reflection;
using System.ComponentModel;
using System.Web.UI;


/// <summary>
/// Summary description for BindingControl
/// </summary>
public class EnumControl
{

    public EnumControl()
	{

		//
		// TODO: Add constructor logic here
		//
	}

    


    /// <summary>
    /// Dynamic Enum Bind in control
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ddl"></param>
    public static void BindEnumDropDown<T>(DropDownList ddl)
    {        
        string[] enumNames = Enum.GetNames(typeof(T));
        foreach (string item in enumNames)
        {
            //get the enum item value
            int value = (int)Enum.Parse(typeof(T), item);
            ListItem listItem = new ListItem(item, value.ToString());
            ddl.Items.Add(listItem);
        }        
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("[ Select ]", "0"));
    }

    public static void GetEnumDescriptions<T>(Control ctrl)
    {
        var list = new List<KeyValuePair<Enum, string>>();
        foreach (Enum value in Enum.GetValues(typeof(T)))
        {
            string description = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(description);
            var attribute = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).First();
            if (attribute != null)
            {
                description = (attribute as DescriptionAttribute).Description;
            }
            list.Add(new KeyValuePair<Enum, string>(value, description));
        }
        if (ctrl is DropDownList)
        {
            DropDownList control = (DropDownList)ctrl;
            control.DataSource = list;
            control.DataTextField = "Value";
            control.DataValueField = "Key";
            control.DataBind();
            control.Items.Insert(0, new ListItem("[ Select ]", "0"));
        }
        else if (ctrl is RadioButtonList)
        {

            RadioButtonList control = (RadioButtonList)ctrl;
            control.DataSource = list;
            control.DataTextField = "Value";
            control.DataValueField = "Key";
            control.DataBind();            
        }
        else if (ctrl is Repeater)
        {
            Repeater control = (Repeater)ctrl;
            control.DataSource = list;        
            control.DataBind();   
        }
        else if (ctrl is DataList)
        {
            DataList control = (DataList)ctrl;
            control.DataSource = list;
            control.DataBind();
        }
        else if (ctrl is CheckBoxList)
        {
            CheckBoxList control = (CheckBoxList)ctrl;
            control.DataSource = list;
            control.DataTextField = "Value";
            control.DataValueField = "Key";
            control.DataBind();
        }
        else if (ctrl is BulletedList)
        {
            BulletedList control = (BulletedList)ctrl;
            control.DataSource = list;
            control.DataTextField = "Value";
            control.DataValueField = "Key";
            control.DataBind();
        }
    }

    
}