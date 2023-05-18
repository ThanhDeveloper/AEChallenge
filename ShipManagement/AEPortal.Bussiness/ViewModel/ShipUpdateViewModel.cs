using System.ComponentModel.DataAnnotations;

namespace AEPortal.Bussiness.ViewModel
{
    public class ShipUpdateViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public decimal Latitude { get; set; } //##.######
        public decimal Longitude { get; set; } //###.######
        public double Velocity { get; set; }
    }
}
