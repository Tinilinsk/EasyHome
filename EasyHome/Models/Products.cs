using System;
using System.Collections.Generic;
using System.Text;

namespace EasyHome.Models
{
    public class Products
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool InStock { get; set; }
    }
}
