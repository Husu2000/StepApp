using AppUserPanel.Pages;
using AppUserPanel.Viewmodels;
using AppUserPanel.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AppUserPanel
{
    
    public partial class App : Application
    {

        public static SimpleInjector.Container Container { get; set; } = new SimpleInjector.Container();

        public App()
        {
            
        }

        
    }

}
