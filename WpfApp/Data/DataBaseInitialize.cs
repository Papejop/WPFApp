using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using var db = new DataBaseContext();
            db.Database.EnsureCreated();
        }
    }
}
