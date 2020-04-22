using System.Collections.Generic;

namespace WebAPI.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public IEnumerable<BooksellDTO> Orders { get; set; }
    }
}