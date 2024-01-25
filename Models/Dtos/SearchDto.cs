namespace Fuen31Site.Models.Dtos
{
    public class SearchDto
    {
        //搜尋相關
        public string? keyword { get; set; }
        public int? categoryId { get; set; } = 0; //0 表示不根據分類編號進行搜尋

        //排序相關
        public string? sortBy { get; set; }
        public string? sortType { get; set; } = "asc"; //desc

        //分頁相關
        public int? Page { get; set; } = 1; //第一頁
        public int? pageSize { get; set; } = 9; //一頁顯示9筆資料
    }
}
