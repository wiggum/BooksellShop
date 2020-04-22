using System.Collections.Generic;

namespace Domain.Entities
{
    public class Booksell: IEntityIdentity
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Composition> Compositions { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}