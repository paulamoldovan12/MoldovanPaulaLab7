using System;
using MoldovanPaulaLab7.Data;
using System.IO;

namespace MoldovanPaulaLab7
{
    public partial class App : Application
    {
        static CoffeeListDatabase database;

        public static CoffeeListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new CoffeeListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CoffeeList.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
