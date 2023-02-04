using DataBaseExampleApp.Models;

namespace DataBaseExampleApp;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
        Init();
    }

    public async void Init()
    {
        var result = await App.Db.GetList<TestData>();
        MainThread.BeginInvokeOnMainThread(() => { DataList.ItemsSource = result; });
        QueryEntry.Text = "SELECT * FROM TestData WHERE Name like ?";
    }

    private async void AddButton_OnClicked(object sender, EventArgs e)
    {
        var test = new Models.TestData
        {
            Name = ItemName.Text,
            Description = ItemDescription.Text
        };
        ItemName.Text = string.Empty;
        ItemDescription.Text = string.Empty;
        await App.Db.Add(test);
        Init();
    }

    private void UpdateButton_OnClicked(object sender, EventArgs e)
    {
        Init();
    }

    private async void Button_OnClicked(object sender, EventArgs e)
    {
        DataList.ItemsSource = await App.Db.TestQuery<TestData>(QueryEntry.Text);
    }
}