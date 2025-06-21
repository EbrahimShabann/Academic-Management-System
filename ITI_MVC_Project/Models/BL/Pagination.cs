using Microsoft.EntityFrameworkCore;

namespace ITI_MVC_Project.Models.BL
{
    public static class IQueryableExtensions
    {
        public static PagedResult<T> ToPagedResult<T>( this IEnumerable<T> query, int pageNumber, int pageSize)
        {
            var totalItemsCount =  query.Count();
            var items =  query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            var totalItems =  query.ToList();
            return new PagedResult<T>
            {
                Items = items,
                TotalItems=totalItems,
                TotalItemsCount = totalItemsCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
            };
        }
    }

}
