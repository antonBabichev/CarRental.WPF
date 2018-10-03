using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CarRental.WPF.Views;

namespace CarRental.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var parentFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(parentFolder, "*.dll"));
            catalog.Catalogs.Add(new DirectoryCatalog(parentFolder, "*.exe"));
            var container = new CompositionContainer(catalog);

            try
            {
                var mainWindow = new MainWindow();
                container.ComposeParts(mainWindow);
                mainWindow.Show();
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }
    }
}
