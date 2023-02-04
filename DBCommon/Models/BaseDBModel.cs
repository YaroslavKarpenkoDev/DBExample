using System.Windows.Input;
using Microsoft.Maui.Controls;
using SQLite;

namespace DBCommon.Models;

public class BaseDBModel
{
    public BaseDBModel()
    {
        
    }
    //primary key means that this field is unique and can be used to identify the row
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Ignore] 
    public ICommand DeleteCommand => new Command(Delete);
    
    public async virtual void Delete()
    {
    }
}