using DBCommon.Models;

namespace DataBaseExampleApp.Models;

public class TestData : BaseDBModel
{
    public string Name { get; set; }
    
    public string Description { get; set; }

    public override async void Delete()
    {
       await App.Db.Delete<TestData>(this.Id);
    }
}