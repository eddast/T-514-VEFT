using System.Collections.Generic;

namespace template.Models
{
    public class Envelope<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int MaxPages { get; set; }
    }
}