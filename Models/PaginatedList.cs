namespace Shoes_Ecommerce.Models
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }

        public PaginatedList(List<T> items , int count , int pageIndex , int pageSize )
        {
            PageIndex = pageIndex;
            TotalItems = (int)Math.Ceiling(count/(double)pageSize);
            Items = items;
        }

        public bool MaxPerviousPage => (PageIndex > 1);
        public bool MaxNextPage => (PageIndex < TotalItems);
        public int PreviousPageIndex => PageIndex - 1;
        public int FirstItemIndex => (PageIndex - 1) * PageSize + 1;
        public int LastItemIndex => Math.Min(PageIndex * PageSize, TotalItems);

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
}
