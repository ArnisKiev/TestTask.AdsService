using AdsService.Tools.Atributes;
using AdsService.Tools.Atributtes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseServises.Models
{
    public class Ad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string? Title { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [MinCountItems(1,ErrorMessage ="Min count of items is 1")]
        [MaxCountItems(3, ErrorMessage ="Max count of items is 3")]
        public IList<Photo> Photos { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Price { get; set; }
        public Ad()=>Photos = new List<Photo>();

      
    }
}
