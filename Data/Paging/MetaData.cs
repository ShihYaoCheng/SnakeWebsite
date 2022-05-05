namespace SnakeAsianLeague.Data.Paging
{
    public class MetaData
    {
        /// <summary>
        /// 當前頁面
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// 頁簽數
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// 一頁顯示資料筆數
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 總比數
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 上一頁
        /// </summary>
        public bool HasPrevious => CurrentPage > 1;
        /// <summary>
        /// 下一頁
        /// </summary>
        public bool HasNext => CurrentPage < TotalPages;
    }
}
