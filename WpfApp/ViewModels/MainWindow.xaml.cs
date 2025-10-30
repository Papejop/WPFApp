using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Data;
using WpfApp.Models;
using WpfApp.Services;

namespace WpfApp.ViewModels
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Documents> _documents = new();
        private CollectionView? _documentsView;

        public MainWindow()
        {
            InitializeComponent();
            LoadDocumentsFromDatabase();
        }

        private void ImportCSV_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            //dialog.FileName = "Document";
            dialog.DefaultExt = ".csv";
            dialog.Filter = "CSV files (*.csv)|*.csv";

            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                string filename = dialog.FileName;

                try
                {
                    ImportCSVData.ImportData(filename);

                    MessageBox.Show("CSV import completed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadDocumentsFromDatabase();
                }
                catch
                {
                    MessageBox.Show("Error importing CSV", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void LoadDocumentsFromDatabase()
        {
            using var db = new DataBaseContext();
            var documents = db.Documents.Include(d => d.Items).ToList();

            _documents = new ObservableCollection<Documents>(documents);
            _documentsView = (CollectionView)CollectionViewSource.GetDefaultView(_documents);
            DataGridDocuments.ItemsSource = _documentsView;
        }

        private void DataGridDocuments_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataGridDocuments.SelectedItem is Documents selectedDocument)
            {
                var itemsWindow = new DocumentItemsWindow(selectedDocument.Id);
                itemsWindow.ShowDialog();
            }
        }
        private void CSV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using var db = new DataBaseContext();
            db.DocumentItems.RemoveRange(db.DocumentItems);
            db.Documents.RemoveRange(db.Documents);
            db.SaveChanges();
            LoadDocumentsFromDatabase();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_documentsView == null) return;

            string filterText = SearchBox.Text.ToLower();

            _documentsView.Filter = doc =>
            {
                var document = doc as Documents;
                if (document == null) return false;

                return document.Id.ToString().Contains(filterText)
                    || document.Type.ToLower().Contains(filterText)
                    || document.FirstName.ToLower().Contains(filterText)
                    || document.LastName.ToLower().Contains(filterText)
                    || document.City.ToLower().Contains(filterText);
            };
        }
    }
}