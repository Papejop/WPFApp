using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp.Models
{
    public class Documents
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public ICollection<DocumentItem> Items { get; set; } = new List<DocumentItem>();

        [NotMapped]
        public int ItemCount => Items?.Count ?? 0;

    }
}
