using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//

public interface IModelCategory
{
    List<KeyValuePair<int, string>> GetCategoriesList();
    Category GetCategory(int Id);
    void DBOperation(string command, Category cat = null, int id = 0);	
}