namespace AdsService.Models
{

    // базовый класс для вывода данных объявления
    public class AdResp
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string MainPhoto { get; set;}
        public decimal Price { get; set;}


    }
}
