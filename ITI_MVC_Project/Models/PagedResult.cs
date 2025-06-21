namespace ITI_MVC_Project.Models
{
   
        public class PagedResult<T>
        {
            public List<T> Items { get; set; } = new();
            public List<T> TotalItems { get; set; } = new();        //was made for course Results to get course name  
            public int TotalItemsCount { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public int TotalPages => (int)Math.Ceiling((double)TotalItemsCount / PageSize);

    }

    
}
