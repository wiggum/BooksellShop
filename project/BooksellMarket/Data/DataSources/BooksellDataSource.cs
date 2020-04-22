using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.DataSources
{
    public partial class BooksellDataSource
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<ActiveOrderDataSource> Orders { get; set; }
        public IEnumerable<SelectedCompositionDataSource> Compositions { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }
    }
}