namespace AdsService.Models
{


    //класс предназначен для вывода дополнительных полей (fields=true)
    public class AdOptFieldsResp:AdResp
    {


        public string Description { get; set; }
        public IList<string> OptionalPhotos { get; set; }=new List<string>();
        public DateTime DateCreated { get; set; }


        
    }
}
