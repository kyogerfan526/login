using login.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public DataSet1 userDataSet = new DataSet1();
        public UsersTableAdapter dataAdapter = new UsersTableAdapter();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

            var query = from user in userDataSet.Users
                        where (user.Name == txtName.Text)
                        where (user.Password == txtPassword.Text)
                        select user;

            // check if there is a match, query will have entry
            if (query.Count() > 0)
            {
                // create instance of the MainWindow (new)
                MainWindow window = new MainWindow();
                // show window
                window.Show();
                // Close() this window
                Close();
            }
            else
            {
                // show message box that states the user does not exist
                // on the message box show an error icon and “Submit” caption
                // look at resources section below for message box information

                Window1 error = new Window1();

                error.Show();

                // clear text boxes
                txtName.Text = "";
                txtPassword.Text = "";
            }


        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            DataSet1.UsersRow row = userDataSet.Users.NewUsersRow();
            // set row Name to name textbox Text
            row.Name = txtName.Text;
            // set row Password to password textbox Text
            row.Password = txtPassword.Text;
            DateTime currentDateTime = DateTime.Now;

            row.ID =int.Parse(currentDateTime.Day + currentDateTime.Hour + currentDateTime.Minute + currentDateTime.Second +"");

            userDataSet.Users.AddUsersRow(row);
            dataAdapter.Update(userDataSet);

            // show message box that states the user was registered
            // on the message box show an information icon and “Register” caption
            // look at resources section below for message box information

            Window2 window = new Window2();
            
            window.Show();


            // clear text boxes
            txtName.Text = "";
            txtPassword.Text = "";

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
