using IdeaPickerPro.Models;

namespace IdeaPickerPro;

public partial class App : Application
{

    public static Repository IdeaList;
    public App()
    {
        InitializeComponent();

        IdeaList = new Repository();
        
        MainPage = new AppShell();
    }
}