using System.Collections.Generic;
using System.Linq;

namespace TechnicalRadiation.Services.Interfaces
{
    public static class PageService<T>
    {
        public static IEnumerable<T> PageData(IEnumerable<T> Data, int PageNumber, int PageSize)
        {
            return Data.Skip((PageNumber-1)*PageSize).Take(PageSize);
        }
    }
}