using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityData;

/// <summary>
/// Summary description for clsProcCallingService
/// </summary>
public class clsProcCallingService
{
	public clsProcCallingService()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void Proc_OmgTransactionFinalCommision()
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            model.adv_proc_CalculateFinalCommission();
        }
    }

    public static void Proc_UpdateDeleteDupilcateOffers()
    {
        using (Ad_ConnectionString model = new Ad_ConnectionString())
        {
            model.adv_UpdateAndDeleteDuplicateOffers();
        }
    }
}