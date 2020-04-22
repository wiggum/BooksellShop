using System.ComponentModel.DataAnnotations;

namespace Data.DataSources
{
    public partial class SelectedCompositionDataSource
    {
        public int BooksellId { get; set; }
        public int CompositionId { get; set; }
        
        public BooksellDataSource Booksell { get; set; }
        public CompositionDataSource Composition { get; set; }
    }
}