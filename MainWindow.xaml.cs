using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
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

namespace CSharpAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void FirebaseConnectionBtn_Click(object sender, RoutedEventArgs e)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "###",
                BasePath = "https://json.firebasedatabase.app/"
            };

            IFirebaseClient client = new FirebaseClient(config);

            FirebaseResponse response = await client.GetAsync("FirstName");
            string fullname = response.ResultAs<string>();
            MessageBox.Show(fullname);

            SetDataToFirebase(client);
        }

        //เรียกใช้จาก IFirebaseClient client
        private async void SetDataToFirebase(IFirebaseClient client)
        {
            var customer = new Customer
            {
                FirstName = "Kaka",
                LastName = "Yaya",
                Age = 18
            };
            SetResponse response = await client.SetAsync("customer/set", customer); //กำหนด path
            Customer customer1 = response.ResultAs<Customer>();
            MessageBox.Show(customer1.FirstName);
        }
    }
}
