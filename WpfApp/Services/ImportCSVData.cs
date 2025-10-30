using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using WpfApp.Data;
using WpfApp.Models;

namespace WpfApp.Services
{
    public class ImportCSVData
    {
        public static void ImportData(string path)
        {
            string? firstLine = File.ReadLines(path).FirstOrDefault();
            int fileType = VerifyContents(firstLine);

            if (fileType == -1)
                return;

            using DataBaseContext db = new DataBaseContext();

            if (fileType == 1)
                ImportDocuments(path, db);

            if (fileType == 2)
                ImportDocumentItems(path, db);

            db.SaveChanges();
        }

        public static void ImportDocuments(string path, DataBaseContext database)
        {
            var lines = File.ReadAllLines(path).Skip(1);

            foreach (var line in lines)
            {
                if(string.IsNullOrEmpty(line)) continue; // TODO: add better validation of data

                var parts = line.Split(";");

                Documents document = new Documents
                {
                    Id = int.Parse(parts[0]),
                    Type = parts[1],
                    Date = DateTime.Parse(parts[2]),
                    FirstName = parts[3],
                    LastName = parts[4],
                    City = parts[5]
                };

                database.Documents.Add(document);
            }
        }

        public static void ImportDocumentItems(string path, DataBaseContext database)
        {
            var lines = File.ReadAllLines(path).Skip(1);

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line)) continue; // TODO: add better validation of data

                var parts = line.Split(";");

                DocumentItem documentItem = new DocumentItem
                {
                    DocumentId = int.Parse(parts[0]),
                    Ordinal = int.Parse(parts[1]),
                    Product = parts[2],
                    Quantity = int.Parse(parts[3]),
                    Price = decimal.Parse(parts[4]),
                    TaxRate = decimal.Parse(parts[5])
                };

                database.DocumentItems.Add(documentItem);
            }
        }

        public static int VerifyContents(string? firstLine)
        {
            if (firstLine == null)
                return -1;
            else if (firstLine.Trim() == "Id;Type;Date;FirstName;LastName;City")
                return 1;
            else if (firstLine.Trim() == "DocumentId;Ordinal;Product;Quantity;Price;TaxRate")
                return 2;
            else
                return -1;
        }

    }
}

    