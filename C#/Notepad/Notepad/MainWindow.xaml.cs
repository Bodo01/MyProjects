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
using System.Windows.Forms;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public TabItems tabItems { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            tabItems = new TabItems();

        }

        public void RefreshLists()
        {

            this.DataContext = null;
            this.DataContext = tabItems;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            tabItems.AddNewItem("", "");
            RefreshLists();
        }


        private void MenuItem_Click2(object sender, RoutedEventArgs e)
        {

            tabItems.RemoveItem();
            RefreshLists();

        }

        private void MenuItem_Click3(object sender, RoutedEventArgs e)
        {

            tabItems.SaveItem();


        }

        private void MenuItem_Click4(object sender, RoutedEventArgs e)
        {

            tabItems.Save();


        }

        private void MenuItem_Click5(object sender, RoutedEventArgs e)
        {

            tabItems.OpenFile();
            RefreshLists();

        }

        private void Find_Button(object sender, RoutedEventArgs e)
        {
            if (FindTextBox.Text != "")
                tabItems.FindText(FindTextBox.Text);



        }

        private void AboutButton(object sender, RoutedEventArgs e)
        {
            Window1 aboutWindow= new Window1();
            aboutWindow.Show();
        }

    
    }
}
