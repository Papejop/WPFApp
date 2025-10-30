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
using WpfApp.Data;
using WpfApp.Models;

namespace WpfApp
{
    public partial class DocumentItemsWindow : Window
    {
        public DocumentItemsWindow(int documentID)
        {
            InitializeComponent();
            LoadDocumentItemsFromDatabase(documentID);
        }

        private void DocumentItemDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LoadDocumentItemsFromDatabase(int documnetID)
        {

            using var db = new DataBaseContext();

            var documentItem = db.DocumentItems.Where(item => item.DocumentId == documnetID).ToList();

            DocumentItemDataGrid.ItemsSource = documentItem;
        }
    }
}
