using System.ComponentModel.DataAnnotations;

namespace SportStore.Models
{
    public class Cart
    {
        [Key]
        public int? cart_id { get; set; }
        [Required]
        public int? product_id { get; set;}
        public int? total {  get; set; }


    }
}
