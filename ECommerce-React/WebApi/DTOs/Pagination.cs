using System.Collections.Generic;

namespace WebApi.DTOs
{
    public class Pagination<T> where T : class
    {
        public int Count { get; set; } /*cantidad de elementos de la entidad que se esta consultando*/
        public int PageIndex { get; set; } 
        public int PageSize { get; set; }
        public IReadOnlyList<T> Data { get; set; }
        public int PageCount { get; set; }
    }
}
