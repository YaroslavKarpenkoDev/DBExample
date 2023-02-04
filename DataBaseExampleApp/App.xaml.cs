using DataBaseExample;
using DataBaseExample.DB.Interfases;
using DataBaseExample.DB.Repositoryes;
using DataBaseExampleApp.Models;

namespace DataBaseExampleApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
        Init();
    }
    
    public static IBaseRepository Db { get; set; }

    public async void Init()
    {
        Config.DBName = "DataBaseExample.db3";
        Config.DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Config.DBName);
        Db = new BaseDataRepository();
        await Db.InitTableAsync<TestData>();
    }
}