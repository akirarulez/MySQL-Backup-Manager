﻿using FirstFloor.ModernUI.Windows.Controls;
using MySQLBackupLibrary;
using MySQLBackupManager.Pages.Content;
using MySQLBackupManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace MySQLBackupManager.Pages
{
    /// <summary>
    /// Interaction logic for AddDatabasePage.xaml
    /// </summary>
    public partial class AddDatabasePage : Page
    {
        public AddDatabasePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DatabasesViewModel databasesViewModel = Globals.DatabasesViewModel;

            DatabaseInfo dbInfo = new DatabaseInfo();
            dbInfo.Host = hostTextBox.Text;
            dbInfo.DatabaseName = databaseTextBox.Text;
            dbInfo.User = userTextBox.Text;
            dbInfo.Password = passwordTextBox.Password;

            string[] startTimeSplit = startTime.Text.Split(':');
            dbInfo.StartTimeHour = Convert.ToInt32(startTimeSplit[0]);
            dbInfo.StartTimeMinute = Convert.ToInt32(startTimeSplit[1]);

            databasesViewModel.addDatabase(dbInfo);

            ResetTextBoxfields();

            ModernDialog.ShowMessage(string.Format("The database '{0}' has been added!", dbInfo.DatabaseName), "Success", MessageBoxButton.OK);
            dbInfo = null;
            NavigationCommands.GoToPage.Execute(new Uri("/Pages/DatabasesPage.xaml", UriKind.Relative), FirstFloor.ModernUI.Windows.Navigation.NavigationHelper.FindFrame(null, this));
        }

        private void ResetTextBoxfields()
        {
            hostTextBox.Text = "";
            databaseTextBox.Text = "";
            userTextBox.Text = "";
            passwordTextBox.Password = "";
        }
    }
}
