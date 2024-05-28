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
using System.Windows.Shapes;
using ContactsApp.Classes;
using SQLite;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        private Contact contact;
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;
            txtName.Text = contact.Name;
            txtEmail.Text = contact.Email;
            txtPhone.Text = contact.Phone;
            Title = $"{contact.Name}'s Contact";

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void UpdateButton_OnClick(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                contact.Name = txtName.Text;
                contact.Email = txtEmail.Text;
                contact.Phone = txtPhone.Text;
                connection.Update(contact);
            }
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }
            Close();
        }


    }
}
