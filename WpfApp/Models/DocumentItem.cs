using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class DocumentItem
    {
        public int DocumentId { get; set; }
        public int Ordinal { get; set; }
        public string Product { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TaxRate { get; set; }

        public Documents Document { get; set; } = null!;
    }
}
