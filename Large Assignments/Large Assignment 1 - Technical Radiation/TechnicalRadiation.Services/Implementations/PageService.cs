using System;
using System.Collections.Generic;
using System.Linq;

namespace TechnicalRadiation.Services.Interfaces
{
    /// <summary>
    /// Handles paging in system
    /// </summary>
    /// <typeparam name="T">Type of data to handle paging on</typeparam>
    public static class PageService<T> where T : class
    {
        /// <summary>
        /// Partitions list of data appropriately in relation to page number and page size
        /// </summary>
        /// <param name="Data">Data to page</param>
        /// <param name="PageNumber">number of items per page</param>
        /// <param name="PageSize">number of page index</param>
        /// <returns></returns>
        public static IEnumerable<T> PageData(IEnumerable<T> Data, int PageNumber, int PageSize)
        {
            return Data.Skip((PageNumber-1)*PageSize).Take(PageSize);
        }
        /// <summary>
        /// Calculates the number of pages needed to contain paged data
        /// </summary>
        /// <param name="DataSize">Size of data set</param>
        /// <param name="PageSize">Items per page</param>
        /// <returns>Number of pages needed to contain paged data</returns>
        public static int GetMaxPages(int DataSize, int PageSize) => 
            (int) Math.Ceiling(((double)DataSize) / ((double)PageSize));
    }
}