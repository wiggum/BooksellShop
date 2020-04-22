using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.DataSources
{
    public partial class ActiveOrderDataSource
    {
        public int OrderId { get; set; }
        public int BooksellId { get; set; }
        
        public OrderDataSource Order { get; set; }
        public BooksellDataSource Booksell { get; set; }
        public DateTime OrderTime { get; set; }
    }
}