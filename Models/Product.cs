using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Models
{
    public class Product
    { 


        [Key]
        public long? product_id { get; set; }

        [Required]
        public string? product_name { get; set; }
        public string? product_details {  get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal? product_price {  get; set; }
        public string? product_category {  get; set; }

    }
}
