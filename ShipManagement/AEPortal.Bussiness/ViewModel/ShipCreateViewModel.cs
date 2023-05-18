using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEPortal.Bussiness.ViewModel
{
    public class ShipCreateViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public decimal Latitude { get; set; } //##.######
        public decimal Longitude { get; set; } //###.######
        public double Velocity { get; set; }
    }
}
