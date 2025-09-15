using System.ComponentModel.DataAnnotations;

namespace FoodSIMULACRO.Models
{
    public class Bebida
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Nombre { get; set; } = null!;

        [Required, MaxLength(50)]
        public string Color { get; set; } = null!;

        // Usa decimal para dinero
        [Range(0, 999999)]
        public decimal Precio { get; set; }
    }
}