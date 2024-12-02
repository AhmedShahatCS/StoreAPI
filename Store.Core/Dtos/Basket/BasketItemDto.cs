using System.ComponentModel.DataAnnotations;

namespace Store.Core.Dtos.Basket
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string PictureUrl { get; set; }
        [Required]

        public string Brand { get; set; }
        [Required]

        public string Type { get; set; }
        [Required]
        [Range(0.1,double.MaxValue,ErrorMessage = "price can to be 0")]
        public Decimal Price { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Quantity must be 1 at least")]
        public int Quantity { get; set; }
    }
}